using Dapper;
using System.Data.SqlClient;

namespace TestDynamicListLayout.Data
{
    public class DynamicRepository
    {
        public string ConnectionString { get; set; } = string.Empty;

        public async Task<IList<dynamic>> GetAssetsData()
        {
            var con = new SqlConnection(ConnectionString);
            con.Open();
            using (con)
            {
                var sql = @"SELECT TOP 2000 * FROM AssetData";
                var command = new CommandDefinition(sql);
                var data = con.Query<dynamic>(command);
                return data.ToList();
            }
        }
    }
}
