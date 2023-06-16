namespace ADMControl.Dominio.Repositorios.RepProduto
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly EfDbContext _context;

        public ProdutoRepositorio(EfDbContext context)
        {
            _context = context;
        }

        public async Task<Produto> BuscarProdutoPorId(int? Id)
        {
            try
            {
                Produto? cont = await _context.Produto.FindAsync(Id);
                if (cont != null)
                {
                    return cont;
                }
                else
                {
                    throw new Exception("Não foi possível encontrar o Produto com o ID fornecido.");
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> ContarProdutos()
        {
            try
            {
                return await _context.Produto.CountAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Delete(int? Id)
        {
            string errorMessage;
            Produto? _obj = await _context.Produto.FindAsync(Id);

            if (_obj != null)
            {
                _context.Remove(_obj);

                try
                {
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (DbUpdateException ex)
                {
                    errorMessage = ex.Message;
                    return false;
                }
            }

            errorMessage = "Objeto não encontrado!";
            return false;
        }

        public async Task<List<Produto>> ListarProdutos()
        {
            //return await _context.Produto.ToListAsync();
            return await _context.Produto
                    .Include(p => p.Categoria)
                    .Include(p => p.Unidade)
                    .ToListAsync();
        }

        public async Task<Produto> Salvar(Produto obj)
        {
            try
            {
                if (obj.PRO_ID == 0)
                {
                    await _context.Produto.AddAsync(obj);
                    _context.Entry(obj).CurrentValues.SetValues(UpperCaseHelper.ObjToUpper(obj, _context));
                }
                else
                {
                    Produto? _obj = await _context.Produto.FindAsync(obj.PRO_ID);
                    if (_obj != null)
                        _context.Entry(_obj).CurrentValues.SetValues(UpperCaseHelper.ObjToUpper(obj, _context));
                    else
                        throw new Exception("Não foi possível salvar o Produto.");

                }

                await _context.SaveChangesAsync();

                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
