namespace WorkRequestSystem.Modules
{ 
    partial class DatabaseManagementForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ViewTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.WRGlobalList = new System.Windows.Forms.DataGridView();
            this.ViewTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WRGlobalList)).BeginInit();
            this.SuspendLayout();
            // 
            // ViewTabControl
            // 
            this.ViewTabControl.Controls.Add(this.tabPage1);
            this.ViewTabControl.Controls.Add(this.tabPage2);
            this.ViewTabControl.Location = new System.Drawing.Point(12, 12);
            this.ViewTabControl.Name = "ViewTabControl";
            this.ViewTabControl.SelectedIndex = 0;
            this.ViewTabControl.Size = new System.Drawing.Size(776, 426);
            this.ViewTabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.WRGlobalList);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 400);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 400);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // WRGlobalList
            // 
            this.WRGlobalList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WRGlobalList.Location = new System.Drawing.Point(6, 6);
            this.WRGlobalList.Name = "WRGlobalList";
            this.WRGlobalList.Size = new System.Drawing.Size(756, 388);
            this.WRGlobalList.TabIndex = 0;
            // 
            // DatabaseManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ViewTabControl);
            this.Name = "DatabaseManagementForm";
            this.Text = "DatabaseManagementForm";
            this.Load += new System.EventHandler(this.DatabaseManagementForm_Load);
            this.ViewTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WRGlobalList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl ViewTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView WRGlobalList;
        private System.Windows.Forms.TabPage tabPage2;
    }
}