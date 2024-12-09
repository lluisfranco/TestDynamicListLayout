using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Controls;
using DevExpress.Utils.Menu;
using DevExpress.Utils.Svg;
using DevExpress.XtraCharts.Native;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGauges.Core.Resources;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.Design;
using static DevExpress.Utils.Design.DXCollectionEditorBase;

namespace TestDynamicListLayout
{
    public static partial class GridHelper
    {
        const string BUTTON_PRINT_GRID = "Print preview";
        const string BUTTON_EXPORT_PDF_GRID = "Export to PDF";
        const string BUTTON_EXPORT_XLS_GRID = "Export to XLS";

        public static void SelectRowIdInList(this GridView view, int? newid)
        {
            if (!newid.HasValue) return;
            view.FocusedRowHandle = view.LocateByValue("RowId", newid);
        }

        public static GridView SetViewDefautOptions(this GridView view)
        {
            //var addCustomPrintExportButtonsDefault = settings?.ShowNavigatorOnLists ?? true;
            //var enableAppearanceHotTrackedRowDefault = settings?.EnableAppearanceHotTrackedRow ?? true;
            //var gridViewFilterBehaviorDefault = settings?.DefaultGridViewFilterBehavior ?? FindPanelBehavior.Filter;
            //var autoExpandGroupsOnRestoreLayoutGridViewsDefault = settings?.AutoExpandGroupsOnRestoreLayoutGridViews ?? true;
            //var showConditionalFormattingMenuDefault = settings?.ShowConditionalFormattingMenu ?? true;
            //var groupDrawModeDefault = settings?.GroupDrawMode ?? GroupDrawMode.Default;

            //view.AddCustomPrintAndExportButtonsToGrid();
            //view.OptionsView.FilterCriteriaDisplayStyle = FilterCriteriaDisplayStyle.Visual;
            //view.OptionsSelection.EnableAppearanceHotTrackedRow =
            //    enableAppearanceHotTrackedRowDefault ? DefaultBoolean.True : DefaultBoolean.False;
            //view.OptionsFind.Behavior = gridViewFilterBehaviorDefault;
            //view.OptionsBehavior.AutoExpandAllGroups = autoExpandGroupsOnRestoreLayoutGridViewsDefault;
            //view.OptionsMenu.ShowConditionalFormattingItem = showConditionalFormattingMenuDefault;
            //view.OptionsView.GroupDrawMode = groupDrawModeDefault;

            view.OptionsView.ShowGroupPanel = false;
            view.OptionsMenu.ShowFooterItem = true;
            view.OptionsMenu.ShowSplitItem = true;
            view.OptionsMenu.ShowConditionalFormattingItem = true;
            view.OptionsMenu.EnableGroupRowMenu = true;
            view.OptionsMenu.ShowGroupSummaryEditorItem = true;
            view.OptionsLayout.StoreAppearance = true;
            view.OptionsLayout.StoreFormatRules = true;
            view.OptionsLayout.Columns.StoreAllOptions = true;
            view.OptionsLayout.Columns.StoreAppearance = true;
            view.Layout += (s, e) => ChangeGridColumnsImageAlign(view);
            view.ColumnPositionChanged += (s, e) => ChangeGridColumnsImageAlign(view);
            return view;
        }

        private static void ChangeGridColumnsImageAlign(GridView view)
        {
            foreach (GridColumn col in view.Columns)
            {
                col.ImageOptions.Alignment = col.Visible && col.OptionsColumn.FixedWidth ?
                    StringAlignment.Center : StringAlignment.Near;
            }
        }

        public static object GetCellValue(this GridView view) =>
            view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn);

        public static GridColumn GetColumn(this GridView view, string fieldname) => view.Columns[fieldname];
        public static IList<GridColumn> GetBehaviorColumns(this GridView view) =>
            view.Columns.Where(p => p.IsBehavior() && p.FieldName != $"{Const.COLUMN_BEHAVIOR_PREFIX}ItemId").ToList();
        public static IList<GridColumn> GetRoleColumns(this GridView view) =>
            (IList<GridColumn>)view.Columns.Where(p => p.IsRole());

