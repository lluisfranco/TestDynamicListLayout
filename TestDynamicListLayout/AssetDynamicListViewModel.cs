using DevExpress.XtraGrid.Columns;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using TestDynamicListLayout.Data;

namespace TestDynamicListLayout
{
    public class AssetDynamicListViewModel
    {
        public bool Initialized { get; private set; }
        public bool Loading { get; set; }
        public Stopwatch Clock { get; private set; } = Stopwatch.StartNew();
        public IList<GridColumn> DefaultSummaryColumnsList { get; set; } = [];
        public IList<GridColumn> SummaryColumnsList { get; set; } = [];
        public IList<GridColumn> ToolTipInfoColumnsList { get; set; } = [];
        public IList<GridColumn> ToolTipNumericDetailColumnsList { get; set; } = [];

        public IList<dynamic> Data { get; set; } = [];

        public new async Task Initialize()
        {

        }

        public async Task<IList<object>> GetData(string dbpath)
        {
            //var dbpath = Path.Combine(Environment.CurrentDirectory, "Database1.mdf");
            //var dbpath = "C:\\__\\Database1.mdf";
            var dbfullpath = Path.Combine(dbpath, "Database1.mdf");
            if (!File.Exists(dbfullpath))
                throw new FileNotFoundException("Database file not found", dbfullpath);
            var _Repo = new DynamicRepository();
            _Repo.ConnectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={dbfullpath};Integrated Security=True";
            Data = await _Repo.GetAssetsData();
            return Data;
        }

        private dynamic GetDynamic(JsonElement element)
        {

            return null;
        }
    }
}
