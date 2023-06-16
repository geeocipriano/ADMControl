$(document).ready(function () {
    criarTabela()
    $(document).on('click', '#modal-default .btn-primary', function () {
        salvarColaborador();
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
    $("#divListColaborador").html(data);
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
        url: "/Colaborador/Cadastro",
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

function salvarColaborador() {
    const Id = $('#Id').val();
    const nome = $('#Nome').val();
    const ativo = $('#ativo').prop('checked');
    $.ajax({
        type: 'POST',
        url: '/Colaborador/Cadastro',
        data: { idColaborador: Id, nomeColaborador: nome, colaboradorAtivo: ativo},
        success: function (data) {
            refreshTabela(data)
        },
        error: function (xhr, status, error) {
            console.error('Erro na requisição:', error);
        }
    });
}

const ExcluirColaborador = (id) => {
    $.ajax({
        type: 'POST',
        url: '/Colaborador/ExcluirColaborador',
        data: { Id: id },
        success: function (data) {
            refreshTabela(data)
        },
        error: function (xhr, status, error) {
            console.error('Erro na requisição:', error);
        }
    });
}