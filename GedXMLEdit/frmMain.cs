using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml ;

namespace GedXMLEdit
{
    public partial class frmGEDXmlEditor : Form
    {
        XmlDocument Doc = new XmlDocument() ;

        public frmGEDXmlEditor()
        {
            InitializeComponent();
            Global.bChanged = false;
        }

        private void cmdLoad_Click(object sender, EventArgs e)
        {
            if (Global.bChanged)
            {
                if (MessageBox.Show("File has changed. Discard Changes and load new file?", "Are you sure", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    == DialogResult.No)
                {
                    return;
                }
            }
            Global.bChanged = false;
            try {
                Log ("Loading " + txtFile.Text) ;
                Doc.Load(txtFile.Text);
                if (GEDFile.IsGedXMLFile(Doc))
                {
                    // Parse the file into the collecting class
                    Global.GedFile = new GEDFile(Doc);

                    // And display the objects into the list
                    if (rdoIndi.Checked)
                        Global.GedFile.Display(lstItems, "INDI");
                    else if(rdoFams.Checked)
                        Global.GedFile.Display(lstItems, "FAM");
                    else
                        Global.GedFile.Display(lstItems, "OTHER");
                }
                else
                {
                    Log("Not a GED XML File");
                }
            } catch (Exception Ex) {
                Log(Ex.Message);
            }
        }

        public static void Log(String S)
        {
            Console.Write(S + "\n");
        }

        private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            GEDFileEntry Entry;
            Entry = (GEDFileEntry)lstItems.SelectedItem;

            lblItem.Text = Entry.ID + ": " + Entry.DisplayName;
        }

        private void cmdEditItem_Click(object sender, EventArgs e)
        {
            GEDFileEntry Entry;
            Entry = (GEDFileEntry)lstItems.SelectedItem;
            Entry.ImageBase = txtImageBase.Text;
            if (Entry.Edit()== DialogResult.OK)
            {
                Global.bChanged = true;
                this.Text = Global.Title + " *";
            }
        }

        private void cmdNewItem_Click(object sender, EventArgs e)
        {
            GEDFileEntry Entry;
            string Type = "";

            if (Global.GedFile != null)
            {
                if (rdoIndi.Checked)
                    Type ="INDI" ;
                else if(rdoFams.Checked)
                    Type = "FAM" ;
                else
                    Type = "SOUR" ;

                Entry = Global.GedFile.NewEntry(Type, Doc);
                Entry.ImageBase = txtImageBase.Text;
                if (Entry.Edit() == DialogResult.OK)
                {
                    Global.bChanged = true;
                    this.Text = Global.Title + " *";
                }
            }
            Global.GedFile.Display(lstItems, Type);
        }

        private void lstItems_DoubleClick(object sender, EventArgs e)
        {
            cmdEditItem_Click(sender, e);
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {       
            Doc.Save(txtFile.Text);
            Global.bChanged = false;
            this.Text = Global.Title ;
        }

        private void rdoIndi_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoIndi.Checked)
            {
                lstItems.ColumnWidth = 150;
                if (Global.GedFile != null)
                    Global.GedFile.Display(lstItems, "INDI");
            }
        }

        private void rdoFams_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoFams.Checked)
            {
                lstItems.ColumnWidth = 300;
                if (Global.GedFile != null)
                    Global.GedFile.Display(lstItems, "FAM");
            }
        }

        private void rdoOthers_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoOthers.Checked)
            {
                lstItems.ColumnWidth = 100;
                if (Global.GedFile != null)
                    Global.GedFile.Display(lstItems, "OTHER");
            }
        }

        private void frmGEDXmlEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Global.bChanged)
            {
                if (MessageBox.Show("File has changed. Save changes before Exit?", "Are you sure", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    == DialogResult.Yes)
                {
                    Doc.Save(txtFile.Text);
                }
            }
        }

    }

    public static class Global
    {
        public static GEDFile GedFile;
        public static bool bChanged;
        public static string Title = "GED XML Editor";
    }

}
