namespace ADMControl.Dominio.Repositorios.RepProduto
{
    public interface IProdutoRepositorio
    {
        Task<Produto> BuscarProdutoPorId(int? Id);
        Task<List<Produto>> ListarProdutos();
        Task<int> ContarProdutos();
        Task<Produto> Salvar(Produto obj);
        Task<bool> Delete(int? Id);
    }
}
