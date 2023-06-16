namespace ADMControl.Web.Controllers
{
    public class ColaboradorController : Controller
    {
        private IColaboradorRepositorio _repCol;

        public ColaboradorController(IColaboradorRepositorio repCol)
        {
            _repCol = repCol;
        }
        public async Task<IActionResult> Index()
        {
            ColaboradorViewModel model = new();
            await model.Load(_repCol, null);

            return View(model);
        }
        public async Task<IActionResult> Cadastro(int? Id)
        {
            try
            {
                ColaboradorViewModel model = new();
                await model.Load(_repCol, Id);

                return PartialView("PartialCadastro", model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> Cadastro(int idColaborador, string nomeColaborador, bool colaboradorAtivo)
        {
            try
            {
                if (idColaborador == 0)
                {
                    Colaborador colaborador = new()
                    {
                        COL_NOME = nomeColaborador,
                        COL_ATIVO = colaboradorAtivo,
                    };
                    await _repCol.Salvar(colaborador);
                }
                else
                {
                    Colaborador colaborador = new()
                    {
                        COL_ID = idColaborador,
                        COL_NOME = nomeColaborador,
                        COL_ATIVO = colaboradorAtivo,
                    };
                    await _repCol.Salvar(colaborador);
                }

                List<Colaborador> colaboradores = await _repCol.ListarColaboradores();

                IEnumerable<Colaborador> regCol = colaboradores.AsEnumerable();

                return PartialView("PartialListaDatatable", regCol);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> ExcluirColaborador(int Id)
        {
            try
            {
                await _repCol.Delete(Id);
                List<Colaborador> colaboradores = await _repCol.ListarColaboradores();

                IEnumerable<Colaborador> regCol = colaboradores.AsEnumerable();

                return PartialView("PartialListaDatatable", regCol);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
