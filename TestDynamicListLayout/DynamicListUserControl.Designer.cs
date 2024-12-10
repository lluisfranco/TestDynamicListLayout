namespace TestDynamicListLayout
{
    partial class DynamicListUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            gridControlDynamic = new DevExpress.XtraGrid.GridControl();
            GridViewDynamic = new DevExpress.XtraGrid.Views.Grid.GridView();
            ToolTipController = new DevExpress.Utils.ToolTipController(components);
            gridSplitContainer = new DevExpress.XtraGrid.GridSplitContainer();
            repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)gridControlDynamic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GridViewDynamic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridSplitContainer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridSplitContainer.Panel1).BeginInit();
            gridSplitContainer.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridSplitContainer.Panel2).BeginInit();
            gridSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)repositoryItemTextEdit1).BeginInit();
            SuspendLayout();
            // 
            // gridControlDynamic
            // 
            gridControlDynamic.Dock = DockStyle.Fill;
            gridControlDynamic.Location = new Point(0, 0);
            gridControlDynamic.MainView = GridViewDynamic;
            gridControlDynamic.Name = "gridControlDynamic";
            gridControlDynamic.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemTextEdit1 });
            gridControlDynamic.Size = new Size(828, 611);
            gridControlDynamic.TabIndex = 3;
            gridControlDynamic.ToolTipController = ToolTipController;
            gridControlDynamic.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { GridViewDynamic });
            // 
            // GridViewDynamic
            // 
            GridViewDynamic.GridControl = gridControlDynamic;
            GridViewDynamic.Name = "GridViewDynamic";
            GridViewDynamic.OptionsMenu.EnableGroupRowMenu = true;
            GridViewDynamic.OptionsMenu.ShowConditionalFormattingItem = true;
            GridViewDynamic.OptionsMenu.ShowFooterItem = true;
            GridViewDynamic.OptionsMenu.ShowGroupSummaryEditorItem = true;
            GridViewDynamic.OptionsView.ShowGroupPanel = false;
            // 
            // gridSplitContainer
            // 
            gridSplitContainer.Dock = DockStyle.Fill;
            gridSplitContainer.Grid = gridControlDynamic;
            gridSplitContainer.Location = new Point(0, 0);
            gridSplitContainer.Name = "gridSplitContainer";
            // 
            // gridSplitContainer.Panel1
            // 
            gridSplitContainer.Panel1.Controls.Add(gridControlDynamic);
            gridSplitContainer.Size = new Size(828, 611);
            gridSplitContainer.TabIndex = 0;
            // 
            // repositoryItemTextEdit1
            // 
            repositoryItemTextEdit1.AutoHeight = false;
            repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // DynamicListUserControl
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridSplitContainer);
            Name = "DynamicListUserControl";
            Size = new Size(828, 611);
            ((System.ComponentModel.ISupportInitialize)gridControlDynamic).EndInit();
            ((System.ComponentModel.ISupportInitialize)GridViewDynamic).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridSplitContainer.Panel1).EndInit();
            gridSplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridSplitContainer.Panel2).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridSplitContainer).EndInit();
            gridSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)repositoryItemTextEdit1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlDynamic;
        public DevExpress.XtraGrid.Views.Grid.GridView GridViewDynamic;
        private DevExpress.XtraGrid.GridSplitContainer gridSplitContainer;
        public DevExpress.Utils.ToolTipController ToolTipController;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
    }
}
