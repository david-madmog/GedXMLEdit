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
        }

        private void cmdLoad_Click(object sender, EventArgs e)
        {
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
            Entry.Edit();
        }

        private void lstItems_DoubleClick(object sender, EventArgs e)
        {
            cmdEditItem_Click(sender, e);
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {       
            Doc.Save(txtFile.Text);
        }

        private void rdoIndi_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoIndi.Checked)
            {
                lstItems.ColumnWidth = 150;
                Global.GedFile.Display(lstItems, "INDI");
            }
        }

        private void rdoFams_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoFams.Checked)
            {
                lstItems.ColumnWidth = 300;
                Global.GedFile.Display(lstItems, "FAM");
            }
        }

        private void rdoOthers_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoOthers.Checked)
            {
                lstItems.ColumnWidth = 100;
                Global.GedFile.Display(lstItems, "OTHER");
            }
        }

        private void txtFile_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public static class Global
    {
        public static GEDFile GedFile;
    }

}
