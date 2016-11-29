namespace GedXMLEdit
{
    partial class MyDatePicker
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
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.cmdPick = new System.Windows.Forms.Button();
            this.calPick = new System.Windows.Forms.MonthCalendar();
            this.cmdNote = new System.Windows.Forms.Button();
            this.txtPlace = new System.Windows.Forms.TextBox();
            this.pnlDate = new System.Windows.Forms.Panel();
            this.txtYear = new System.Windows.Forms.NumericUpDown();
            this.txtMonth = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.lblat = new System.Windows.Forms.Label();
            this.pnlDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtYear)).BeginInit();
            this.SuspendLayout();
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(3, 6);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(15, 14);
            this.chkEnabled.TabIndex = 44;
            this.chkEnabled.UseVisualStyleBackColor = true;
            this.chkEnabled.CheckedChanged += new System.EventHandler(this.chkEnabled_CheckedChanged);
            // 
            // cmdPick
            // 
            this.cmdPick.Location = new System.Drawing.Point(139, 3);
            this.cmdPick.Name = "cmdPick";
            this.cmdPick.Size = new System.Drawing.Size(24, 19);
            this.cmdPick.TabIndex = 43;
            this.cmdPick.Text = "▼";
            this.cmdPick.UseVisualStyleBackColor = true;
            this.cmdPick.Click += new System.EventHandler(this.cmdPick_Click);
            // 
            // calPick
            // 
            this.calPick.Location = new System.Drawing.Point(35, 28);
            this.calPick.Name = "calPick";
            this.calPick.TabIndex = 45;
            this.calPick.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calPick_DateChanged);
            // 
            // cmdNote
            // 
            this.cmdNote.Location = new System.Drawing.Point(312, 4);
            this.cmdNote.Name = "cmdNote";
            this.cmdNote.Size = new System.Drawing.Size(37, 19);
            this.cmdNote.TabIndex = 47;
            this.cmdNote.Text = "note";
            this.cmdNote.UseVisualStyleBackColor = true;
            this.cmdNote.Click += new System.EventHandler(this.cmdNote_Click);
            // 
            // txtPlace
            // 
            this.txtPlace.Location = new System.Drawing.Point(182, 3);
            this.txtPlace.Name = "txtPlace";
            this.txtPlace.Size = new System.Drawing.Size(130, 20);
            this.txtPlace.TabIndex = 46;
            // 
            // pnlDate
            // 
            this.pnlDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDate.Controls.Add(this.txtYear);
            this.pnlDate.Controls.Add(this.txtMonth);
            this.pnlDate.Controls.Add(this.txtDate);
            this.pnlDate.Location = new System.Drawing.Point(19, 2);
            this.pnlDate.Name = "pnlDate";
            this.pnlDate.Size = new System.Drawing.Size(121, 24);
            this.pnlDate.TabIndex = 48;
            // 
            // txtYear
            // 
            this.txtYear.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtYear.Location = new System.Drawing.Point(69, 3);
            this.txtYear.Maximum = new decimal(new int[] {
            2099,
            0,
            0,
            0});
            this.txtYear.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(47, 16);
            this.txtYear.TabIndex = 45;
            this.txtYear.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtYear.ValueChanged += new System.EventHandler(this.txtYear_ValueChanged);
            // 
            // txtMonth
            // 
            this.txtMonth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMonth.Location = new System.Drawing.Point(19, 3);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new System.Drawing.Size(50, 13);
            this.txtMonth.TabIndex = 44;
            this.txtMonth.TextChanged += new System.EventHandler(this.txtMonth_TextChanged);
            // 
            // txtDate
            // 
            this.txtDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDate.Location = new System.Drawing.Point(4, 3);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(18, 13);
            this.txtDate.TabIndex = 43;
            this.txtDate.TextChanged += new System.EventHandler(this.txtDate_TextChanged);
            // 
            // lblat
            // 
            this.lblat.AutoSize = true;
            this.lblat.Location = new System.Drawing.Point(163, 6);
            this.lblat.Name = "lblat";
            this.lblat.Size = new System.Drawing.Size(16, 13);
            this.lblat.TabIndex = 49;
            this.lblat.Text = "at";
            // 
            // MyDatePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.lblat);
            this.Controls.Add(this.pnlDate);
            this.Controls.Add(this.cmdNote);
            this.Controls.Add(this.txtPlace);
            this.Controls.Add(this.calPick);
            this.Controls.Add(this.chkEnabled);
            this.Controls.Add(this.cmdPick);
            this.Name = "MyDatePicker";
            this.Size = new System.Drawing.Size(351, 28);
            this.Load += new System.EventHandler(this.MyDatePicker_Load);
            this.pnlDate.ResumeLayout(false);
            this.pnlDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.Button cmdPick;
        private System.Windows.Forms.MonthCalendar calPick;
        private System.Windows.Forms.Button cmdNote;
        private System.Windows.Forms.TextBox txtPlace;
        private System.Windows.Forms.Panel pnlDate;
        private System.Windows.Forms.NumericUpDown txtYear;
        private System.Windows.Forms.TextBox txtMonth;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label lblat;
    }
}
