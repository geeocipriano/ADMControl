$(document).ready(function () {
    // Configuração do DataTable
    $("#example2").DataTable({
        "responsive": true,
        "lengthChange": false,
        "autoWidth": false,
        "buttons": ["copy", "csv", "excel", "pdf", "print", "colvis"]
    });

    console.log("Documento carregado ADMM");



     //Adicionar evento de clique ao botão "Salvar"
    $(document).on('click', '#modal-default .btn-primary', function () {
        salvarProduto();
    });
});


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
    // Obtém os valores dos campos do formulário
    const descricao = $('#Descricao').val();
    const unidade = $('#Unidade').val();
    const categoria = $('#Categoria').val();
    const estmin = $('#Estmin').val();
    const estmax = $('#Estmax').val();
    const estatu = $('#Estatu').val();

    // Cria um objeto com os dados do produto
    const produto = {
        PRD_DESC: descricao,
        Unidade: unidade,
        Categoria: categoria,
        PRD_ESTMIN: estmin,
        PRD_ESTMAX: estmax,
        PRD_ESTATU: estatu
    };

    // Faz a requisição POST usando $.ajax
    $.ajax({
        type: 'POST',
        url: '/Produto/Cadastro',
        data: produto,
        success: function (response) {
            // Requisição bem-sucedida, faça algo aqui (por exemplo, fechar o modal)
            $('#modal-default').modal('hide');
            // Outras ações que você deseja executar após o salvamento
        },
        error: function (xhr, status, error) {
            // Ocorreu um erro durante a requisição, faça algo aqui
            console.error('Erro na requisição:', error);
        }
    });
}




//function salvarProduto() {
//    console.log("fORM carregado ADMM");
//    var formData = new FormData();
//    //formData.append('produto.PRD_DESC', descricao);
//    //formData.append('produto.PRD_ID', $('#Id').val());
//    var descricao = $('#Descricao').val();
//    formData.append('produto.PRD_DESC', $('#Descricao').val());
//    formData.append('produto.PRD_IDUNIDADE', $('#Unidade').val());
//    formData.append('produto.PRD_IDCATEGORIA', $('#Categoria').val());
//    formData.append('produto.PRD_ESTMIN', $('#Estmin').val());
//    formData.append('produto.PRD_ESTMAX', $('#Estmax').val());
//    formData.append('produto.PRD_ESTATU', $('#Estatu').val());
//    $.ajax({
//        url: '/Produto/SalvarProduto',
//        method: 'POST',
//        processData: false,
//        contentType: false,
//        data: formData,
//        success: function (data) {
//            if (data.success) {
//                window.location.href = "/Produto/";
//            } else {
//                alert('Erro ao salvar produto.');
//            }
//        },
//        error: function () {
//            $("#loadingModal").modal("hide");
//            alert('Erro ao salvar produto.');
//        }
//    });
//}