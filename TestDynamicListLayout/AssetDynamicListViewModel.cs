using DevExpress.XtraGrid.Columns;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using TestDynamicListLayout.Data;

namespace TestDynamicListLayout
{
    public class AssetDynamicListViewModel
    {
        public IList<dynamic> Data { get; set; } = [];

        public async Task<IList<dynamic>> GetData(string dbpath)
        {
            //var dbpath = Path.Combine(Environment.CurrentDirectory, "Database1.mdf");
            //var dbpath = "C:\\__\\Database1.mdf";
            var dbfullpath = Path.Combine(dbpath, "Database1.mdf");
            if (!File.Exists(dbfullpath))
                throw new FileNotFoundException("Database file not found", dbfullpath);
            DynamicRepository _Repo = new()
            {
                ConnectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={dbfullpath};Integrated Security=True"
            };
            Data = await _Repo.GetAssetsData();
            return Data;
        }
    }
}
