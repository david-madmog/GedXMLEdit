namespace GedXMLEdit
{
    partial class FamEdit
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstChildren = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdHusb = new System.Windows.Forms.Button();
            this.cmdWife = new System.Windows.Forms.Button();
            this.cmdAddChild = new System.Windows.Forms.Button();
            this.cmdDeleteChild = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.lblHusband = new System.Windows.Forms.Label();
            this.lblWife = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.mdpMarriage = new GedXMLEdit.MyDatePicker();
            this.mdpDivorce = new GedXMLEdit.MyDatePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Husband";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Wife";
            // 
            // lstChildren
            // 
            this.lstChildren.FormattingEnabled = true;
            this.lstChildren.Location = new System.Drawing.Point(191, 42);
            this.lstChildren.Name = "lstChildren";
            this.lstChildren.Size = new System.Drawing.Size(199, 82);
            this.lstChildren.TabIndex = 4;
            this.lstChildren.DoubleClick += new System.EventHandler(this.lstChildren_DoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(191, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Children";
            // 
            // cmdHusb
            // 
            this.cmdHusb.Location = new System.Drawing.Point(142, 38);
            this.cmdHusb.Name = "cmdHusb";
            this.cmdHusb.Size = new System.Drawing.Size(43, 23);
            this.cmdHusb.TabIndex = 6;
            this.cmdHusb.Text = "...";
            this.cmdHusb.UseVisualStyleBackColor = true;
            this.cmdHusb.Click += new System.EventHandler(this.cmdHusb_Click);
            // 
            // cmdWife
            // 
            this.cmdWife.Location = new System.Drawing.Point(142, 106);
            this.cmdWife.Name = "cmdWife";
            this.cmdWife.Size = new System.Drawing.Size(43, 23);
            this.cmdWife.TabIndex = 7;
            this.cmdWife.Text = "...";
            this.cmdWife.UseVisualStyleBackColor = true;
            this.cmdWife.Click += new System.EventHandler(this.cmdWife_Click);
            // 
            // cmdAddChild
            // 
            this.cmdAddChild.Location = new System.Drawing.Point(396, 40);
            this.cmdAddChild.Name = "cmdAddChild";
            this.cmdAddChild.Size = new System.Drawing.Size(75, 23);
            this.cmdAddChild.TabIndex = 8;
            this.cmdAddChild.Text = "Add...";
            this.cmdAddChild.UseVisualStyleBackColor = true;
            this.cmdAddChild.Click += new System.EventHandler(this.cmdAddChild_Click);
            // 
            // cmdDeleteChild
            // 
            this.cmdDeleteChild.Location = new System.Drawing.Point(396, 70);
            this.cmdDeleteChild.Name = "cmdDeleteChild";
            this.cmdDeleteChild.Size = new System.Drawing.Size(75, 23);
            this.cmdDeleteChild.TabIndex = 9;
            this.cmdDeleteChild.Text = "Delete";
            this.cmdDeleteChild.UseVisualStyleBackColor = true;
            this.cmdDeleteChild.Click += new System.EventHandler(this.cmdDeleteChild_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(396, 275);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 10;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(315, 275);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 11;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // lblHusband
            // 
            this.lblHusband.BackColor = System.Drawing.SystemColors.Window;
            this.lblHusband.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHusband.Location = new System.Drawing.Point(13, 38);
            this.lblHusband.Name = "lblHusband";
            this.lblHusband.Size = new System.Drawing.Size(122, 23);
            this.lblHusband.TabIndex = 12;
            this.lblHusband.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWife
            // 
            this.lblWife.BackColor = System.Drawing.SystemColors.Window;
            this.lblWife.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblWife.Location = new System.Drawing.Point(13, 106);
            this.lblWife.Name = "lblWife";
            this.lblWife.Size = new System.Drawing.Size(122, 23);
            this.lblWife.TabIndex = 13;
            this.lblWife.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Marriage";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "Divorce";
            // 
            // mdpMarriage
            // 
            this.mdpMarriage.BackColor = System.Drawing.SystemColors.Window;
            this.mdpMarriage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mdpMarriage.Checked = false;
            this.mdpMarriage.Location = new System.Drawing.Point(13, 161);
            this.mdpMarriage.Name = "mdpMarriage";
            this.mdpMarriage.Size = new System.Drawing.Size(390, 22);
            this.mdpMarriage.TabIndex = 42;
            // 
            // mdpDivorce
            // 
            this.mdpDivorce.BackColor = System.Drawing.SystemColors.Window;
            this.mdpDivorce.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mdpDivorce.Checked = false;
            this.mdpDivorce.Location = new System.Drawing.Point(13, 210);
            this.mdpDivorce.Name = "mdpDivorce";
            this.mdpDivorce.Size = new System.Drawing.Size(390, 22);
            this.mdpDivorce.TabIndex = 41;
            // 
            // FamEdit
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(478, 357);
            this.Controls.Add(this.mdpMarriage);
            this.Controls.Add(this.mdpDivorce);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblWife);
            this.Controls.Add(this.lblHusband);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdDeleteChild);
            this.Controls.Add(this.cmdAddChild);
            this.Controls.Add(this.cmdWife);
            this.Controls.Add(this.cmdHusb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstChildren);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FamEdit";
            this.Text = "Edit Family";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstChildren;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdHusb;
        private System.Windows.Forms.Button cmdWife;
        private System.Windows.Forms.Button cmdAddChild;
        private System.Windows.Forms.Button cmdDeleteChild;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label lblHusband;
        private System.Windows.Forms.Label lblWife;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private MyDatePicker mdpDivorce;
        private MyDatePicker mdpMarriage;
    }
}