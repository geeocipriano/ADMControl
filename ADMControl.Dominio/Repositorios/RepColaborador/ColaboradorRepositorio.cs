namespace ADMControl.Dominio.Repositorios.RepColaborador
{
    public class ColaboradorRepositorio : IColaboradorRepositorio
    {
        private readonly EfDbContext _context;

        public ColaboradorRepositorio(EfDbContext context)
        {
            _context = context;
        }
        public async Task<Colaborador> BuscarColaboradorPorId(int? Id)
        {
            try
            {
                Colaborador? cont = await _context.Colaborador.FindAsync(Id);
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

        public async Task<int> ContarColaboradores()
        {
            try
            {
                return await _context.Colaborador.CountAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Delete(int? Id)
        {
            string errorMessage;
            Colaborador? _obj = await _context.Colaborador.FindAsync(Id);

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

        public async Task<List<Colaborador>> ListarColaboradores()
        {
            return await _context.Colaborador.ToListAsync();
        }

        public async Task<Colaborador> Salvar(Colaborador obj)
        {
            try
            {
                if (obj.COL_ID == 0)
                {
                    await _context.Colaborador.AddAsync(obj);
                    _context.Entry(obj).CurrentValues.SetValues(UpperCaseHelper.ObjToUpper(obj, _context));
                }
                else
                {
                    Colaborador? _obj = await _context.Colaborador.FindAsync(obj.COL_ID);
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
