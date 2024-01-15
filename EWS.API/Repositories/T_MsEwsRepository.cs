using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EWS.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace EWS.API.Repositories
{
	public class T_MsEwsRepository
	{
		private readonly EWSDbContext _context;
		public T_MsEwsRepository(EWSDbContext context)
		{
			_context = context;
		}

		// public async Task<IEnumerable<T_MsEws?>> GetContentPdf()
		// {
		// 	return await _context.T_MsEws.Distinct().ToListAsync().ConfigureAwait(false);
		// }


		// public async Task<IEnumerable<T_MsEwsNew?>> GetContentPdf()
		// {
		// 	await _context.Database.ExecuteSqlRawAsync("EXECUTE dummyEWS");
		// }

		public async Task<IEnumerable<T_MsEwsNew?>> GetContentPdf()
		{

			List<T_MsEwsNew> result = new List<T_MsEwsNew>();
			try
			{
				_context.Database.SetCommandTimeout(300);

				result = await _context.Set<T_MsEwsNew>()
					.FromSqlRaw("EXECUTE dummyEWS")
					.ToListAsync();

				return result;

			}
			catch (Exception ex)
			{
				return result;
				// Log or print the exception message
				Console.WriteLine(ex.Message);
				// Handle the exception as needed
			}

		}

	}
}