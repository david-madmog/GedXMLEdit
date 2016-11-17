namespace GedXMLEdit
{
    partial class IndiEdit
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
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.rdoMale = new System.Windows.Forms.RadioButton();
            this.rdoFemale = new System.Windows.Forms.RadioButton();
            this.dtpBirth = new System.Windows.Forms.DateTimePicker();
            this.txtBirth = new System.Windows.Forms.TextBox();
            this.dtpDeath = new System.Windows.Forms.DateTimePicker();
            this.txtAKA = new System.Windows.Forms.TextBox();
            this.txtDeath = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmdBirth = new System.Windows.Forms.Button();
            this.cmdDeath = new System.Windows.Forms.Button();
            this.cmdNote = new System.Windows.Forms.Button();
            this.cmdImage = new System.Windows.Forms.Button();
            this.txtImage = new System.Windows.Forms.TextBox();
            this.ofdFile = new System.Windows.Forms.OpenFileDialog();
            this.lblSource = new System.Windows.Forms.Label();
            this.cmdSource = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(249, 330);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(88, 27);
            this.cmdOK.TabIndex = 0;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(343, 330);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(88, 27);
            this.cmdCancel.TabIndex = 1;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(83, 10);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(123, 20);
            this.txtName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sex";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Birth";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Death";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(212, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "AKA";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Image";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(47, 275);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Note";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(199, 275);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Source";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 303);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Emigrated";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 329);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Occupation";
            // 
            // rdoMale
            // 
            this.rdoMale.AutoSize = true;
            this.rdoMale.Location = new System.Drawing.Point(83, 33);
            this.rdoMale.Name = "rdoMale";
            this.rdoMale.Size = new System.Drawing.Size(48, 17);
            this.rdoMale.TabIndex = 13;
            this.rdoMale.TabStop = true;
            this.rdoMale.Text = "Male";
            this.rdoMale.UseVisualStyleBackColor = true;
            // 
            // rdoFemale
            // 
            this.rdoFemale.AutoSize = true;
            this.rdoFemale.Location = new System.Drawing.Point(83, 56);
            this.rdoFemale.Name = "rdoFemale";
            this.rdoFemale.Size = new System.Drawing.Size(59, 17);
            this.rdoFemale.TabIndex = 14;
            this.rdoFemale.TabStop = true;
            this.rdoFemale.Text = "Female";
            this.rdoFemale.UseVisualStyleBackColor = true;
            // 
            // dtpBirth
            // 
            this.dtpBirth.Location = new System.Drawing.Point(83, 79);
            this.dtpBirth.Name = "dtpBirth";
            this.dtpBirth.ShowCheckBox = true;
            this.dtpBirth.Size = new System.Drawing.Size(156, 20);
            this.dtpBirth.TabIndex = 15;
            // 
            // txtBirth
            // 
            this.txtBirth.Location = new System.Drawing.Point(247, 80);
            this.txtBirth.Name = "txtBirth";
            this.txtBirth.Size = new System.Drawing.Size(148, 20);
            this.txtBirth.TabIndex = 16;
            // 
            // dtpDeath
            // 
            this.dtpDeath.Location = new System.Drawing.Point(83, 105);
            this.dtpDeath.Name = "dtpDeath";
            this.dtpDeath.ShowCheckBox = true;
            this.dtpDeath.Size = new System.Drawing.Size(156, 20);
            this.dtpDeath.TabIndex = 17;
            // 
            // txtAKA
            // 
            this.txtAKA.Location = new System.Drawing.Point(247, 10);
            this.txtAKA.Name = "txtAKA";
            this.txtAKA.Size = new System.Drawing.Size(148, 20);
            this.txtAKA.TabIndex = 18;
            // 
            // txtDeath
            // 
            this.txtDeath.Location = new System.Drawing.Point(247, 105);
            this.txtDeath.Name = "txtDeath";
            this.txtDeath.Size = new System.Drawing.Size(148, 20);
            this.txtDeath.TabIndex = 19;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(83, 154);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // cmdBirth
            // 
            this.cmdBirth.Location = new System.Drawing.Point(401, 81);
            this.cmdBirth.Name = "cmdBirth";
            this.cmdBirth.Size = new System.Drawing.Size(34, 19);
            this.cmdBirth.TabIndex = 21;
            this.cmdBirth.Text = "...";
            this.cmdBirth.UseVisualStyleBackColor = true;
            this.cmdBirth.Click += new System.EventHandler(this.cmdBirth_Click);
            // 
            // cmdDeath
            // 
            this.cmdDeath.Location = new System.Drawing.Point(401, 105);
            this.cmdDeath.Name = "cmdDeath";
            this.cmdDeath.Size = new System.Drawing.Size(34, 19);
            this.cmdDeath.TabIndex = 22;
            this.cmdDeath.Text = "...";
            this.cmdDeath.UseVisualStyleBackColor = true;
            this.cmdDeath.Click += new System.EventHandler(this.cmdDeath_Click);
            // 
            // cmdNote
            // 
            this.cmdNote.Location = new System.Drawing.Point(86, 272);
            this.cmdNote.Name = "cmdNote";
            this.cmdNote.Size = new System.Drawing.Size(34, 19);
            this.cmdNote.TabIndex = 23;
            this.cmdNote.Text = "...";
            this.cmdNote.UseVisualStyleBackColor = true;
            this.cmdNote.Click += new System.EventHandler(this.cmdNote_Click);
            // 
            // cmdImage
            // 
            this.cmdImage.Location = new System.Drawing.Point(247, 128);
            this.cmdImage.Name = "cmdImage";
            this.cmdImage.Size = new System.Drawing.Size(34, 19);
            this.cmdImage.TabIndex = 24;
            this.cmdImage.Text = "...";
            this.cmdImage.UseVisualStyleBackColor = true;
            this.cmdImage.Click += new System.EventHandler(this.cmdImage_Click);
            // 
            // txtImage
            // 
            this.txtImage.Location = new System.Drawing.Point(83, 128);
            this.txtImage.Name = "txtImage";
            this.txtImage.Size = new System.Drawing.Size(156, 20);
            this.txtImage.TabIndex = 25;
            // 
            // ofdFile
            // 
            this.ofdFile.FileName = "openFileDialog1";
            // 
            // lblSource
            // 
            this.lblSource.BackColor = System.Drawing.SystemColors.Window;
            this.lblSource.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSource.Location = new System.Drawing.Point(246, 272);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(149, 19);
            this.lblSource.TabIndex = 26;
            // 
            // cmdSource
            // 
            this.cmdSource.Location = new System.Drawing.Point(401, 272);
            this.cmdSource.Name = "cmdSource";
            this.cmdSource.Size = new System.Drawing.Size(34, 19);
            this.cmdSource.TabIndex = 27;
            this.cmdSource.Text = "...";
            this.cmdSource.UseVisualStyleBackColor = true;
            this.cmdSource.Click += new System.EventHandler(this.cmdSource_Click);
            // 
            // IndiEdit
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(443, 369);
            this.ControlBox = false;
            this.Controls.Add(this.cmdSource);
            this.Controls.Add(this.lblSource);
            this.Controls.Add(this.txtImage);
            this.Controls.Add(this.cmdImage);
            this.Controls.Add(this.cmdNote);
            this.Controls.Add(this.cmdDeath);
            this.Controls.Add(this.cmdBirth);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtDeath);
            this.Controls.Add(this.txtAKA);
            this.Controls.Add(this.dtpDeath);
            this.Controls.Add(this.txtBirth);
            this.Controls.Add(this.dtpBirth);
            this.Controls.Add(this.rdoFemale);
            this.Controls.Add(this.rdoMale);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "IndiEdit";
            this.Text = "Edit Individual";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton rdoMale;
        private System.Windows.Forms.RadioButton rdoFemale;
        private System.Windows.Forms.DateTimePicker dtpBirth;
        private System.Windows.Forms.TextBox txtBirth;
        private System.Windows.Forms.DateTimePicker dtpDeath;
        private System.Windows.Forms.TextBox txtAKA;
        private System.Windows.Forms.TextBox txtDeath;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button cmdBirth;
        private System.Windows.Forms.Button cmdDeath;
        private System.Windows.Forms.Button cmdNote;
        private System.Windows.Forms.Button cmdImage;
        private System.Windows.Forms.TextBox txtImage;
        private System.Windows.Forms.OpenFileDialog ofdFile;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Button cmdSource;
    }
}