namespace ADMControl.Web.Models
{
    public class ColaboradorViewModel
    {
        public Colaborador Colaborador { get; set; }
        public List<Colaborador> Colaboradores { get; set; }
        public ColaboradorViewModel()
        {
            Colaborador = new Colaborador();
            Colaboradores = new List<Colaborador>();
        }

        public async Task Load(IColaboradorRepositorio repCol, int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    this.Colaborador = await repCol.BuscarColaboradorPorId(id);
                }
                this.Colaboradores = await repCol.ListarColaboradores();
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
