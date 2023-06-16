namespace ADMControl.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private IProdutoRepositorio _repPro;
        private ICategoriaRepositorio _repCat;
        private IUnidadeRepositorio _repUni;

        public ProdutoController(IProdutoRepositorio repPro, ICategoriaRepositorio repCat, IUnidadeRepositorio repUni)
        {
            _repPro = repPro;
            _repCat = repCat;
            _repUni = repUni;
        }
        public async Task<IActionResult> Index()
        {
            ProdutoViewModel model = new();
            await model.Load(_repCat, _repUni, _repPro, null);

            return View(model);
        }

        public async Task<IActionResult> Cadastro(int? Id)
        {
            try
            {
                ProdutoViewModel model = new();
                await model.Load(_repCat, _repUni, _repPro, Id);

                return PartialView("PartialCadastro", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Cadastro(int idProduto, string descProduto, int idCategoria, int idUnidade, double estoqueMinimo, double estoqueMaximo, double estoqueAtual)
        {
            try
            {
                if (idProduto == 0)
                {
                    Produto produto = new Produto()
                    {
                        PRO_DESC = descProduto,
                        PRO_IDCATEGORIA = idCategoria,
                        PRO_IDUNIDADE = idUnidade,
                        PRO_MIN = estoqueMinimo,
                        PRO_MAX = estoqueMaximo,
                        PRO_ATU = estoqueAtual
                    };

                    var prod = produto;
                    await _repPro.Salvar(produto);
                }
                else
                {
                    Produto produto = new Produto()
                    {
                        PRO_ID = idProduto,
                        PRO_DESC = descProduto,
                        PRO_IDCATEGORIA = idCategoria,
                        PRO_IDUNIDADE = idUnidade,
                        PRO_MIN = estoqueMinimo,
                        PRO_MAX = estoqueMaximo,
                        PRO_ATU = estoqueAtual
                    };

                    Categoria categoria = await _repCat.BuscarCategoriaPorId(1);
                    Unidade unidade = await _repUni.BuscarUnidadePorId(1);

                    produto.Categoria = categoria;
                    produto.Unidade = unidade;
                    await _repPro.Salvar(produto);
                }

                List<Produto> produtos = new();

                produtos = await _repPro.ListarProdutos();
                IEnumerable<Produto> regPro = produtos.AsEnumerable();

                return PartialView("PartialListaDatatable", regPro);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirProduto(int Id)
        {
            try
            {
                await _repPro.Delete(Id);
                //ProdutoViewModel model = new();
                //await model.Load(_repCat, _repUni, _repPro, null);

                List<Produto> produtos = new();

                produtos = await _repPro.ListarProdutos();
                IEnumerable<Produto> regPro = produtos.AsEnumerable();

                return PartialView("PartialListaDatatable", regPro);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IActionResult> PartialListaProdutos()
        {
            try
            {

                List<Produto> produtos = new();

                produtos = await _repPro.ListarProdutos();
                IEnumerable<Produto> regPro = produtos.AsEnumerable();

                return PartialView("PartialListaDatatable", regPro);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
