using Dapper;
using EWS.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;


namespace EWS.API.Repositories
{
	public class T_MsEwsRepository
	{
		private readonly string connectionString1;
		// private readonly string connectionString2;
		// private readonly string connectionString3;
		// private readonly string connectionString4;
		// private readonly string connectionString5;
		// private readonly string connectionString6;
		// private readonly string connectionString7;
		private readonly EWSDbContext _context;

		public T_MsEwsRepository(IOptions<ConnectionStrings> connectionStrings, EWSDbContext context)
		{
			_context = context;
			connectionString1 = connectionStrings.Value.DbConnectionString7;
			// connectionString2 = connectionStrings.Value.DbConnectionString2;
			// connectionString3 = connectionStrings.Value.DbConnectionString3;
			// connectionString4 = connectionStrings.Value.DbConnectionString4;
			// connectionString5 = connectionStrings.Value.DbConnectionString5;
			// connectionString6 = connectionStrings.Value.DbConnectionString6;
			// connectionString7 = connectionStrings.Value.DbConnectionString7;
		}

		public List<T_MsUrutanEws?> GetMsUrutan()
		{
			return _context.T_MsUrutanEws.Distinct().OrderBy(x => x.ranked).ToList();
		}

		public List<T_PercentageAchColorEws?> GetColorAchieveEWS(decimal valueAchieve)
		{
			return _context.T_PercentageAchColorEws.Where(x => x.numberStart <= valueAchieve && x.numberEnd >= valueAchieve).ToList();
		}

		public async Task<IEnumerable<T_MsEwsNew?>> GetContentPdf()
		{

			List<T_MsEwsNew> result = new List<T_MsEwsNew>();
			try
			{
				_context.Database.SetCommandTimeout(300);

				result = await _context.Set<T_MsEwsNew>().FromSqlRaw("EXECUTE dummyEWS").ToListAsync();

				return result;

			}
			catch (Exception ex)
			{
				return result;
			}

		}

		public async Task<IEnumerable<T_MsEwsNew?>> GetContentByCompanyLocationPdf(string company, string location)
		{

			List<T_MsEwsNew> result = new List<T_MsEwsNew>();

			try
			{
				_context.Database.SetCommandTimeout(300);

				result = await _context.Set<T_MsEwsNew>().FromSqlRaw("EXECUTE dummyEWS").ToListAsync();

				return result;

			}
			catch (Exception ex)
			{
				return result;
			}

		}

		public T_MsBusinessUnit GetDescriptionCompanyLocation(string company, string location)
		{
			try
			{
				using (var connection = new SqlConnection(connectionString1))
				{
					var data = connection.Query<T_MsBusinessUnit>("select Company,Location,Description,'PKU' RegionCode from T_MsBusinessUnit where Active = 1 and Company='" + company + "' and Location='" + location +"'");

					if (data.Count() > 0)
					{
						return data.FirstOrDefault();
					}
				}

				return new T_MsBusinessUnit
				{
					Company = company,
					Location = location,
				};
			}
			catch (Exception e)
			{
				Console.WriteLine();
				return new T_MsBusinessUnit
				{
					Company = company,
					Location = location,
				};
			}

		}

	}
}