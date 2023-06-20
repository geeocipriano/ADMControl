$(document).ready(function () {
    criarTabela()
    $(document).on('click', '#modal-default .btn-primary', function () {
        salvarEntrada();
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
    $("#divListEntrada").html(data);
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
        url: "/Entrada/Cadastro",
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

function salvarEntrada() {
    const Id = $('#Id').val();
    const numero = $('#Numero').val();
    const fornecedor = $('#Fornecedor').val();
    $.ajax({
        type: 'POST',
        url: '/Entrada/Cadastro',
        data: { idEntrada: Id, numeroEntrada: numero, nomeFornecedor: fornecedor },
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