using EWS.Services.Interface;
using EWS.Services.Models;
using Microsoft.Extensions.Options;
using Microsoft.Data.SqlClient;
using Dapper;

namespace EWS.Services.Services
{
    public class DataServices : IDataService
    {
        private readonly string? connectionString1;
        private readonly string? connectionString2;
        private readonly string? connectionString3;
        private readonly string? connectionString4;
        private readonly string? connectionString5;
        private readonly string? connectionString6;
        private readonly string? connectionString7;
        public DataServices(IOptions<ConnectionStrings> connectionStrings)
        {
            connectionString1 = connectionStrings.Value.DbConnectionString;
            connectionString2 = connectionStrings.Value.DbConnectionString2;
            connectionString3 = connectionStrings.Value.DbConnectionString3;
            connectionString4 = connectionStrings.Value.DbConnectionString4;
            connectionString5 = connectionStrings.Value.DbConnectionString5;
            connectionString6 = connectionStrings.Value.DbConnectionString6;
            connectionString7 = connectionStrings.Value.DbConnectionString7;
        }

        public IEnumerable<T_MsBusinessUnit> GetDataBusinessUnit()
        {
            List<T_MsBusinessUnit> result = new List<T_MsBusinessUnit>();

            using (var connection = new SqlConnection(connectionString7))
            {
                string query = @"
                    select Company,Location,Description, RegionCode, case when KodeGroup = 'FRG' then 'FR' else KodeGroup end KodeGroup  from T_MsBusinessUnit where Active = 1 and Location like '2%' 
                    and Company+Location not in ('A1022','A1121','A1422','A1423','A2521','0122')";

                var data = connection.Query<T_MsBusinessUnit>(query);

                if (data.Count() > 0)
                {
                    result.AddRange(data);
                }
            }
            return result;

        }



    }

}