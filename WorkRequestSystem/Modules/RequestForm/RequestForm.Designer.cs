namespace WorkRequestSystem.Modules
{
    partial class RequestForm
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
            this.DateOfWorkPerformedCalendar = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.WorkDescriptionText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TruckNumberComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.HoursWorkedNumeric = new System.Windows.Forms.NumericUpDown();
            this.MinutesWorkedNumeric = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.PartsListBox = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.PartNameComboBox = new System.Windows.Forms.ComboBox();
            this.AddPartBtn = new System.Windows.Forms.Button();
            this.RemovePartBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.AcceptBtn = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.PartsNumberComboBox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TruckBrandComboBox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TruckSerialNumberComboBox = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.TruckModelNumberComboBox = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.TruckTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.TruckDepartmentComboBox = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.TruckOperatorComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.HoursWorkedNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinutesWorkedNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // DateOfWorkPerformedCalendar
            // 
            this.DateOfWorkPerformedCalendar.Location = new System.Drawing.Point(14, 296);
            this.DateOfWorkPerformedCalendar.MaxSelectionCount = 1;
            this.DateOfWorkPerformedCalendar.Name = "DateOfWorkPerformedCalendar";
            this.DateOfWorkPerformedCalendar.TabIndex = 0;
            this.DateOfWorkPerformedCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.DateOfWorkPerformedCalendar_DateChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Amana Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Description of work performed";
            // 
            // WorkDescriptionText
            // 
            this.WorkDescriptionText.AcceptsReturn = true;
            this.WorkDescriptionText.Location = new System.Drawing.Point(15, 153);
            this.WorkDescriptionText.Multiline = true;
            this.WorkDescriptionText.Name = "WorkDescriptionText";
            this.WorkDescriptionText.Size = new System.Drawing.Size(267, 118);
            this.WorkDescriptionText.TabIndex = 4;
            this.WorkDescriptionText.TextChanged += new System.EventHandler(this.WorkDescriptionText_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Date of work performed";
            // 
            // TruckNumberComboBox
            // 
            this.TruckNumberComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.TruckNumberComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TruckNumberComboBox.FormattingEnabled = true;
            this.TruckNumberComboBox.Location = new System.Drawing.Point(15, 33);
            this.TruckNumberComboBox.Name = "TruckNumberComboBox";
            this.TruckNumberComboBox.Size = new System.Drawing.Size(121, 21);
            this.TruckNumberComboBox.TabIndex = 9;
            this.TruckNumberComboBox.SelectedIndexChanged += new System.EventHandler(this.TruckNumberComboBox_SelectedIndexChanged);
            this.TruckNumberComboBox.TextUpdate += new System.EventHandler(this.TruckNumberComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 471);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Time Spent";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 488);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Hours";
            // 
            // HoursWorkedNumeric
            // 
            this.HoursWorkedNumeric.Location = new System.Drawing.Point(21, 505);
            this.HoursWorkedNumeric.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.HoursWorkedNumeric.Name = "HoursWorkedNumeric";
            this.HoursWorkedNumeric.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.HoursWorkedNumeric.Size = new System.Drawing.Size(55, 20);
            this.HoursWorkedNumeric.TabIndex = 12;
            this.HoursWorkedNumeric.ValueChanged += new System.EventHandler(this.UpdateTimeSpent);
            // 
            // MinutesWorkedNumeric
            // 
            this.MinutesWorkedNumeric.Location = new System.Drawing.Point(82, 505);
            this.MinutesWorkedNumeric.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.MinutesWorkedNumeric.Name = "MinutesWorkedNumeric";
            this.MinutesWorkedNumeric.Size = new System.Drawing.Size(53, 20);
            this.MinutesWorkedNumeric.TabIndex = 13;
            this.MinutesWorkedNumeric.ValueChanged += new System.EventHandler(this.UpdateTimeSpent);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(83, 486);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Minutes";
            // 
            // PartsListBox
            // 
            this.PartsListBox.FormattingEnabled = true;
            this.PartsListBox.Location = new System.Drawing.Point(396, 36);
            this.PartsListBox.Name = "PartsListBox";
            this.PartsListBox.Size = new System.Drawing.Size(154, 407);
            this.PartsListBox.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(396, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Parts Used";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(556, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Part to add";
            // 
            // PartNameComboBox
            // 
            this.PartNameComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.PartNameComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.PartNameComboBox.FormattingEnabled = true;
            this.PartNameComboBox.Location = new System.Drawing.Point(560, 65);
            this.PartNameComboBox.Name = "PartNameComboBox";
            this.PartNameComboBox.Size = new System.Drawing.Size(121, 21);
            this.PartNameComboBox.TabIndex = 18;
            this.PartNameComboBox.SelectedIndexChanged += new System.EventHandler(this.PartNameComboBox_SelectedIndexChanged);
            // 
            // AddPartBtn
            // 
            this.AddPartBtn.Location = new System.Drawing.Point(559, 136);
            this.AddPartBtn.Name = "AddPartBtn";
            this.AddPartBtn.Size = new System.Drawing.Size(75, 23);
            this.AddPartBtn.TabIndex = 19;
            this.AddPartBtn.Text = "Add Part";
            this.AddPartBtn.UseVisualStyleBackColor = true;
            this.AddPartBtn.Click += new System.EventHandler(this.AddPartBtn_Click);
            // 
            // RemovePartBtn
            // 
            this.RemovePartBtn.Location = new System.Drawing.Point(559, 165);
            this.RemovePartBtn.Name = "RemovePartBtn";
            this.RemovePartBtn.Size = new System.Drawing.Size(102, 23);
            this.RemovePartBtn.TabIndex = 20;
            this.RemovePartBtn.Text = "Remove Selected";
            this.RemovePartBtn.UseVisualStyleBackColor = true;
            this.RemovePartBtn.Click += new System.EventHandler(this.RemovePartBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(606, 505);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 21;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // AcceptBtn
            // 
            this.AcceptBtn.Location = new System.Drawing.Point(525, 505);
            this.AcceptBtn.Name = "AcceptBtn";
            this.AcceptBtn.Size = new System.Drawing.Size(75, 23);
            this.AcceptBtn.TabIndex = 22;
            this.AcceptBtn.Text = "Accept";
            this.AcceptBtn.UseVisualStyleBackColor = true;
            this.AcceptBtn.Click += new System.EventHandler(this.AcceptBtn_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(557, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(560, 93);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "P/N";
            // 
            // PartsNumberComboBox
            // 
            this.PartsNumberComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.PartsNumberComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.PartsNumberComboBox.FormattingEnabled = true;
            this.PartsNumberComboBox.Location = new System.Drawing.Point(560, 109);
            this.PartsNumberComboBox.Name = "PartsNumberComboBox";
            this.PartsNumberComboBox.Size = new System.Drawing.Size(121, 21);
            this.PartsNumberComboBox.TabIndex = 25;
            this.PartsNumberComboBox.SelectedIndexChanged += new System.EventHandler(this.PartsNumberComboBox_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(139, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Truck Brand";
            // 
            // TruckBrandComboBox
            // 
            this.TruckBrandComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.TruckBrandComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TruckBrandComboBox.FormattingEnabled = true;
            this.TruckBrandComboBox.Location = new System.Drawing.Point(142, 33);
            this.TruckBrandComboBox.Name = "TruckBrandComboBox";
            this.TruckBrandComboBox.Size = new System.Drawing.Size(121, 21);
            this.TruckBrandComboBox.TabIndex = 27;
            this.TruckBrandComboBox.SelectedIndexChanged += new System.EventHandler(this.TruckBrandComboBox_SelectedIndexChanged);
            this.TruckBrandComboBox.TextUpdate += new System.EventHandler(this.TruckBrandComboBox_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 57);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "Serial Number";
            // 
            // TruckSerialNumberComboBox
            // 
            this.TruckSerialNumberComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.TruckSerialNumberComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TruckSerialNumberComboBox.FormattingEnabled = true;
            this.TruckSerialNumberComboBox.Location = new System.Drawing.Point(15, 73);
            this.TruckSerialNumberComboBox.Name = "TruckSerialNumberComboBox";
            this.TruckSerialNumberComboBox.Size = new System.Drawing.Size(121, 21);
            this.TruckSerialNumberComboBox.TabIndex = 29;
            this.TruckSerialNumberComboBox.SelectedIndexChanged += new System.EventHandler(this.TruckSerialNumberComboBox_SelectedIndexChanged);
            this.TruckSerialNumberComboBox.TextUpdate += new System.EventHandler(this.TruckSerialNumberComboBox_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(139, 57);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = "Model Number";
            // 
            // TruckModelNumberComboBox
            // 
            this.TruckModelNumberComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.TruckModelNumberComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TruckModelNumberComboBox.FormattingEnabled = true;
            this.TruckModelNumberComboBox.Location = new System.Drawing.Point(142, 73);
            this.TruckModelNumberComboBox.Name = "TruckModelNumberComboBox";
            this.TruckModelNumberComboBox.Size = new System.Drawing.Size(121, 21);
            this.TruckModelNumberComboBox.TabIndex = 31;
            this.TruckModelNumberComboBox.SelectedIndexChanged += new System.EventHandler(this.TruckModelNumberComboBox_SelectedIndexChanged);
            this.TruckModelNumberComboBox.TextUpdate += new System.EventHandler(this.TruckModelNumberComboBox_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(266, 18);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 13);
            this.label14.TabIndex = 32;
            this.label14.Text = "Truck Type";
            // 
            // TruckTypeComboBox
            // 
            this.TruckTypeComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.TruckTypeComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TruckTypeComboBox.FormattingEnabled = true;
            this.TruckTypeComboBox.Location = new System.Drawing.Point(269, 32);
            this.TruckTypeComboBox.Name = "TruckTypeComboBox";
            this.TruckTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.TruckTypeComboBox.TabIndex = 33;
            this.TruckTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.TruckTypeComboBox_SelectedIndexChanged);
            this.TruckTypeComboBox.TextUpdate += new System.EventHandler(this.TruckTypeComboBox_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(266, 57);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 13);
            this.label15.TabIndex = 34;
            this.label15.Text = "Department";
            // 
            // TruckDepartmentComboBox
            // 
            this.TruckDepartmentComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.TruckDepartmentComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TruckDepartmentComboBox.FormattingEnabled = true;
            this.TruckDepartmentComboBox.Location = new System.Drawing.Point(269, 73);
            this.TruckDepartmentComboBox.Name = "TruckDepartmentComboBox";
            this.TruckDepartmentComboBox.Size = new System.Drawing.Size(121, 21);
            this.TruckDepartmentComboBox.TabIndex = 35;
            this.TruckDepartmentComboBox.SelectedIndexChanged += new System.EventHandler(this.TruckDepartmentComboBox_SelectedIndexChanged);
            this.TruckDepartmentComboBox.TextUpdate += new System.EventHandler(this.TruckDepartmentComboBox_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 97);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 13);
            this.label16.TabIndex = 36;
            this.label16.Text = "Operator";
            // 
            // TruckOperatorComboBox
            // 
            this.TruckOperatorComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.TruckOperatorComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TruckOperatorComboBox.FormattingEnabled = true;
            this.TruckOperatorComboBox.Location = new System.Drawing.Point(15, 113);
            this.TruckOperatorComboBox.Name = "TruckOperatorComboBox";
            this.TruckOperatorComboBox.Size = new System.Drawing.Size(121, 21);
            this.TruckOperatorComboBox.TabIndex = 37;
            this.TruckOperatorComboBox.SelectedIndexChanged += new System.EventHandler(this.TruckOperatorComboBox_SelectedIndexChanged);
            this.TruckOperatorComboBox.TextUpdate += new System.EventHandler(this.TruckOperatorComboBox_SelectedIndexChanged);
            // 
            // RequestForm
            // 
            this.AcceptButton = this.AcceptBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(690, 537);
            this.Controls.Add(this.TruckOperatorComboBox);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.TruckDepartmentComboBox);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.TruckTypeComboBox);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.TruckModelNumberComboBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.TruckSerialNumberComboBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.TruckBrandComboBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.PartsNumberComboBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.AcceptBtn);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.RemovePartBtn);
            this.Controls.Add(this.AddPartBtn);
            this.Controls.Add(this.PartNameComboBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.PartsListBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.MinutesWorkedNumeric);
            this.Controls.Add(this.HoursWorkedNumeric);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TruckNumberComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.WorkDescriptionText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DateOfWorkPerformedCalendar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RequestForm";
            this.ShowIcon = false;
            this.Text = "Work Performance Form";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.HoursWorkedNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinutesWorkedNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar DateOfWorkPerformedCalendar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox WorkDescriptionText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox TruckNumberComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown HoursWorkedNumeric;
        private System.Windows.Forms.NumericUpDown MinutesWorkedNumeric;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox PartsListBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox PartNameComboBox;
        private System.Windows.Forms.Button AddPartBtn;
        private System.Windows.Forms.Button RemovePartBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button AcceptBtn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox PartsNumberComboBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox TruckBrandComboBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox TruckSerialNumberComboBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox TruckModelNumberComboBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox TruckTypeComboBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox TruckDepartmentComboBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox TruckOperatorComboBox;
    }
}