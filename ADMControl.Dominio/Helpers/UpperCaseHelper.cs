

namespace ADMControl.Dominio.Helpers
{
	public static class UpperCaseHelper
	{
		public static TResult ObjToUpper<TResult>(TResult obj, EfDbContext _context, string PropExcl = null)
		{
			TResult retorno = obj;

			foreach (PropertyInfo prop in obj.GetType().GetProperties())
			{
				//CONSIDERAR STRING E DESCONSIDERAR NOTMAPPED
				if (prop.PropertyType == typeof(string) && (prop.GetCustomAttributes(typeof(NotMappedAttribute), true).Count() == 0))

					if (_context.Entry(retorno).Property(prop.Name).CurrentValue != null)
						_context.Entry(retorno).Property(prop.Name).CurrentValue = (prop.Name.CompareTo(PropExcl) == 0)
							? _context.Entry(obj).Property(prop.Name).CurrentValue.ToString()
							: _context.Entry(obj).Property(prop.Name).CurrentValue.ToString();
			}

			return retorno;
		}
	}
}
