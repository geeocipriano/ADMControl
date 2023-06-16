namespace ADMControl.Dominio.Repositorios.RepColaborador
{
    public interface IColaboradorRepositorio
    {
        Task<Colaborador> BuscarColaboradorPorId(int? Id);
        Task<List<Colaborador>> ListarColaboradores();
        Task<int> ContarColaboradores();
        Task<Colaborador> Salvar(Colaborador obj);
        Task<bool> Delete(int? Id);
    }
}
