namespace TestDynamicListLayout
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            dynamicListUserControl = new DynamicListUserControl();
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            barButtonItemRefresh = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemRestoreDefaultLayout = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemSaveToFile = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemLoadFromFile = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            SuspendLayout();
            // 
            // dynamicListUserControl
            // 
            dynamicListUserControl.Dock = DockStyle.Fill;
            dynamicListUserControl.Initialized = false;
            dynamicListUserControl.Location = new Point(0, 158);
            dynamicListUserControl.Name = "dynamicListUserControl";
            dynamicListUserControl.Size = new Size(1074, 558);
            dynamicListUserControl.TabIndex = 0;
            // 
            // ribbonControl1
            // 
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, barButtonItemRefresh, barButtonItemRestoreDefaultLayout, barButtonItemSaveToFile, barButtonItemLoadFromFile });
            ribbonControl1.Location = new Point(0, 0);
            ribbonControl1.MaxItemId = 5;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbonControl1.Size = new Size(1074, 158);
            // 
            // barButtonItemRefresh
            // 
            barButtonItemRefresh.Caption = "Refresh";
            barButtonItemRefresh.Id = 1;
            barButtonItemRefresh.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItemRefresh.ImageOptions.SvgImage");
            barButtonItemRefresh.Name = "barButtonItemRefresh";
            // 
            // barButtonItemRestoreDefaultLayout
            // 
            barButtonItemRestoreDefaultLayout.Caption = "Restore Default Layout";
            barButtonItemRestoreDefaultLayout.Id = 2;
            barButtonItemRestoreDefaultLayout.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItemRestoreDefaultLayout.ImageOptions.SvgImage");
            barButtonItemRestoreDefaultLayout.Name = "barButtonItemRestoreDefaultLayout";
            // 
            // barButtonItemSaveToFile
            // 
            barButtonItemSaveToFile.Caption = "Save Layout to file...";
            barButtonItemSaveToFile.Id = 3;
            barButtonItemSaveToFile.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItemSaveToFile.ImageOptions.SvgImage");
            barButtonItemSaveToFile.Name = "barButtonItemSaveToFile";
            // 
            // barButtonItemLoadFromFile
            // 
            barButtonItemLoadFromFile.Caption = "Load Layout from file...";
            barButtonItemLoadFromFile.Id = 4;
            barButtonItemLoadFromFile.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItemLoadFromFile.ImageOptions.SvgImage");
            barButtonItemLoadFromFile.Name = "barButtonItemLoadFromFile";
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "Options";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(barButtonItemRefresh);
            ribbonPageGroup1.ItemLinks.Add(barButtonItemRestoreDefaultLayout);
            ribbonPageGroup1.ItemLinks.Add(barButtonItemSaveToFile, true);
            ribbonPageGroup1.ItemLinks.Add(barButtonItemLoadFromFile);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "Options";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1074, 716);
            Controls.Add(dynamicListUserControl);
            Controls.Add(ribbonControl1);
            Name = "Form1";
            Ribbon = ribbonControl1;
            Text = "XttraGrid Layout Issue";
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DynamicListUserControl dynamicListUserControl;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem barButtonItemRefresh;
        private DevExpress.XtraBars.BarButtonItem barButtonItemRestoreDefaultLayout;
        private DevExpress.XtraBars.BarButtonItem barButtonItemSaveToFile;
        private DevExpress.XtraBars.BarButtonItem barButtonItemLoadFromFile;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
    }
}
