using DevExpress.Utils;
using DevExpress.Utils.Serializing;
using DevExpress.Utils.Svg;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System.IO;
using System.Text.Json;
using TestDynamicListLayout.Data;

namespace TestDynamicListLayout
{
    public partial class Form1 : RibbonForm
    {
        private GridView View => dynamicListUserControl.GridViewDynamic;
        private GridColumn GetViewColumn(string name) => View.GetColumn(name);

        //BEGIN Form Configuration
        private readonly string _OBJECT_TYPE_NAME = "Asset";
        private readonly string _FORM_CAPTION = "Assets List";
        private readonly SvgImage _FORM_ICON_SVG_IMAGE = SvgHelper.GetImageFromResources("ObjectTypes.AssetTypes");
        private readonly AssetDynamicListViewModel _ViewModel;
        //END Form Configuration

        private byte[] _DefaultLayout = default!;

        public Form1()
        {
            InitializeComponent();
            Text = _FORM_CAPTION;
            IconOptions.SvgImage = _FORM_ICON_SVG_IMAGE;
            _ViewModel = new AssetDynamicListViewModel();
            barButtonItemRefresh.ItemClick += async (s, e) =>
            {
                await RefreshData();
            };
            barButtonItemRestoreDefaultLayout.ItemClick += (s, e) =>
            {
                SetControlLayoutBytes(View, _DefaultLayout);
            };
            barButtonItemSaveToFile.ItemClick += (s, e) =>
            {
                SaveControlLayoutToFile(View);
            };
            barButtonItemLoadFromFile.ItemClick += (s, e) =>
            {
                LoadControlLayoutFromFile(View);
            };
        }

