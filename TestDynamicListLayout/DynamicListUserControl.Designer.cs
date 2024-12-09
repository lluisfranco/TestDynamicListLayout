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
            this.components = new System.ComponentModel.Container();
            this.gridControlDynamic = new DevExpress.XtraGrid.GridControl();
            this.GridViewDynamic = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ToolTipController = new DevExpress.Utils.ToolTipController(this.components);
            this.gridSplitContainer = new DevExpress.XtraGrid.GridSplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDynamic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewDynamic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSplitContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSplitContainer.Panel1)).BeginInit();
            this.gridSplitContainer.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSplitContainer.Panel2)).BeginInit();
            this.gridSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControlDynamic
            // 
            this.gridControlDynamic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlDynamic.Location = new System.Drawing.Point(0, 0);
            this.gridControlDynamic.MainView = this.GridViewDynamic;
            this.gridControlDynamic.Name = "gridControlDynamic";
            this.gridControlDynamic.Size = new System.Drawing.Size(828, 611);
            this.gridControlDynamic.TabIndex = 3;
            this.gridControlDynamic.ToolTipController = this.ToolTipController;
            this.gridControlDynamic.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewDynamic});
            // 
            // GridViewDynamic
            // 
            this.GridViewDynamic.GridControl = this.gridControlDynamic;
            this.GridViewDynamic.Name = "GridViewDynamic";
            this.GridViewDynamic.OptionsMenu.EnableGroupRowMenu = true;
            this.GridViewDynamic.OptionsMenu.ShowConditionalFormattingItem = true;
            this.GridViewDynamic.OptionsMenu.ShowFooterItem = true;
            this.GridViewDynamic.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.GridViewDynamic.OptionsView.ShowGroupPanel = false;
            // 
            // gridSplitContainer
            // 
            this.gridSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSplitContainer.Grid = this.gridControlDynamic;
            this.gridSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.gridSplitContainer.Name = "gridSplitContainer";
            // 
            // gridSplitContainer.gridSplitContainer_Panel1
            // 
            this.gridSplitContainer.Panel1.Controls.Add(this.gridControlDynamic);
            this.gridSplitContainer.Size = new System.Drawing.Size(828, 611);
            this.gridSplitContainer.TabIndex = 0;
            // 
            // DynamicListUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridSplitContainer);
            this.Name = "DynamicListUserControl";
            this.Size = new System.Drawing.Size(828, 611);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDynamic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewDynamic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSplitContainer.Panel1)).EndInit();
            this.gridSplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSplitContainer.Panel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSplitContainer)).EndInit();
            this.gridSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlDynamic;
        public DevExpress.XtraGrid.Views.Grid.GridView GridViewDynamic;
        private DevExpress.XtraGrid.GridSplitContainer gridSplitContainer;
        public DevExpress.Utils.ToolTipController ToolTipController;
    }
}
