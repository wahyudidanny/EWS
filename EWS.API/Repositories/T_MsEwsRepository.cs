using Dapper;
using EWS.API.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EWS.API.Repositories
{
	public class T_MsEwsRepository
	{
		private readonly string? _connectionString;
		private readonly string? _connectionString2;
		private readonly string? _connectionString3;
		private readonly string? _connectionString4;
		private readonly string? _connectionString5;
		private readonly string? _connectionString6;
		private readonly string? _connectionString7;


		private readonly EWSDbContext _dbContextRiau;
		private readonly EWSDbContext _dbContextKalbar;


		public T_MsEwsRepository(IOptions<ConnectionStrings> connectionStrings)
		{

			_connectionString = connectionStrings.Value.DbConnectionString;
			_connectionString2 = connectionStrings.Value.DbConnectionString2;
			_connectionString3 = connectionStrings.Value.DbConnectionString3;
			_connectionString4 = connectionStrings.Value.DbConnectionString4;
			_connectionString5 = connectionStrings.Value.DbConnectionString5;
			_connectionString6 = connectionStrings.Value.DbConnectionString6;
			_connectionString7 = connectionStrings.Value.DbConnectionString7;

			var optionsBuilder = new DbContextOptionsBuilder<EWSDbContext>().UseSqlServer(_connectionString);
        		_dbContextRiau = new EWSDbContext(optionsBuilder.Options);

			var optionsBuilder2 = new DbContextOptionsBuilder<EWSDbContext>().UseSqlServer(_connectionString2);
        		_dbContextRiau = new EWSDbContext(optionsBuilder2.Options);


		}

		public List<T_MsUrutanEws?> GetMsUrutan()
		{
				return _dbContextRiau.T_MsUrutanEws.Distinct().OrderBy(x => x.ranked).ToList();
		}

		// public List<T_PercentageAchColorEws?> GetColorAchieveEWS(decimal valueAchieve)
		// {
		// 	return _context.T_PercentageAchColorEws.Where(x => x.numberStart <= valueAchieve && x.numberEnd >= valueAchieve).ToList();
		// }

		// public async Task<IEnumerable<T_MsRekapKebun>> GetDataRekapLevelKebun()
		// {
		// 	return await _context.T_MsRekapKebun.ToListAsync().ConfigureAwait(false);

		// }

		// public async Task<IEnumerable<T_MsRekapGroup>> GetDataRekapLevelGroup()
		// {

		// 	return await _context.T_MsRekapGroup.ToListAsync().ConfigureAwait(false);
		// }

		// public async Task<IEnumerable<T_MsUrutanHeaderKebunGroup>> GetUrutanHeaderKebunGroup()
		// {
		// 	return await _context.T_MsUrutanHeaderKebunGroup.Where(x => x.asHeader == true).OrderBy(item => item.Id).ToListAsync().ConfigureAwait(false);
		// }


		// public async Task<IEnumerable<T_MsUrutanHeaderKebunGroup>> GetUrutanSubHeaderKebunGroup()
		// {
		// 	return await _context.T_MsUrutanHeaderKebunGroup.Where(x => x.asHeader == false).OrderBy(item => item.Id).ToListAsync().ConfigureAwait(false);
		// }


		// public async Task<IEnumerable<T_MsEwsNew>> GetDataRekapLevelAfdeling()
		// {
		// 	return await _context.T_MsEwsNew.ToListAsync().ConfigureAwait(false);
		// }

		// public async Task GenerateEWSAllRegion()
		// {
		// 	try
		// 	{
		// 		_context.Database.SetCommandTimeout(300);
		// 		await _context.Database.ExecuteSqlRawAsync("EXECUTE dummyEWSAll");
		// 	}
		// 	catch (Exception ex)
		// 	{

		// 	}
		// }
		// public async Task<IEnumerable<T_MsEwsNew?>> GetContentPdf()
		// {

		// 	List<T_MsEwsNew> result = new List<T_MsEwsNew>();
		// 	try
		// 	{
		// 		_context.Database.SetCommandTimeout(300);

		// 		result = await _context.Set<T_MsEwsNew>().FromSqlRaw("EXECUTE dummyEWS").ToListAsync();

		// 		return result;

		// 	}
		// 	catch (Exception ex)
		// 	{
		// 		return result;
		// 	}

		// }


		public string getConnectionString(string regionCode)
		{
			string connectionStrings = string.Empty;

			if (regionCode.ToLower() == "pku")
			{
				connectionStrings = _connectionString7;

			}

			return connectionStrings;

		}



		public async Task<IEnumerable<T_MsEwsNew?>> GetContentByCompanyLocationPdf(string company, string location, string regionCode)
		{

			List<T_MsEwsNew> results = new List<T_MsEwsNew>();
			string connectionStrings = getConnectionString(regionCode);

			using (var connection = new SqlConnection(connectionStrings))
			{

				try
				{
					await connection.OpenAsync();

					using (var command = new SqlCommand("select ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS Ranked,* from EWSDataRekapAfdeling WHERE Company=@Company AND Location=@Location", connection))
					{
						command.Parameters.AddWithValue("@Company", company);
						command.Parameters.AddWithValue("@Location", location);
						command.CommandTimeout = 180;

						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								T_MsEwsNew result = new T_MsEwsNew();

								// Set propertynya masih satu satu, karena kolom di sql server dan di controller berbeda
								result.company = reader["Company"] != DBNull.Value ? (string)reader["Company"] : null;
								result.location = reader["Location"] != DBNull.Value ? (string)reader["Location"] : null;
								result.afdeling = reader["Afdeling"] != DBNull.Value ? (string)reader["Afdeling"] : null;
								result.blokCode = reader["BlokCode"] != DBNull.Value ? (string)reader["BlokCode"] : null;
								result.hectaragePlanted = reader["HectaragePlanted"] != DBNull.Value ? (decimal)reader["HectaragePlanted"] : (decimal?)null;
								result.tonHa = reader["Ton/ha"] != DBNull.Value ? (decimal)reader["Ton/ha"] : (decimal?)null;
								result.roundTonHa = reader["RoundTon/ha"] != DBNull.Value ? (decimal)reader["RoundTon/ha"] : (decimal?)null;
								result.bdgtTonHa = reader["BdgtTon/Ha"] != DBNull.Value ? (decimal)reader["BdgtTon/Ha"] : (decimal?)null;
								result.roundBdgtTonHa = reader["RoundBdgtTon/Ha"] != DBNull.Value ? (decimal)reader["RoundBdgtTon/Ha"] : (decimal?)null;
								result.acHTonHaAktvsBgdt = reader["ACHTon/Ha-AktvsBgdt"] != DBNull.Value ? (decimal)reader["ACHTon/Ha-AktvsBgdt"] : (decimal?)null;
								result.jjgPkk = reader["Jjg/Pkk"] != DBNull.Value ? (decimal)reader["Jjg/Pkk"] : (decimal?)null;
								result.roundJjgPkk = reader["RoundJjg/Pkk"] != DBNull.Value ? (decimal)reader["RoundJjg/Pkk"] : (decimal?)null;
								result.bdgtJjgPkk = reader["BdgtJjg/Pkk"] != DBNull.Value ? (decimal)reader["BdgtJjg/Pkk"] : (decimal?)null;
								result.roundBdgtJjgPkk = reader["RoundBdgtJjg/Pkk"] != DBNull.Value ? (decimal)reader["RoundBdgtJjg/Pkk"] : (decimal?)null;
								result.achJjgAktvsBgdt = reader["ACHJjg-AktvsBgdt"] != DBNull.Value ? (decimal)reader["ACHJjg-AktvsBgdt"] : (decimal?)null;
								result.bjrAkt = reader["BjrAkt"] != DBNull.Value ? (decimal)reader["BjrAkt"] : (decimal?)null;
								result.roundBjrAkt = reader["RoundBjrAkt"] != DBNull.Value ? (decimal)reader["RoundBjrAkt"] : (decimal?)null;
								result.bjrBdgt = reader["BjrBdgt"] != DBNull.Value ? (decimal)reader["BjrBdgt"] : (decimal?)null;
								result.roundBjrBdgt = reader["RoundBjrBdgt"] != DBNull.Value ? (decimal)reader["RoundBjrBdgt"] : (decimal?)null;
								result.achBjrAktvsBgdt = reader["ACHBjr-AktvsBgdt"] != DBNull.Value ? (decimal)reader["ACHBjr-AktvsBgdt"] : (decimal?)null;
								result.aktRotPnn = reader["AktRotPnn"] != DBNull.Value ? (decimal)reader["AktRotPnn"] : (decimal?)null;
								result.roundAktRotPnn = reader["RoundAktRotPnn"] != DBNull.Value ? (decimal)reader["RoundAktRotPnn"] : (decimal?)null;
								result.bdgtRotasi = reader["BdgtRotasi"] != DBNull.Value ? (decimal)reader["BdgtRotasi"] : (decimal?)null;
								result.achRotasiAktvsBgdt = reader["ACHRotasi-AktvsBgdt"] != DBNull.Value ? (decimal)reader["ACHRotasi-AktvsBgdt"] : (decimal?)null;
								result.totAnotganikAkt = reader["TotAnotganikAkt"] != DBNull.Value ? (decimal)reader["TotAnotganikAkt"] : (decimal?)null;
								result.totAnotganikBdgt = reader["TotAnotganikBdgt"] != DBNull.Value ? (decimal)reader["TotAnotganikBdgt"] : (decimal?)null;
								result.achAnorganikAktvsBgdt = reader["ACHAnorganik-AktvsBgdt"] != DBNull.Value ? (decimal)reader["ACHAnorganik-AktvsBgdt"] : (decimal?)null;
								result.totpiringanAkt = reader["TotpiringanAkt"] != DBNull.Value ? (decimal)reader["TotpiringanAkt"] : (decimal?)null;
								result.totpiringanBdgt = reader["TotpiringanBdgt"] != DBNull.Value ? (decimal)reader["TotpiringanBdgt"] : (decimal?)null;
								result.achPiringanAktvsBgdt = reader["ACHPiringan-AktvsBgdt"] != DBNull.Value ? (decimal)reader["ACHPiringan-AktvsBgdt"] : (decimal?)null;
								result.totgawanganAkt = reader["TotgawanganAkt"] != DBNull.Value ? (decimal)reader["TotgawanganAkt"] : (decimal?)null;
								result.totgawanganBdgt = reader["TotgawanganBdgt"] != DBNull.Value ? (decimal)reader["TotgawanganBdgt"] : (decimal?)null;
								result.achGawanganAktvsBgdt = reader["ACHGawangan-AktvsBgdt"] != DBNull.Value ? (decimal)reader["ACHGawangan-AktvsBgdt"] : (decimal?)null;
								result.tottunasAkt = reader["TottunasAkt"] != DBNull.Value ? (decimal)reader["TottunasAkt"] : (decimal?)null;
								result.tottunasBdgt = reader["TottunasBdgt"] != DBNull.Value ? (decimal)reader["TottunasBdgt"] : (decimal?)null;
								result.achTunasAktvsBgdt = reader["ACHTUnas-AktvsBgdt"] != DBNull.Value ? (decimal)reader["ACHTUnas-AktvsBgdt"] : (decimal?)null;

								results.Add(result);
							}

						}

						connection.Close();

					}

				}
				catch (Exception ex)
				{

					if (connection.State != ConnectionState.Closed)
						connection.Close();

					results.Clear();

					return results;
				}


			}
			return results;
		}

		// public async Task<IEnumerable<T_MsEwsNew?>> GetContentByRekapKebun(string company, string location)
		// {

		// 	List<T_MsEwsNew> result = new List<T_MsEwsNew>();

		// 	try
		// 	{
		// 		_context.Database.SetCommandTimeout(300);

		// 		result = await _context.Set<T_MsEwsNew>().FromSqlRaw("EXECUTE dummyEWS").ToListAsync();

		// 		return result;

		// 	}
		// 	catch (Exception ex)
		// 	{
		// 		return result;
		// 	}

		// }


		public async Task<string> getDescriptionBusinessUnit(string company, string location, string regionCode)
		{

			string result = "";
			string connectionStrings = getConnectionString(regionCode);

			using (var connection = new SqlConnection(connectionStrings))
			{
				try
				{
					await connection.OpenAsync();

					using (var command = new SqlCommand("select Description from T_MsBusinessUnit where Active = 1 and Company=@Company AND Location = @Location", connection))
					{
						command.Parameters.AddWithValue("@Company", company);
						command.Parameters.AddWithValue("@Location", location);
						command.CommandTimeout = 180;

						var scalarResult = command.ExecuteScalar();
						if (scalarResult != null)
							result = scalarResult.ToString();
						else
							result = "undefined";

					}

					connection.Close();
					
				}
				catch (Exception e)
				{
					if (connection.State != ConnectionState.Closed)
						connection.Close();

					result = "";

					return result;

				}

			}

			return result;

		}

	}
}