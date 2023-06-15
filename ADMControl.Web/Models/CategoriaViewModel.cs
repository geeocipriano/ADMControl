namespace ADMControl.Web.Models
{
    public class CategoriaViewModel : Controller
    {
        public Categoria? Categoria { get; set; }
        public List<Categoria>? Categorias { get; set; }
        public CategoriaViewModel()
        {
            Categoria = new Categoria();
            Categorias = new List<Categoria>();
        }

        public async Task Load(ICategoriaRepositorio repCat, int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    this.Categoria = await repCat.BuscarCategoriaPorId(id);
                }
                this.Categorias = await repCat.ListarCategorias();
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}