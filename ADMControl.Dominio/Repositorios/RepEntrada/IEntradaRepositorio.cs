namespace ADMControl.Dominio.Repositorios.RepEntrada
{
    public interface IEntradaRepositorio
    {
        Task<Entrada> BuscarEntradaPorId(int? Id);
        Task<ProdutoxEntrada> BuscarProdutoPorId(int? Id);
        Task<List<Entrada>> ListarEntradas();
        Task<Entrada> Salvar(Entrada obj);
        Task<ProdutoxEntrada> SalvarProduto(ProdutoxEntrada obj);
        Task<List<ProdutoxEntrada>> ListarProdutosxEntrada(int Id);
        Task<bool> Delete(int? Id);
        Task<bool> DeleteProduto(int? Id);
    }
}