        public static bool IsBehavior(this GridColumn col) =>
            col.FieldName.StartsWithInvariantCultureIgnoreCase(Const.COLUMN_BEHAVIOR_PREFIX);
        public static bool IsRole(this GridColumn col) =>
            col.FieldName.StartsWithInvariantCultureIgnoreCase(Const.COLUMN_ROLE_PREFIX);

        public static GridView ShowFooter(this GridView view, bool value = true)
        {
            view.OptionsView.ShowFooter = value;
            return view;
        }

        public static GridColumn SetHeaderImage(this GridColumn col, string imagepath,
            StringAlignment alignment = StringAlignment.Center)
        {
            if (col == null) return col;
            var img = SvgHelper.GetImageFromResources(imagepath);
            if (img == null) return col;
            SetHeaderImage(col, img, alignment);
            return col;
        }

        public static GridColumn SetHeaderImage(this GridColumn col, SvgImage img,
            StringAlignment alignment = StringAlignment.Center)
        {
            if (col == null) return col;
            if (img == null) return col;
            col.ImageOptions.Alignment = alignment;
            col.ImageOptions.SvgImage = img;
            col.ImageOptions.SvgImageSize = new Size(16, 16);
            if (alignment == StringAlignment.Center) col.ToolTip = col.Caption;
            return col;
        }

        public static GridColumn SetCaption(this GridColumn col, string caption)
        {
            if (col == null) return col;
            col.Caption = caption;
            return col;
        }

        public static GridColumn SetTooltip(this GridColumn col, string tooltip)
        {
            if (col == null) return col;
            col.ToolTip = tooltip;
            return col;
        }

        public static GridColumn SetBoolImageCombo(this GridColumn col)
        {
            var combo = UIHelper.GetBooleanRealComboBox();
            if (col == null) return col;
            col.ColumnEdit = combo;
            combo.GlyphAlignment = HorzAlignment.Center;
            return col;
        }

        public static GridColumn SetImageCombo(this GridColumn col,
            RepositoryItemImageComboBox combo, HorzAlignment alignment = HorzAlignment.Center)
        {
            if (col == null) return col;
            col.ColumnEdit = combo;
            combo.GlyphAlignment = alignment;
            return col;
        }

        public static GridColumn SetWidth(this GridColumn col, int width)
        {
            if (col == null) return col;
            col.Width = width;
            return col;
        }

        public static GridColumn SetFixedWidth(this GridColumn col, int width = 65)
        {
            if (col == null) return col;
            col.OptionsColumn.FixedWidth = true;
            col.OptionsColumn.AllowSize = false;
            col.Width = width;
            return col;
        }

        public static GridColumn SetPosition(this GridColumn col, int pos)
        {
            if (col == null) return col;
            col.VisibleIndex = pos;
            return col;
        }

        public static GridColumn SetVisible(this GridColumn col, bool value = true)
        {
            if (col == null) return col;
            col.Visible = value;
            if (col.VisibleIndex == 0) col.VisibleIndex = col.View.VisibleColumns.Count;
            return col;
        }

        public static GridColumn ShowInCustomizationForm(this GridColumn col, bool value = true)
        {
            if (col == null) return col;
            col.OptionsColumn.ShowInCustomizationForm = value;
            return col;
        }

        public static GridColumn SetEditable(this GridColumn col, bool value = true,
            GridColumnOptions options = null)
        {
            var defaultColor = DXSkinColors.ForeColors.Question;
            options = options ?? new GridColumnOptions();
            if (col == null) return col;
            col.OptionsColumn.AllowEdit = value;
            col.AppearanceHeader.BackColor = value ? options.ColumnHighlightColor : default;
            return col;
        }

        public static GridColumn SetDisplayFormat(this GridColumn col, FormatType type, string format)
        {
            if (col == null) return col;
            col.DisplayFormat.FormatType = type;
            col.DisplayFormat.FormatString = format;
            return col;
        }

