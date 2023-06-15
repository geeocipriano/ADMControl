namespace ADMControl.Dominio.Repositorios.RepCategoria
{
	public class CategoriaRepositorio : ICategoriaRepositorio
	{
		private readonly EfDbContext _context;

		public CategoriaRepositorio(EfDbContext context)
		{
			_context = context;
		}
		public async Task<Categoria> BuscarCategoriaPorId(int? Id)
		{
			try
			{
				Categoria? cont = await _context.Categoria.FindAsync(Id);
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

		public async Task<int> ContarCategorias()
		{
			try
			{
				return await _context.Categoria.CountAsync();
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<bool> Delete(int? Id)
		{
			string errorMessage;
			Categoria? _obj = await _context.Categoria.FindAsync(Id);

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

		public async Task<List<Categoria>> ListarCategorias()
		{
			return await _context.Categoria.ToListAsync();
		}

		public async Task<Categoria> Salvar(Categoria obj)
		{
			try
			{
				if (obj.CAT_ID == 0)
				{
					await _context.Categoria.AddAsync(obj);
					_context.Entry(obj).CurrentValues.SetValues(UpperCaseHelper.ObjToUpper(obj, _context));
				}
				else
				{
					Categoria? _obj = await _context.Categoria.FindAsync(obj.CAT_ID);
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
