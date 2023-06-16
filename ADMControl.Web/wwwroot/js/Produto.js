$(document).ready(function () {
    criarTabela()
    $(document).on('click', '#modal-default .btn-primary', function () {
        salvarProduto();
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
    $("#divListProduto").html(data);
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
        url: "/Produto/Cadastro",
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

function salvarProduto() {
    const Id = $('#Id').val();
    const categoria = $('#FilListaCategoria').val();
    const unidade = $('#FilSelectedUnidade').val();
    const desc = $('#Descricao').val();
    const estminimo = $('#Estmin').val();
    const estmaximo = $('#Estmax').val();
    const estatual = $('#Estatu').val();
    $.ajax({
        type: 'POST',
        url: '/Produto/Cadastro',
        data: { idProduto: Id, descProduto: desc, idCategoria: categoria, idUnidade: unidade, estoqueMinimo: estminimo, estoqueMaximo: estmaximo, estoqueAtual: estatual },
        success: function (data) {
            refreshTabela(data)
        },
        error: function (xhr, status, error) {
            console.error('Erro na requisição:', error);
        }
    });
}

const ExcluirProduto = (id) => {
    $.ajax({
        type: 'POST',
        url: '/Produto/ExcluirProduto',
        data: { Id: id },
        success: function (data) {
            refreshTabela(data)
        },
        error: function (xhr, status, error) {
            console.error('Erro na requisição:', error);
        }
    });
}