        public static GridView CreateColumns(this GridView view, IList<AssetInfo> data,
            GridColumnOptions options = null)
        {
            options = options ?? new GridColumnOptions();
            view.Columns.Clear();
            if (data.Count == 0) return null;
            var row = data.First() as IDictionary<string, object>;

            var props = data.First().GetType().GetProperties().Select(p => p.Name); 

            foreach (var key in props)
            {
                var col = new GridColumn
                {
                    FieldName = key,
                    Visible = false
                };
                col.SetEditable(false);
                view.Columns.Add(col);
                if (col.IsBehavior())
                {
                    if (options.OptionsBehaviors.BehaviorsList != null)
                    {
                        var behavior = col.GetBehavior(options);
                        if (behavior != null)
                        {
                            if (options.OptionsBehaviors.BehaviorColumnHighlightMode ==
                                BehaviorColumnHighlightEnum.Image)
                            {
                                var imagename = behavior.BehaviorId < 1000000 ?
                                    options.OptionsBehaviors.BehaviorColumnSystemResourceImageName :
                                    options.OptionsBehaviors.BehaviorColumnCustomResourceImageName;
                                col.SetHeaderImage(imagename, StringAlignment.Near);
                            }
                            var caption = behavior?.BehaviorName ?? col.FieldName;
                            col.SetCaption(caption);
                            if (options.OptionsBehaviors.ShowBehaviorDisplayFormat &&
                                behavior.DisplayFormat != null)
                                col.SetDisplayFormat(FormatType.Custom, behavior.DisplayFormat);
                            if (options.OptionsBehaviors.ShowBehaviorDescriptionOnTooltip &&
                                behavior.BehaviorDescription != null)
                                col.SetTooltip(behavior.BehaviorDescription);
                        }
                    }
                }
            }
            return view;
        }

        private static ColumnBehaviorInfo GetBehavior(this GridColumn col, GridColumnOptions options)
        {
            var sid = col.FieldName.Replace(Const.COLUMN_BEHAVIOR_PREFIX, string.Empty);
            int.TryParse(sid, out int id);
            var behavior = options.OptionsBehaviors.BehaviorsList.FirstOrDefault(
                p => p.BehaviorId == id);
            return behavior;
        }

        public static GridView SetData(this GridView view, IList<AssetInfo> data, GridColumnOptions options = null)
        {
            if (options == null) options = new GridColumnOptions() { AutoCreateColumnsOnSetData = false };
            if (options.AutoCreateColumnsOnSetData) view.CreateColumns(data, options);
            var t = view.TopRowIndex;
            var i = view.FocusedRowHandle;
            view.OptionsBehavior.AutoPopulateColumns = false;
            view.GridControl.DataSource = data;
            view.FocusedRowHandle = i;
            view.TopRowIndex = t;
            return view;
        }

        public static GridView UseAdvancedCustomizationForm(this GridView view)
        {
            view.OptionsCustomization.UseAdvancedCustomizationForm = DefaultBoolean.True;
            view.OptionsCustomization.CustomizationFormSearchBoxVisible = true;
            view.OptionsCustomization.AdvancedCustomizationFormSortMode = CustomizationFormSortMode.Default;
            view.OptionsCustomization.CustomizationFormSnapMode = SnapMode.All;
            view.CustomizationFormBounds = new Rectangle(0, 0, 600, 400);
            return view;
        }

        public static GridView AddCustomPrintAndExportButtonsToGrid(this GridView view)
        {
            var grid = view.GridControl;
            if (grid == null) return view;
            grid.UseEmbeddedNavigator = true;
            var navigator = grid.EmbeddedNavigator;
            if (navigator == null) return view;
            navigator.Buttons.CustomButtons.Clear();
            navigator.Buttons.ImageList = GetNavigatorImageList();
            navigator.TextStringFormat = "{0} / {1}";
            navigator.Buttons.Append.Visible = false;
            navigator.Buttons.CancelEdit.Visible = false;
            navigator.Buttons.Remove.Visible = false;
            navigator.Buttons.Edit.Visible = false;
            navigator.Buttons.EndEdit.Visible = false;
            var printGridButton = navigator.Buttons.CustomButtons.Add();
            printGridButton.Hint = BUTTON_PRINT_GRID;
            printGridButton.ImageIndex = 0;
            var exportPDFGridButton = navigator.Buttons.CustomButtons.Add();
            exportPDFGridButton.Hint = BUTTON_EXPORT_PDF_GRID;
            exportPDFGridButton.ImageIndex = 1;
            var exportXLSGridButton = navigator.Buttons.CustomButtons.Add();
            exportXLSGridButton.Hint = BUTTON_EXPORT_XLS_GRID;
            exportXLSGridButton.ImageIndex = 2;
            navigator.ButtonClick += (s, e) =>
            {
                if (e.Button.Hint == BUTTON_PRINT_GRID)
                    grid.ShowPreviewForm();
                if (e.Button.Hint == BUTTON_EXPORT_PDF_GRID)
                    grid.ExportToDisk(ExportGridControlFormatEnum.pdf, true);
                if (e.Button.Hint == BUTTON_EXPORT_XLS_GRID)
                    grid.ExportToDisk(ExportGridControlFormatEnum.xlsx, true);
            };
            return view;
        }

