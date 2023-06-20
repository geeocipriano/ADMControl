namespace ADMControl.Web.Models
{
    public class EntradaViewModel
    {
        public Entrada Entrada { get; set; }
        public List<Entrada> Entradas { get; set; }
        public List<ProdutoxEntrada> ProdutoxEntradas { get; set; }
        public EntradaViewModel()
        {
            Entrada = new Entrada();
            Entradas = new List<Entrada>();
            ProdutoxEntradas = new();
        }

        public async Task Load(IEntradaRepositorio repEnt, int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    this.Entrada = await repEnt.BuscarEntradaPorId(id);
                }
                this.Entradas = await repEnt.ListarEntradas();
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
