namespace ADMControl.Web.Controllers
{
    public class EntradaController : Controller
    {
        private IEntradaRepositorio _repEnt;
        private IProdutoRepositorio _repProd;

        public EntradaController(IEntradaRepositorio repEnt, IProdutoRepositorio repProd)
        {
            _repEnt = repEnt;
            _repProd = repProd;
        }
        public async Task<IActionResult> Index()
        {
            EntradaViewModel model = new();
            await model.Load(_repProd, _repEnt, null);

            return View(model);
        }

        public async Task<IActionResult> Cadastro(int? Id)
        {
            try
            {
                EntradaViewModel model = new();
                await model.Load(_repProd, _repEnt, Id);

                return PartialView("PartialCadastro", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IActionResult> AbreProdutos(int Id)
        {
            try
            {
                List<ProdutoxEntrada> produtos = new();

                produtos = await _repEnt.ListarProdutosxEntrada(Id);
                IEnumerable<ProdutoxEntrada> regEnt = produtos.AsEnumerable();

                return PartialView("PartialListaItens", regEnt);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Cadastro(int idEntrada, int numeroEntrada, string nomeFornecedor)
        {
            try
            {
                if (idEntrada == 0)
                {
                    Entrada entrada = new()
                    {
                        ENT_NUMERO = numeroEntrada,
                        ENT_DATA = DateTime.Now,
                        ENT_FORNECEDOR = nomeFornecedor
                    };
                    await _repEnt.Salvar(entrada);
                }
                else
                {
                    Entrada entrada = new()
                    {
                        ENT_ID = idEntrada,
                        ENT_NUMERO = numeroEntrada,
                        ENT_DATA = DateTime.Now,
                        ENT_FORNECEDOR = nomeFornecedor
                    };
                    await _repEnt.Salvar(entrada);
                }

                List<Entrada> entradas = new();

                entradas = await _repEnt.ListarEntradas();
                IEnumerable<Entrada> regEnt = entradas.AsEnumerable();

                return PartialView("PartialListaDatatable", regEnt);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirEntrada(int Id)
        {
            try
            {
                await _repEnt.Delete(Id);
                List<Entrada> entradas = await _repEnt.ListarEntradas();

                IEnumerable<Entrada> regEnt = entradas.AsEnumerable();

                return PartialView("PartialListaDatatable", regEnt);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarProduto(int idEntrada, int idProduto)
        {
            try
            {
                ProdutoxEntrada pxe = new()
                {
                    PXE_IDENTRADA = idEntrada,
                    PXE_IDPRODUTO = idProduto,
                    PXE_QUANTIDADE = 1.5
                };
                await _repEnt.SalvarProduto(pxe);

                Produto prod = await _repProd.BuscarProdutoPorId(pxe.PXE_IDPRODUTO);
                prod.PRO_ATU += pxe.PXE_QUANTIDADE;
                await _repProd.Salvar(prod);


                List<ProdutoxEntrada> produtos = new();

                produtos = await _repEnt.ListarProdutosxEntrada(idEntrada);
                IEnumerable<ProdutoxEntrada> regEnt = produtos.AsEnumerable();

                return PartialView("PartialListaItens", regEnt);
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
                ProdutoxEntrada proxe = await _repEnt.BuscarProdutoPorId(Id);
                await _repEnt.DeleteProduto(Id);


                Produto prod = await _repProd.BuscarProdutoPorId(proxe.PXE_IDPRODUTO);
                prod.PRO_ATU -= proxe.PXE_QUANTIDADE;
                await _repProd.Salvar(prod);

                List<ProdutoxEntrada> produtos = new();

                produtos = await _repEnt.ListarProdutosxEntrada(proxe.PXE_IDENTRADA);
                IEnumerable<ProdutoxEntrada> regEnt = produtos.AsEnumerable();

                return PartialView("PartialListaItens", regEnt);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