        public static GridView AddExportOptionsToColumnHeaderPopup(this GridView view)
        {
            view.PopupMenuShowing += (s, e) =>
            {
                if (e.MenuType == GridMenuType.Column)
                {
                    var grid = view.GridControl;
                    var itemPrintPreview = new DXMenuItem("Print Preview",
                        new EventHandler(delegate (object o, EventArgs a)
                        {
                            view.GridControl.ShowRibbonPrintPreview();
                        }))
                    {
                        BeginGroup = true
                    };
                    itemPrintPreview.ImageOptions.SvgImage =
                        SvgHelper.GetImageFromResources("Core.Print");
                    e.Menu.Items.Add(itemPrintPreview);
                    var itemExportToPdf = new DXMenuItem("Export to PDF",
                        new EventHandler(delegate (object o, EventArgs a)
                        {
                            view.GridControl.ExportToDisk(ExportGridControlFormatEnum.pdf);
                        }));
                    itemExportToPdf.ImageOptions.SvgImage =
                        SvgHelper.GetImageFromResources("Core.ExportToPDF");
                    e.Menu.Items.Add(itemExportToPdf);
                    var itemExportToXlsx = new DXMenuItem("Export to XLSX",
                        new EventHandler(delegate (object o, EventArgs a)
                        {
                            view.GridControl.ExportToDisk(ExportGridControlFormatEnum.xlsx);
                        }));
                    itemExportToXlsx.ImageOptions.SvgImage =
                        SvgHelper.GetImageFromResources("Core.ExportToXLSX");
                    e.Menu.Items.Add(itemExportToXlsx);
                    var showHideNavigator = new DXMenuItem(
                        view.GridControl.UseEmbeddedNavigator ? "Hide Navigator" : "Show Navigator",
                        new EventHandler(delegate (object o, EventArgs a)
                        {
                            view.GridControl.UseEmbeddedNavigator = !view.GridControl.UseEmbeddedNavigator;
                        }));
                    showHideNavigator.ImageOptions.SvgImage =
                        SvgHelper.GetImageFromResources("Lists.GridViewNavigator");
                    e.Menu.Items.Add(showHideNavigator);
                    //var splitter = view.GridControl.GetGridSplitter();
                    //if (splitter != null)
                    //{

                    //}
                }
            };
            return view;
        }

        private static SvgImageCollection GetNavigatorImageList()
        {
            var img = new SvgImageCollection()
            {
                SvgHelper.GetImageFromResources("Core.Print"),
                SvgHelper.GetImageFromResources("Core.ExportToPDF"),
                SvgHelper.GetImageFromResources("Core.ExportToXLSX"),
            };
            img.ImageSize = new Size(10, 10);
            return img;
        }

        public static void ShowPreviewForm(this GridControl grid)
        {
            grid.ShowRibbonPrintPreview();
        }