        public async Task RefreshData()
        {
            try
            {
                View.GridControl.BeginUpdate();
                await _ViewModel.GetData("C:\\__\\");
                if (!dynamicListUserControl.Initialized)
                {
                    await dynamicListUserControl.Initialize();
                    View.SetData(_ViewModel.Data, dynamicListUserControl.DefaultGridColumnOptions);
                    CreateDefaultView();
                    View.SetViewDefautOptions();

                    _DefaultLayout = [.. GetControlLayoutBytes(View)];
                }
                else
                {
                    View.SetData(_ViewModel.Data);
                }
                View.GridControl.EndUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CreateDefaultView()
        {
            var isactiveCombo = UIHelper.GetIsActiveComboBox();
            var isactiveManagementCombo = UIHelper.GetIsActiveManagementBooleanComboBox();
            var isManagedCombo = UIHelper.GetAssetManagedBooleanComboBox();            
            GetViewColumn("IsItemActive")?.SetVisible().SetFixedWidth().SetCaption("Is Active").
                SetHeaderImage("Core.IsActiveAll").SetImageCombo(isactiveCombo);
            GetViewColumn("BV_1")?.SetVisible().SetFixedWidth().SetCaption("Is Active Management").
                SetHeaderImage("Core.IsActiveManagementAll").SetImageCombo(isactiveManagementCombo);
            GetViewColumn("Managed")?.SetVisible().SetFixedWidth().SetCaption("Is Managed").
                SetHeaderImage("Assets.IsAssetManagedAll").SetImageCombo(isManagedCombo);
            GetViewColumn("AssetCode")?.SetVisible();
            GetViewColumn("AssetName")?.SetVisible();
            GetViewColumn("AssetCurrencyId")?.SetVisible().SetFixedWidth().SetCaption("Currency").
                SetHeaderImage("ObjectTypes.Currency");
            GetViewColumn("ISIN")?.SetVisible();
            GetViewColumn("Ticker")?.SetVisible().SetCaption("Ext. Code");
            GetViewColumn("LastPrice")?.SetVisible().SetDisplayFormat(FormatType.Numeric, "n4");
            GetViewColumn("LastPriceDate")?.SetVisible();
            GetViewColumn("BV_106")?.SetVisible();
            GetViewColumn("CreationDate").SetDisplayFormat(FormatType.DateTime, "g");
            GetViewColumn("ModifiedDate").SetDisplayFormat(FormatType.DateTime, "g");
            CreatePerformanceColumnsDefaultView();
            View.UseAdvancedCustomizationForm();
            View.BestFitColumns(true);
            View.FocusedRowHandle = 0;
        }

        public void CreatePerformanceColumnsDefaultView()
        {
            CreatePerformanceColumnsDefaultView("YTD");
            CreatePerformanceColumnsDefaultView("D1");
            CreatePerformanceColumnsDefaultView("MTD");
            CreatePerformanceColumnsDefaultView("M12");
            GetViewColumn($"GainsYTD")?.SetVisible();
            GetViewColumn($"PerformanceYTD")?.SetVisible();
        }

        public void CreatePerformanceColumnsDefaultView(string period)
        {
            GetViewColumn($"InitialAmount{period}")?.SetDisplayFormat(FormatType.Numeric, "n2").CreateMintDataBarRule();
            GetViewColumn($"FinalAmount{period}")?.SetDisplayFormat(FormatType.Numeric, "n2").CreateMintDataBarRule();
            GetViewColumn($"Gains{period}")?.SetDisplayFormat(FormatType.Numeric, "n2").CreatePositiveNegativeIconSetRule();
            GetViewColumn($"Performance{period}")?.SetDisplayFormat(FormatType.Numeric, "P2").CreatePositiveNegativeIconSetRule();
            GetViewColumn($"InOut{period}")?.SetDisplayFormat(FormatType.Numeric, "n2").CreateMintDataBarRule();
            GetViewColumn($"InitialDate{period}")?.SetDisplayFormat(FormatType.DateTime, "d");
            GetViewColumn($"FinalDate{period}")?.SetDisplayFormat(FormatType.DateTime, "d");
            GetViewColumn($"NumDays{period}");
            GetViewColumn($"Weighted{period}")?.SetDisplayFormat(FormatType.Numeric, "n2").CreateMintDataBarRule();
        }

        private MemoryStream GetControlLayoutStream<T>(T control) where T : ISupportXtraSerializer
        {
            var stream = new MemoryStream();
            control.SaveLayoutToStream(stream);
            stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }

        private byte[] GetControlLayoutBytes<T>(T control) where T : ISupportXtraSerializer
        {
            return GetControlLayoutStream(control).ToArray();
        }


        private void SetControlLayoutBytes<T>(T control, byte[] userLayoutBytes) where T : ISupportXtraSerializer
        {
            try
            {
                if (userLayoutBytes.Length == 0) return;
                var stream = new MemoryStream(userLayoutBytes);
                control.RestoreLayoutFromStream(stream);
                stream.Seek(0, SeekOrigin.Begin);
            }
            catch
            {

            }
        }

        private void SaveControlLayoutToFile<T>(T control) where T : ISupportXtraSerializer
        {
            var fd = new OpenFileDialog() { Filter = "*.xml|*.xml" };
            if (fd.ShowDialog() == DialogResult.OK)
            {
                var stream = new FileStream(fd.FileName, FileMode.Create);
                control.SaveLayoutToStream(stream);
                stream.Close();
            }
        }

        private void LoadControlLayoutFromFile<T>(T control) where T : ISupportXtraSerializer
        {
            var fd = new OpenFileDialog() { Filter = "*.xml|*.xml" };
            if (fd.ShowDialog() == DialogResult.OK)
            {
                var stream = new FileStream(fd.FileName, FileMode.Open);
                control.RestoreLayoutFromStream(stream);
                stream.Close();
            }
        }
    }

    public static class DbHelper
    {
        public static IEnumerable<AssetInfo> GetAssetDataFromFile()
        {
            var content = File.ReadAllText("Assets.json");
            return JsonSerializer.Deserialize<List<AssetInfo>>(content) ?? [];
        }
    }
}
