using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace GedXMLEdit
{
    public partial class FamEdit : Form
    {
        /*
  <FAM ID="F1">
    <HUSB REF="I1"></HUSB>
    <WIFE REF="I2"></WIFE>
    <CHIL REF="I26"></CHIL>
    <CHIL REF="I313"></CHIL>
    <CHIL REF="I370"></CHIL>
    <MARR>
      <DATE>17 JUL 1993</DATE>
    </MARR>
  </FAM>
         * */
        XmlNode MyNode;

        public FamEdit(XmlNode Node)
        {
            InitializeComponent();
            MyNode = Node;
            ParseNodeToUIComponents(Node);
        }

        private void ParseNodeToUIComponents(XmlNode Node)
        {
            MyDate tmpDateTime;
            XmlNode tmpNode;
            string sID;

            foreach (XmlNode Child in Node.ChildNodes)
            {
                switch (Child.Name.ToUpper())
                {
                    case "HUSB":
                        sID = Child.Attributes["REF"].Value ;
                        tmpNode = GEDXMLUtilites.GlobalLocateNodeByID(sID, "INDI", Child ) ;
                        if (tmpNode != null)
                        {
                            GEDFileEntryIndi Husb = new GEDFileEntryIndi();
                            Husb.Node = tmpNode;
                            lblHusband.Text = Husb.DisplayName;
                            lblHusband.Tag = sID;
                        }
                        break;
                    case "WIFE":
                        sID = Child.Attributes["REF"].Value;
                        tmpNode = GEDXMLUtilites.GlobalLocateNodeByID(sID, "INDI", Child);
                        if (tmpNode != null)
                        {
                            GEDFileEntryIndi Wife = new GEDFileEntryIndi();
                            Wife.Node = tmpNode;
                            lblWife.Text = Wife.DisplayName;
                            lblWife.Tag = sID;
                        }
                        break;
                    case "CHIL":
                        sID = Child.Attributes["REF"].Value;
                        tmpNode = GEDXMLUtilites.GlobalLocateNodeByID(sID, "INDI", Child);
                        if (tmpNode != null)
                        {
                            GEDFileEntryIndi Chil = new GEDFileEntryIndi();
                            Chil.Node = tmpNode;
                            lstChildren.Items.Add(Chil);
                        }
                        break;
                    case "MARR":
                        tmpDateTime = GEDXMLUtilites.ParseDate(Child);
                        if (tmpDateTime != MyDate.MinValue)
                        {
                            chkMarr.Checked = true;
                            txtMarrDate.Text = tmpDateTime.Day();
                            txtMarrMonth.Text = tmpDateTime.Month();
                            txtMarrYear.Text = tmpDateTime.Year();
                        }
                        else
                        {
                            chkMarr.Checked = false;
                        }
//                        txtBirth.Text = GEDXMLUtilites.ParsePlace(Child);
//                        BirthNote = GEDXMLUtilites.ParseNote(Child);
                        break; 
                    default:
                        break;
                }
            }
        }

        void UpdateAllFields(XmlNode Node)
        {
            XmlNode TmpNode;

            if (chkMarr.Checked)
            {
                TmpNode = GEDXMLUtilites.UpdateSingleField("MARR", GEDXMLUtilites.InsertEmpty, Node);
                MyDate tmpDate = new MyDate(txtMarrYear.Value.ToString(), txtMarrMonth.Text, txtMarrDate.Text);
                GEDXMLUtilites.UpdateSingleField("DATE", tmpDate.MedString(), TmpNode);
//                GEDXMLUtilites.UpdateSingleField("PLAC", txtBirth.Text, TmpNode);
//                GEDXMLUtilites.UpdateSingleField("NOTE", BirthNote, TmpNode);
            }
            else
            {
                GEDXMLUtilites.UpdateSingleField("MARR", "", Node);
            }

            if (lblHusband.Text != "")
            {
                TmpNode = GEDXMLUtilites.UpdateSingleField("HUSB", GEDXMLUtilites.InsertEmpty, Node) ;
                GEDXMLUtilites.SetAttribute("REF", lblHusband.Tag.ToString(), TmpNode) ;
            }
            else
            {
                GEDXMLUtilites.UpdateSingleField("HUSB", "", Node);
            }

            if (lblWife.Text != "")
            {
                TmpNode = GEDXMLUtilites.UpdateSingleField("WIFE", GEDXMLUtilites.InsertEmpty, Node) ;
                GEDXMLUtilites.SetAttribute("REF", lblWife.Tag.ToString(), TmpNode) ;
            }
            else
            {
                GEDXMLUtilites.UpdateSingleField("WIFE", "", Node);
            }

            // Children...
            string[] ChildIDs = new string[lstChildren.Items.Count] ;

            for (int i = 0; i< lstChildren.Items.Count; i++)
            {
                ChildIDs[i] = ((GEDFileEntryIndi)lstChildren.Items[i]).ID;
            }
            GEDXMLUtilites.UpdateMultipleFieldAttr("CHIL", "REF", ChildIDs, Node);

            // And now make sure the various individuals are linked back...
            XmlNode tmpIndiNode ;
            string MyID;
            MyID = Node.Attributes["ID"].Value;

            foreach (XmlNode Child in Node.ChildNodes)
            {
                try
                {
                    string SourceID = Child.Attributes["REF"].Value;
                    TmpNode = GEDXMLUtilites.GlobalLocateNodeByID(SourceID, "INDI", Child);
                    if (TmpNode != null)
                    {
                        if (Child.Name.ToUpper() == "HUSB" || Child.Name.ToUpper() == "WIFE")
                        {
                            tmpIndiNode = GEDXMLUtilites.UpdateSingleField("FAMS", GEDXMLUtilites.InsertEmpty, TmpNode);
                            GEDXMLUtilites.SetAttribute("REF", MyID, tmpIndiNode);
                        }
                        else if (Child.Name.ToUpper() == "CHIL")
                        {
                            tmpIndiNode = GEDXMLUtilites.UpdateSingleField("FAMC", GEDXMLUtilites.InsertEmpty, TmpNode);
                            GEDXMLUtilites.SetAttribute("REF", MyID, tmpIndiNode);
                        }
                    }
                }
                catch (Exception) { }
            }
        }






        private void cmdOK_Click(object sender, EventArgs e)
        {
            UpdateAllFields(MyNode);
            this.Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdHusb_Click(object sender, EventArgs e)
        {
            ItemPicker IP = new ItemPicker();
            string ID;
            XmlNode tmpNode;

            if (lblHusband.Tag == null)
                ID = IP.ShowDialogAndReturnString("", "INDI");
            else
                ID = IP.ShowDialogAndReturnString(lblHusband.Tag.ToString(), "INDI");

            if (ID != "")
            {
                tmpNode = GEDXMLUtilites.GlobalLocateNodeByID(ID, "INDI", MyNode);
                if (tmpNode != null)
                {
                    GEDFileEntryIndi Husb = new GEDFileEntryIndi();
                    Husb.Node = tmpNode;
                    lblHusband.Text = Husb.DisplayName;
                    lblHusband.Tag = ID;
                }
            }
            else
            {
                lblHusband.Text = "";
                lblHusband.Tag = "";
            }
        }

        private void cmdWife_Click(object sender, EventArgs e)
        {
            ItemPicker IP = new ItemPicker();
            string ID;
            XmlNode tmpNode;

            if (lblWife.Tag == null)
                ID = IP.ShowDialogAndReturnString("", "INDI");
            else
                ID = IP.ShowDialogAndReturnString(lblWife.Tag.ToString(), "INDI");

            if (ID != "")
            {
                tmpNode = GEDXMLUtilites.GlobalLocateNodeByID(ID, "INDI", MyNode);
                if (tmpNode != null)
                {
                    GEDFileEntryIndi Wife = new GEDFileEntryIndi();
                    Wife.Node = tmpNode;
                    lblWife.Text = Wife.DisplayName;
                    lblWife.Tag = ID;
                }
            }
            else
            {
                lblWife.Text = "";
                lblWife.Tag = "";
            }
        }

        private void cmdAddChild_Click(object sender, EventArgs e)
        {
            ItemPicker IP = new ItemPicker();
            string ID;
            XmlNode tmpNode;

            ID = IP.ShowDialogAndReturnString("", "INDI");

            if (ID != "")
            {
                tmpNode = GEDXMLUtilites.GlobalLocateNodeByID(ID, "INDI", MyNode);
                if (tmpNode != null)
                {
                    GEDFileEntryIndi Chil = new GEDFileEntryIndi();
                    Chil.Node = tmpNode;
                    lstChildren.Items.Add(Chil);
                }
            }
        }

        private void cmdDeleteChild_Click(object sender, EventArgs e)
        {
            if (lstChildren.SelectedIndex >= 0)
                lstChildren.Items.RemoveAt(lstChildren.SelectedIndex);
        }

        private void lstChildren_DoubleClick(object sender, EventArgs e)
        {
            if (lstChildren.SelectedIndex >= 0)
                lstChildren.Items.RemoveAt(lstChildren.SelectedIndex);
        }

        private void chkMarr_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMarr.Checked)
            {
                txtMarrDate.Enabled = true;
                txtMarrMonth.Enabled = true;
                txtMarrYear.Enabled = true;
            }
            else
            {
                txtMarrDate.Enabled = false;
                txtMarrMonth.Enabled = false;
                txtMarrYear.Enabled = false;
            }

        }

        private void cmdMarrPick_Click(object sender, EventArgs e)
        {
            if (mcDatePicker.Visible)
            {
                mcDatePicker.Visible = false;
            }
            else
            {
                mcDatePicker.Top = pnlMarr.Top - mcDatePicker.Height;
                mcDatePicker.Left = pnlMarr.Left;
                MyDate tmpDate = new MyDate(txtMarrYear.Value.ToString(), txtMarrMonth.Text, txtMarrDate.Text);
                mcDatePicker.SelectionRange = new SelectionRange(tmpDate.ToDateTime(), tmpDate.ToDateTime());
                mcDatePicker.Visible = true;
            }
 
        }

        private void mcDatePicker_DateChanged(object sender, DateRangeEventArgs e)
        {
            MyDate D = new MyDate(mcDatePicker.SelectionStart);
            txtMarrDate.Text = D.Day();
            txtMarrMonth.Text = D.Month();
            txtMarrYear.Text = D.Year();
        }
    }
}
