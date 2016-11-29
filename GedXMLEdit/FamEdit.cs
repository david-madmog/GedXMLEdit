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
                        GEDXMLUtilites.ParseCompoundDate(Child, mdpMarriage);
                        break;
                    case "DIV":
                        GEDXMLUtilites.ParseCompoundDate(Child, mdpDivorce);
                        break; 
                    default:
                        break;
                }
            }
        }

        void UpdateAllFields(XmlNode Node)
        {
            XmlNode TmpNode;

            GEDXMLUtilites.UpdateCompoundDateField("MARR", mdpMarriage, Node);
            GEDXMLUtilites.UpdateCompoundDateField("DIV", mdpDivorce, Node);

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
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
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

    }
}
