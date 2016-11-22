using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GedXMLEdit
{
    public partial class ItemPicker : Form
    {
        string mID;

        public ItemPicker()
        {
            InitializeComponent();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                GEDFileEntry FE = (GEDFileEntry)lstItems.SelectedItem;
                if (FE != null)
                {
                    mID = ((GEDFileEntry)lstItems.SelectedItem).ID;
                }
                else
                {
                    mID = "";
                }
            }
            catch (Exception)
            {
                mID = "";
            }
            this.Close();
        }

        public string ShowDialogAndReturnString(string ID, string ItemType)
        {
            mID = ID;
            Global.GedFile.Display(lstItems, ItemType);
            foreach(GEDFileEntry FE in lstItems.Items) 
            {
                if (FE.ID == ID)
                {
                    lstItems.SelectedItem = FE;
                    break;
                }
            }
            this.ShowDialog();
            return mID;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdNone_Click(object sender, EventArgs e)
        {
            lstItems.SelectedItem = null; 
        }

    }
}
