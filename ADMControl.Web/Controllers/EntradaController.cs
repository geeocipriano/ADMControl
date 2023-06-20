namespace ADMControl.Web.Controllers
{
    public class EntradaController : Controller
    {
        private IEntradaRepositorio _repEnt;

        public EntradaController(IEntradaRepositorio repEnt)
        {
            _repEnt = repEnt;
        }
        public async Task<IActionResult> Index()
        {
            EntradaViewModel model = new();
            await model.Load(_repEnt, null);

            return View(model);
        }

        public async Task<IActionResult> Cadastro(int? Id)
        {
            try
            {
                EntradaViewModel model = new();
                await model.Load(_repEnt, Id);

                return PartialView("PartialCadastro", model);
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
                    Entrada entrada = new Entrada()
                    {
                        ENT_NUMERO = numeroEntrada,
                        ENT_DATA = DateTime.Now,
                        ENT_FORNECEDOR = nomeFornecedor
                    };
                    await _repEnt.Salvar(entrada);
                }
                else
                {
                    Entrada entrada = new Entrada()
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
    }
}
