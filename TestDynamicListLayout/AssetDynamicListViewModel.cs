using DevExpress.XtraGrid.Columns;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

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

        public IList<AssetInfo> Data { get; set; } = [];

        public new async Task Initialize()
        {

        }

        public async Task<IList<AssetInfo>> GetData()
        {
            Clock.Start();
            //Data = await _Repo.GetAssetsData();

            var content = File.ReadAllText("Assets.json");
            Data = JsonSerializer.Deserialize<List<AssetInfo>>(content);

            Clock.Stop();
            return Data;
        }
    }
}
