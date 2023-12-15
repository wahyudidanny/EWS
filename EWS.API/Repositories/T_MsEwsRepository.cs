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

		public async Task<IEnumerable<T_MsEws?>> GetAll()
		{
			return await _context.T_MsEws.Distinct().ToListAsync().ConfigureAwait(false);
		}
    }
}