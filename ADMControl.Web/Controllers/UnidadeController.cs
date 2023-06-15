namespace ADMControl.Web.Controllers
{
    public class UnidadeController : Controller
    {
        private IUnidadeRepositorio _repUni;

        public UnidadeController(IUnidadeRepositorio repUni)
        {
            _repUni = repUni;
        }
        public async Task<IActionResult> Index()
        {
            UnidadeViewModel model = new();
            await model.Load(_repUni, null);

            return View(model);
        }

        public async Task<IActionResult> Cadastro(int? Id)
        {
            try
            {
                UnidadeViewModel model = new();
                model = new();
                await model.Load(_repUni, Id);

                return PartialView("PartialCadastro", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Cadastro(int idUnidade, string siglaUnidade, string nomeUnidade)
        {
            try
            {
                if (idUnidade == 0)
                {
                    Unidade unidade = new()
                    {
                        UNI_SIGLA = siglaUnidade,
                        UNI_NOME = nomeUnidade,
                    };
                    await _repUni.Salvar(unidade);
                }
                else
                {
                    Unidade unidade = new()
                    {
                        UNI_SIGLA = siglaUnidade,
                        UNI_NOME = nomeUnidade,
                    };
                    await _repUni.Salvar(unidade);
                }

                List<Unidade> unidades = await _repUni.ListarUnidades();

                IEnumerable<Unidade> regUni = unidades.AsEnumerable();

                return PartialView("PartialListaDatatable", regUni);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirUnidade(int Id)
        {
            try
            {
                await _repUni.Delete(Id);
                List<Unidade> unidades = await _repUni.ListarUnidades();

                IEnumerable<Unidade> regUni = unidades.AsEnumerable();

                return PartialView("PartialListaDatatable", regUni);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IActionResult> PartialListaUnidades()
        {
            try
            {

                List<Unidade> unidades = new();

                unidades = await _repUni.ListarUnidades();

                IEnumerable<Unidade> regUni = unidades.AsEnumerable();

                return PartialView("PartialListaDatatable", regUni);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
