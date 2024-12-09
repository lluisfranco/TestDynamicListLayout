using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace TestDynamicListLayout
{
    public partial class DynamicListUserControl : XtraUserControl
    {
        public GridColumnOptions DefaultGridColumnOptions { get; private set; } = new();
        public bool Initialized { get; set; }
        public int? RowId => (GridViewDynamic.GetRow(GridViewDynamic?.FocusedRowHandle ?? 0) as dynamic)?.RowId;

        public event EventHandler GridDoubleClick;
        public event EventHandler GridShowPopupMenu;

        public DynamicListUserControl()
        {
            InitializeComponent();
            DefaultGridColumnOptions.AutoCreateColumnsOnSetData = true;
            GridViewDynamic.DoubleClick += (s, e) =>
            {
                var ea = e as DXMouseEventArgs;
                var view = s as GridView;
                var info = view.CalcHitInfo(ea.Location);
                if (info.InRow || info.InRowCell) GridDoubleClick?.Invoke(s, e);
            };
            GridViewDynamic.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    var ea = e as DXMouseEventArgs;
                    var view = s as GridView;
                    var info = view.CalcHitInfo(ea.Location);
                    if (info.InRow || info.InRowCell) GridShowPopupMenu?.Invoke(s, e);
                }
            };
        }

        public async Task Initialize()
        {
            
            Initialized = true;
        }
    }
}
