namespace ADMControl.Dominio.Repositorios.RepCategoria
{
    public interface ICategoriaRepositorio
    {
        Task<Categoria> BuscarCategoriaPorId(int? Id);
        Task<List<Categoria>> ListarCategorias();
        Task<int> ContarCategorias();
        Task<Categoria> Salvar(Categoria obj);
        Task<bool> Delete(int? Id);
    }
}
