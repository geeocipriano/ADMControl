namespace ADMControl.Web.Controllers
{
    public class CategoriaController : Controller
    {
        private ICategoriaRepositorio _repCat;

        public CategoriaController(ICategoriaRepositorio repCat)
        {
            _repCat = repCat;
        }
        public async Task<IActionResult> Index()
        {
            CategoriaViewModel model = new();
            await model.Load(_repCat, null);

            return View(model);
        }

        public async Task<IActionResult> Cadastro(int? Id)
        {
            try
            {
                CategoriaViewModel model = new();
                await model.Load(_repCat, Id);

                return PartialView("PartialCadastro", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Cadastro(int idCategoria, string nomeCategoria)
        {
            try
            {
                if (idCategoria == 0)
                {
                    Categoria categoria = new Categoria
                    {
                        CAT_NOME = nomeCategoria,
                    };
                    await _repCat.Salvar(categoria);
                }
                else
                {
                    Categoria categoria = new Categoria
                    {
                        CAT_ID = idCategoria,
                        CAT_NOME = nomeCategoria,
                    };
                    await _repCat.Salvar(categoria);
                }


                //CategoriaViewModel model = new CategoriaViewModel();
                //await model.Load(_repCat, null);
                List<Categoria> categorias = new();

                categorias = await _repCat.ListarCategorias();

                IEnumerable<Categoria> regCat = categorias.AsEnumerable();

                return PartialView("PartialListaDatatable", regCat);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirCategoria(int Id)
        {
            try
            {
                await _repCat.Delete(Id);
                List<Categoria> categorias = await _repCat.ListarCategorias();

                IEnumerable<Categoria> regCat = categorias.AsEnumerable();

                return PartialView("PartialListaDatatable", regCat);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IActionResult> PartialListaCategorias()
        {
            try
            {

                List<Categoria> categorias = new();

                categorias = await _repCat.ListarCategorias();

                IEnumerable<Categoria> regCat = categorias.AsEnumerable();

                return PartialView("PartialListaDatatable", regCat);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
