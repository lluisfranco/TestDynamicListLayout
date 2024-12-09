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
            dynamicListUserControl = new DynamicListUserControl();
            button1 = new Button();
            SuspendLayout();
            // 
            // dynamicListUserControl
            // 
            dynamicListUserControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dynamicListUserControl.Initialized = false;
            dynamicListUserControl.Location = new Point(10, 62);
            dynamicListUserControl.Name = "dynamicListUserControl";
            dynamicListUserControl.Size = new Size(881, 584);
            dynamicListUserControl.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(112, 44);
            button1.TabIndex = 1;
            button1.Text = "Restore Default Layout";
            button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(902, 657);
            Controls.Add(button1);
            Controls.Add(dynamicListUserControl);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private DynamicListUserControl dynamicListUserControl;
        private Button button1;
    }
}
