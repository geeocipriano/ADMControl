namespace ADMControl.Dominio.Repositorios.RepEntrada
{
    public class EntradaRepositorio : IEntradaRepositorio
    {
        private readonly EfDbContext _context;

        public EntradaRepositorio(EfDbContext context)
        {
            _context = context;
        }
        public async Task<Entrada> BuscarEntradaPorId(int? Id)
        {
            try
            {
                Entrada? cont = await _context.Entrada.FindAsync(Id);
                if (cont != null)
                {
                    return cont;
                }
                else
                {
                    throw new Exception("Não foi possível encontrar o contato com o ID fornecido.");
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<ProdutoxEntrada> BuscarProdutoPorId(int? Id)
        {
            try
            {
                ProdutoxEntrada? cont = await _context.ProdutoxEntrada.FindAsync(Id);
                if (cont != null)
                {
                    return cont;
                }
                else
                {
                    throw new Exception("Não foi possível encontrar o contato com o ID fornecido.");
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Delete(int? Id)
        {
            string errorMessage;
            Entrada? _obj = await _context.Entrada.FindAsync(Id);

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

        public async Task<bool> DeleteProduto(int? Id)
        {
            string errorMessage;
            ProdutoxEntrada? _obj = await _context.ProdutoxEntrada.FindAsync(Id);

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

        public async Task<List<Entrada>> ListarEntradas()
        {
            return await _context.Entrada.ToListAsync();
        }

        public async Task<List<ProdutoxEntrada>> ListarProdutosxEntrada(int Id)
        {
            return await _context.ProdutoxEntrada.Where(m => m.PXE_IDENTRADA == Id).ToListAsync();
        }

        public async Task<Entrada> Salvar(Entrada obj)
        {
            try
            {
                if (obj.ENT_ID == 0)
                {
                    await _context.Entrada.AddAsync(obj);
                    _context.Entry(obj).CurrentValues.SetValues(UpperCaseHelper.ObjToUpper(obj, _context));
                }
                else
                {
                    Entrada? _obj = await _context.Entrada.FindAsync(obj.ENT_ID);
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

        public async Task<ProdutoxEntrada> SalvarProduto(ProdutoxEntrada obj)
        {
            try
            {
                if (obj.PXE_ID == 0)
                {
                    await _context.ProdutoxEntrada.AddAsync(obj);
                    _context.Entry(obj).CurrentValues.SetValues(UpperCaseHelper.ObjToUpper(obj, _context));
                }
                else
                {
                    ProdutoxEntrada? _obj = await _context.ProdutoxEntrada.FindAsync(obj.PXE_ID);
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
