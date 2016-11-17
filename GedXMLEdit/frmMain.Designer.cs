namespace GedXMLEdit
{
    partial class frmGEDXmlEditor
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
            this.txtFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdLoad = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.lstItems = new System.Windows.Forms.ListBox();
            this.lblItem = new System.Windows.Forms.Label();
            this.cmdEditItem = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtImageBase = new System.Windows.Forms.TextBox();
            this.rdoIndi = new System.Windows.Forms.RadioButton();
            this.rdoFams = new System.Windows.Forms.RadioButton();
            this.rdoOthers = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Location = new System.Drawing.Point(77, 4);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(395, 20);
            this.txtFile.TabIndex = 0;
            this.txtFile.Text = "C:\\Users\\davidp\\Documents\\Personal\\Madmog website\\TREE\\SRC\\David.xml";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "File to Edit:";
            // 
            // cmdLoad
            // 
            this.cmdLoad.Location = new System.Drawing.Point(15, 32);
            this.cmdLoad.Name = "cmdLoad";
            this.cmdLoad.Size = new System.Drawing.Size(94, 23);
            this.cmdLoad.TabIndex = 2;
            this.cmdLoad.Text = "Load";
            this.cmdLoad.UseVisualStyleBackColor = true;
            this.cmdLoad.Click += new System.EventHandler(this.cmdLoad_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(117, 32);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(94, 23);
            this.cmdSave.TabIndex = 3;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // lstItems
            // 
            this.lstItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstItems.ColumnWidth = 150;
            this.lstItems.FormattingEnabled = true;
            this.lstItems.Location = new System.Drawing.Point(12, 126);
            this.lstItems.MultiColumn = true;
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(460, 173);
            this.lstItems.TabIndex = 4;
            this.lstItems.SelectedIndexChanged += new System.EventHandler(this.lstItems_SelectedIndexChanged);
            this.lstItems.DoubleClick += new System.EventHandler(this.lstItems_DoubleClick);
            // 
            // lblItem
            // 
            this.lblItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblItem.AutoSize = true;
            this.lblItem.Location = new System.Drawing.Point(115, 314);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(10, 13);
            this.lblItem.TabIndex = 5;
            this.lblItem.Text = ".";
            // 
            // cmdEditItem
            // 
            this.cmdEditItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdEditItem.Location = new System.Drawing.Point(15, 309);
            this.cmdEditItem.Name = "cmdEditItem";
            this.cmdEditItem.Size = new System.Drawing.Size(94, 23);
            this.cmdEditItem.TabIndex = 6;
            this.cmdEditItem.Text = "Edit Item:";
            this.cmdEditItem.UseVisualStyleBackColor = true;
            this.cmdEditItem.Click += new System.EventHandler(this.cmdEditItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Image Base:";
            // 
            // txtImageBase
            // 
            this.txtImageBase.Location = new System.Drawing.Point(77, 96);
            this.txtImageBase.Name = "txtImageBase";
            this.txtImageBase.Size = new System.Drawing.Size(395, 20);
            this.txtImageBase.TabIndex = 8;
            this.txtImageBase.Text = "C:\\Users\\davidp\\Documents\\Personal\\Madmog website\\TREE\\Imgs\\";
            // 
            // rdoIndi
            // 
            this.rdoIndi.AutoSize = true;
            this.rdoIndi.Checked = true;
            this.rdoIndi.Location = new System.Drawing.Point(231, 30);
            this.rdoIndi.Name = "rdoIndi";
            this.rdoIndi.Size = new System.Drawing.Size(75, 17);
            this.rdoIndi.TabIndex = 9;
            this.rdoIndi.TabStop = true;
            this.rdoIndi.Text = "Individuals";
            this.rdoIndi.UseVisualStyleBackColor = true;
            this.rdoIndi.CheckedChanged += new System.EventHandler(this.rdoIndi_CheckedChanged);
            // 
            // rdoFams
            // 
            this.rdoFams.AutoSize = true;
            this.rdoFams.Location = new System.Drawing.Point(231, 53);
            this.rdoFams.Name = "rdoFams";
            this.rdoFams.Size = new System.Drawing.Size(62, 17);
            this.rdoFams.TabIndex = 10;
            this.rdoFams.Text = "Families";
            this.rdoFams.UseVisualStyleBackColor = true;
            this.rdoFams.CheckedChanged += new System.EventHandler(this.rdoFams_CheckedChanged);
            // 
            // rdoOthers
            // 
            this.rdoOthers.AutoSize = true;
            this.rdoOthers.Location = new System.Drawing.Point(231, 76);
            this.rdoOthers.Name = "rdoOthers";
            this.rdoOthers.Size = new System.Drawing.Size(56, 17);
            this.rdoOthers.TabIndex = 11;
            this.rdoOthers.Text = "Others";
            this.rdoOthers.UseVisualStyleBackColor = true;
            this.rdoOthers.CheckedChanged += new System.EventHandler(this.rdoOthers_CheckedChanged);
            // 
            // frmGEDXmlEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 344);
            this.Controls.Add(this.rdoOthers);
            this.Controls.Add(this.rdoFams);
            this.Controls.Add(this.rdoIndi);
            this.Controls.Add(this.txtImageBase);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdEditItem);
            this.Controls.Add(this.lblItem);
            this.Controls.Add(this.lstItems);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdLoad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFile);
            this.Name = "frmGEDXmlEditor";
            this.Text = "GEDXmlEditor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdLoad;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.ListBox lstItems;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Button cmdEditItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtImageBase;
        private System.Windows.Forms.RadioButton rdoIndi;
        private System.Windows.Forms.RadioButton rdoFams;
        private System.Windows.Forms.RadioButton rdoOthers;
    }
}

