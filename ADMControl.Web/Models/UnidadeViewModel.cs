namespace ADMControl.Web.Models
{
    public class UnidadeViewModel : Controller
    {
        public Unidade Unidade { get; set; }
        public List<Unidade> Unidades { get; set; }
        public UnidadeViewModel()
        {
            Unidade = new Unidade();
            Unidades = new List<Unidade>();
        }

        public async Task Load(IUnidadeRepositorio repUni, int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    this.Unidade = await repUni.BuscarUnidadePorId(id);
                }
                this.Unidades = await repUni.ListarUnidades();
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
