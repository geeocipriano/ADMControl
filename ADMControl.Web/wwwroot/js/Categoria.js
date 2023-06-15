$(document).ready(function () {
    criarTabela()
    //$('#example2').DataTable({
    //    language: {
    //        url: '//cdn.datatables.net/plug-ins/1.13.4/i18n/pt-BR.json',
    //    },
    //});
    //let table = new DataTable('#example2');

    $(document).on('click', '#modal-default .btn-primary', function () {
        salvarCategoria();
    });
    $(document).on('click', '#ExcluirCategoria .btn-primary', function () {
        ExcluirCategoria();
    });
});

function criarTabela() {
    $('#example2').DataTable({
        language: {
            url: '//cdn.datatables.net/plug-ins/1.13.4/i18n/pt-BR.json',
        },
    });
}

function refreshTabela(data) {
    $('#example2').DataTable().clear().destroy();
    $("#divListCategoria").html(data);
    $('#example2').DataTable({
        language: {
            url: '//cdn.datatables.net/plug-ins/1.13.4/i18n/pt-BR.json',
        },
    });
    $('#modal-default').modal('hide');
}

const AbreCadastro = (_Id) => {
    $.ajax({
        type: "get",
        url: "/Categoria/Cadastro",
        data: { id: _Id },
        cache: false,
        beforeSend: function (data) {
        },
        success: function (data) {
            $("#divModalCadastro").html("");
            $("#divModalCadastro").html(data);
            $('#modal-default').modal('show');

        },
        complete: function (data) {
        },
        error: function (data) {
            console.log(data);
            swal({
                title: "Falha ao carregar dados!",
                text: data.responseText,
                icon: "error",
                button: "Ok",
            });
        }
    });
}

function salvarCategoria() {
    const Id = $('#Id').val();
    const nome = $('#Nome').val();
    $.ajax({
        type: 'POST',
        url: '/Categoria/Cadastro',
        data: { idCategoria: Id , nomeCategoria: nome},
        success: function (data) {
            refreshTabela(data)
        },
        error: function (xhr, status, error) {
            console.error('Erro na requisição:', error);
        }
    });
}

const ExcluirCategoria = (id) => {
    $.ajax({
        type: 'POST',
        url: '/Categoria/ExcluirCategoria',
        data: { Id: id },
        success: function (data) {
            refreshTabela(data)
        },
        error: function (xhr, status, error) {
            console.error('Erro na requisição:', error);
        }
    });
}