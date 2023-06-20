namespace ADMControl.Dominio.Repositorios.RepEntrada
{
    public interface IEntradaRepositorio
    {
        Task<Entrada> BuscarEntradaPorId(int? Id);
        Task<List<Entrada>> ListarEntradas();
        Task<Entrada> Salvar(Entrada obj);
        Task<bool> Delete(int? Id);
    }
}