        public static void ExportToDisk(this GridControl control,
            ExportGridControlFormatEnum format, bool showMessageOnError = false)
        {
            try
            {
                var file = System.IO.Path.GetTempFileName().Replace("tmp", format.ToString());
                switch (format)
                {
                    case ExportGridControlFormatEnum.xlsx:
                        control.ExportToXlsx(file);
                        break;
                    case ExportGridControlFormatEnum.pdf:
                        control.ExportToPdf(file);
                        break;
                    default:
                        break;
                }
                ProcessExtensions.Open(file);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void ShowToolTipTextInfoForColumns(
            GridControl gridcontrol,
            ToolTipControllerGetActiveObjectInfoEventArgs e,
            GridColumn[] columns)
        {
            if (gridcontrol == null) return;
            if (e.SelectedControl.Name == gridcontrol.Name)
            {
                if (e.Info == null)
                {
                    var gridview = gridcontrol.FocusedView as GridView;
                    var ghinfo = gridview.CalcHitInfo(e.ControlMousePosition);
                    if (ghinfo.InRowCell)
                    {
                        var cellKey = string.Format("{0} - {1}", ghinfo.RowHandle, ghinfo.Column);
                        if (columns.Contains(ghinfo.Column))
                        {
                            var info = new ToolTipControlInfo(cellKey, string.Empty);
                            var txt = gridview.GetRowCellDisplayText(ghinfo.RowHandle, ghinfo.Column);
                            info.Text = txt;
                            e.Info = info;
                        }
                    }
                }
            }
        }

        public static void ShowTooltipNumericInfoForColumns(
            GridControl grid,
            ToolTipControllerGetActiveObjectInfoEventArgs e,
            GridColumn[] columns)
        {
            if (grid == null) return;
            var view = grid.FocusedView as GridView;
            var ghinfo = view.CalcHitInfo(e.ControlMousePosition);
            if (ghinfo.InRowCell)
            {
                string cellKey = String.Format("{0} - {1}", ghinfo.RowHandle, ghinfo.Column);
                if (columns.Any(p => p.Name == ghinfo.Column.Name))
                {
                    var displaytxt = view.GetRowCellDisplayText(ghinfo.RowHandle, ghinfo.Column);
                    if (string.IsNullOrWhiteSpace(displaytxt)) return;
                    var value = Convert.ToDecimal(view.GetRowCellValue(ghinfo.RowHandle, ghinfo.Column));
                    var info = new ToolTipControlInfo(cellKey, value.ToString())
                    {
                        SuperTip = CreateNumberValueSuperTip(value, ghinfo.Column.DisplayFormat.FormatString)
                    };
                    e.Info = info;
                }
            }
        }

        private static SuperToolTip CreateNumberValueSuperTip(decimal value, string formatString)
        {
            var v1 = value;
            var v2 = value;
            for (int i = 0; i < 12; i++)
            {
                if (formatString.ToUpper().Contains("{0:N" + i.ToString() + "}")) formatString = "n" + i.ToString();
            }
            if (formatString.ToUpper().Contains("P"))
            {
                formatString = formatString.ToUpper().Replace("P", "n");
                value *= 100;
            }
            var st = new SuperToolTip() { AllowHtmlText = DefaultBoolean.True };
            st.Items.Add(new ToolTipTitleItem() { Text = "Inspect Value" });
            st.Items.Add(new ToolTipItem() { Text = "Showing" });
            st.Items.Add(new ToolTipItem() { Text = value.ToString(formatString) });
            st.Items.Add(new ToolTipSeparatorItem());
            st.Items.Add(new ToolTipItem() { Text = "Real" });
            st.Items.Add(new ToolTipItem() { Text = value.ToString("n10") });
            try
            {
                v1 = Convert.ToDecimal((value).ToString(formatString));
                v2 = Convert.ToDecimal(value.ToString("n10"));
            }
            catch (Exception)
            {

            }
            var dif = Convert.ToDecimal(v1 - v2);
            if (dif != 0)
            {
                st.Items.Add(new ToolTipSeparatorItem());
                st.Items.Add(new ToolTipItem() { Text = "<color=@critical>Difference</color>" });
                st.Items.Add(new ToolTipItem() { Text = $"<color=@critical>{dif.ToString("n10")}</color>" });
            }
            return st;
        }

        public static void AddFormatRule(this ColumnView view, GridFormatRule rule)
        {
            if (view.FormatRules.Any(p => p.Name == rule.Name))
            {
                for (int i = view.FormatRules.Count - 1; i >= 0; i--)
                {
                    if (view.FormatRules[i].Name == rule.Name)
                    {
                        view.FormatRules.RemoveAt(i);
                    }
                }
            }
            view.FormatRules.Add(rule);
        }

        public static GridFormatRule CreatePositiveNegativeIconSetRule(this GridColumn column, bool addToView = true)
        {
            var gridFormatRule = new GridFormatRule();
            var formatConditionRuleIconSet = new FormatConditionRuleIconSet();
            var formatConditionIconSet = new FormatConditionIconSet();
            var formatConditionIconSetIcon1 = new FormatConditionIconSetIcon();
            var formatConditionIconSetIcon2 = new FormatConditionIconSetIcon();
            var formatConditionIconSetIcon3 = new FormatConditionIconSetIcon();

            gridFormatRule.Column = column;
            gridFormatRule.Name = $"{column.Name}_IconSetPositiveNegative";
            formatConditionIconSet.CategoryName = "Positive/Negative";
            formatConditionIconSetIcon1.PredefinedName = "Triangles3_3.png";
            formatConditionIconSetIcon1.Value = new decimal(new int[] {
                -1,
                -1,
                -1,
                -2147483648});
            formatConditionIconSetIcon1.ValueComparison = FormatConditionComparisonType.GreaterOrEqual;
            formatConditionIconSetIcon2.PredefinedName = "Triangles3_2.png";
            formatConditionIconSetIcon2.ValueComparison = FormatConditionComparisonType.GreaterOrEqual;
            formatConditionIconSetIcon3.PredefinedName = "Triangles3_1.png";
            formatConditionIconSet.Icons.Add(formatConditionIconSetIcon1);
            formatConditionIconSet.Icons.Add(formatConditionIconSetIcon2);
            formatConditionIconSet.Icons.Add(formatConditionIconSetIcon3);
            formatConditionIconSet.Name = "PositiveNegativeTriangles";
            formatConditionIconSet.ValueType = FormatConditionValueType.Number;
            formatConditionRuleIconSet.IconSet = formatConditionIconSet;
            gridFormatRule.Rule = formatConditionRuleIconSet;
            if (addToView) column.View.AddFormatRule(gridFormatRule);
            return gridFormatRule;
        }

        public static GridFormatRule CreateMintDataBarRule(this GridColumn column, bool addToView = true)
        {
            var gridFormatRule = new GridFormatRule();
            var formatConditionRuleDataBar = new FormatConditionRuleDataBar();

            gridFormatRule.Column = column;
            gridFormatRule.Name = $"{column.Name}_MintDataBar";
            formatConditionRuleDataBar.PredefinedName = "Mint";
            gridFormatRule.Rule = formatConditionRuleDataBar;
            if (addToView) column.View.AddFormatRule(gridFormatRule);
            return gridFormatRule;
        }

        public static GridFormatRule CreatePositiveValueRule(this GridColumn column, bool addToView = true)
        {
            var gridFormatRule = new GridFormatRule();
            var formatConditionRuleValue = new FormatConditionRuleValue();
            gridFormatRule.Column = column;
            gridFormatRule.Name = $"{column.Name}_PositiveValue";
            formatConditionRuleValue.Appearance.ForeColor = DXSkinColors.ForeColors.Information;
            formatConditionRuleValue.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue.Condition = FormatCondition.Greater;
            formatConditionRuleValue.Value1 = new decimal(new int[] {
            0,
            0,
            0,
            0});
            gridFormatRule.Rule = formatConditionRuleValue;
            if (addToView) column.View.AddFormatRule(gridFormatRule);
            return gridFormatRule;
        }

        public static GridFormatRule CreateNegativeValueRule(this GridColumn column, bool addToView = true)
        {
            var gridFormatRule = new GridFormatRule();
            var formatConditionRuleValue = new FormatConditionRuleValue();
            gridFormatRule.Column = column;
            gridFormatRule.Name = $"{column.Name}_NegativeValue";
            formatConditionRuleValue.Appearance.ForeColor = DXSkinColors.ForeColors.Critical;
            formatConditionRuleValue.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue.Condition = FormatCondition.Less;
            formatConditionRuleValue.Value1 = new decimal(new int[] {
            0,
            0,
            0,
            0});
            gridFormatRule.Rule = formatConditionRuleValue;
            if (addToView) column.View.AddFormatRule(gridFormatRule);
            return gridFormatRule;
        }
    }
}
