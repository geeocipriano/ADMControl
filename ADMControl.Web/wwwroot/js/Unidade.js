$(document).ready(function () {
    criarTabela()
    $(document).on('click', '#modal-default .btn-primary', function () {
        salvarUnidade();
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
    $("#divListUnidade").html(data);
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
        url: "/Unidade/Cadastro",
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

function salvarUnidade() {
    const Id = $('#Id').val();
    const sigla = $('#Sigla').val();
    const nome = $('#Nome').val();
    $.ajax({
        type: 'POST',
        url: '/Unidade/Cadastro',
        data: { idUnidade: Id, siglaUnidade: sigla ,nomeUnidade: nome },
        success: function (data) {
            refreshTabela(data)
        },
        error: function (xhr, status, error) {
            console.error('Erro na requisição:', error);
        }
    });
}

const ExcluirUnidade = (id) => {
    $.ajax({
        type: 'POST',
        url: '/Unidade/ExcluirUnidade',
        data: { Id: id },
        success: function (data) {
            refreshTabela(data)
        },
        error: function (xhr, status, error) {
            console.error('Erro na requisição:', error);
        }
    });
}