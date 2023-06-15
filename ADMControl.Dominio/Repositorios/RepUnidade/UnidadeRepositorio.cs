namespace ADMControl.Dominio.Repositorios.RepUnidade
{
    public class UnidadeRepositorio : IUnidadeRepositorio
    {
        private readonly EfDbContext _context;

        public UnidadeRepositorio(EfDbContext context)
        {
            _context = context;
        }
        public async Task<Unidade> BuscarUnidadePorId(int? Id)
        {
            try
            {
                Unidade? cont = await _context.Unidade.FindAsync(Id);
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

        public async Task<int> ContarUnidades()
        {
            try
            {
                return await _context.Unidade.CountAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Delete(int? Id)
        {
            string errorMessage;
            Unidade? _obj = await _context.Unidade.FindAsync(Id);

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

        public async Task<List<Unidade>> ListarUnidades()
        {
            return await _context.Unidade.ToListAsync();
        }

        public async Task<Unidade> Salvar(Unidade obj)
        {
            try
            {
                if (obj.UNI_ID == 0)
                {
                    await _context.Unidade.AddAsync(obj);
                    _context.Entry(obj).CurrentValues.SetValues(UpperCaseHelper.ObjToUpper(obj, _context));
                }
                else
                {
                    Categoria? _obj = await _context.Categoria.FindAsync(obj.UNI_ID);
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
