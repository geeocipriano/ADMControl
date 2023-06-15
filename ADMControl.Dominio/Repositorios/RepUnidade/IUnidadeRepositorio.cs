namespace ADMControl.Dominio.Repositorios.RepUnidade
{
    public interface IUnidadeRepositorio
    {
        Task<Unidade> BuscarUnidadePorId(int? Id);
        Task<List<Unidade>> ListarUnidades();
        Task<int> ContarUnidades();
        Task<Unidade> Salvar(Unidade obj);
        Task<bool> Delete(int? Id);
    }
}
