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
using System.IO;

namespace GedXMLEdit
{
    public partial class IndiEdit : Form
    {
        /*
    <NAME>David Simon /Poirier/</NAME>
    <SEX>M</SEX>
    <BIRT>
      <DATE>16 MAY 1967</DATE>
      <PLAC>Bishop's Stortford</PLAC>
      <NOTE>Born at 96 Colney Hatch Lane</NOTE>
    </BIRT>
    <FAMS REF="F1"></FAMS>
    <FAMC REF="F2"></FAMC>
    <DEAT>
      <DATE>12 JUL 2001</DATE>
      <PLAC>London</PLAC>
    </DEAT>
    <EVEN>
            Vitty
            <TYPE>AKA</TYPE></EVEN>
    <IMG>Vitty_Shimansky.jpg</IMG>
    <NOTE>
            \"My father\" [Henry's father, i.e. Arthur] told me that originally the
            <CONT>Birnbaums came from Spain. They went to Holland at the time of the</CONT><CONT>Spanish Inquisition, eventually adopting the Dutch/German name of</CONT><CONT>Birnbaum, and becoming Ashkenazi.</CONT><CONT>In an old Prayer book which I [HP] believe once belonged to Berl</CONT><CONT>Birnbaum I found a slip of paper. On it was written</CONT><CONT>'Rabbi Moses ben Naimon 1135-1204 Born Cordoba'</CONT><CONT>This was of course Moses Mamonides. It would be exciting if he was</CONT><CONT>indeed an ancestor. There is also a reference to Rabbi Schlaimoh</CONT><CONT>Yelchaki - born in france 1040 died 1105.</CONT></NOTE>
    <SOUR REF="S1"></SOUR>
    <EMIG>
      <PLAC>Emigrated to Bucharest</PLAC>
    </EMIG>
    <OCCU>
            Ship's Butcher on Australian line
            <PLAC>Dundee</PLAC></OCCU>

         */

        XmlNode MyNode;
        
        string ImageBase ;
        string BirthNote ;
        string DeathNote ;
        string Note ;
        GEDFileEntry Source ;

        public IndiEdit(XmlNode Node, String pImageBase)
        {
            InitializeComponent();
            MyNode = Node;
            ImageBase = pImageBase;
            ParseNodeToUIComponents(Node);
        }

        private void ParseNodeToUIComponents(XmlNode Node)
        {
            MyDate tmpDateTime;
            XmlNode tmpNode;

            pictureBox1.Image = pictureBox1.ErrorImage;

            foreach (XmlNode Child in Node.ChildNodes)
            {
                switch (Child.Name.ToUpper())
                {
                    case "NAME":
                        txtName.Text = Child.InnerText.Trim();
                        break;
                    case "SEX":
                        if (Child.InnerText == "M")
                            rdoMale.Checked = true;
                        else
                            rdoFemale.Checked = true;
                        break;
                    case "BIRT":
                        tmpDateTime = GEDXMLUtilites.ParseDate(Child);
                        if (tmpDateTime != MyDate.MinValue)
                        {
                            chkBirth.Checked = true;
                            txtBirthDate.Text = tmpDateTime.Day();
                            txtBirthMonth.Text = tmpDateTime.Month();
                            txtBirthYear.Text = tmpDateTime.Year();
                        }
                        else
                        {
                            chkBirth.Checked = false;
                        }
                        txtBirth.Text = GEDXMLUtilites.ParsePlace(Child);
                        BirthNote = GEDXMLUtilites.ParseNote(Child);
                        break;
                    case "DEAT":
                        tmpDateTime = GEDXMLUtilites.ParseDate(Child);
                        if (tmpDateTime != MyDate.MinValue)
                        {
                            chkDeath.Checked = true;
                            txtDeathDate.Text = tmpDateTime.Day();
                            txtDeathMonth.Text = tmpDateTime.Month();
                            txtDeathYear.Text = tmpDateTime.Year();
                        }
                        else
                        {
                            chkDeath.Checked = false;
                        }
                        txtDeath.Text = GEDXMLUtilites.ParsePlace(Child);
                        DeathNote = GEDXMLUtilites.ParseNote(Child);
                        break;
                    case "EVEN":
                        txtAKA.Text = GEDXMLUtilites.ParseText(Child);
                        break;
                    case "IMG":
                        txtImage.Text = Child.InnerText;
                        if (!LoadImage(txtImage.Text))
                            txtImage.Text = "" ;
                        break;
                    case "NOTE":
                        Note = Child.InnerText;
                        break;
                    case "SOUR":
                        try
                        {
                            string SourceID = Child.Attributes["REF"].Value;
                            tmpNode = GEDXMLUtilites.GlobalLocateNodeByID(SourceID, "SOUR", Child);
                            if (tmpNode != null)
                            {
                                Source = new GEDFileEntrySour();
                                Source.Node = tmpNode;
                                lblSource.Text = Source.DisplayName;
                            }
                        } catch (Exception) {}
                        break;
                    case "EMIG":
                        break;
                    case "OCCU":
                        break;
                    default:
                        break;
                }
            }
        }

        void UpdateAllFields(XmlNode Node)
        {
            XmlNode TmpNode;

            GEDXMLUtilites.UpdateSingleField("NAME", txtName.Text, Node);
            if (rdoMale.Checked)
                GEDXMLUtilites.UpdateSingleField("SEX", "M", Node);
            else
                GEDXMLUtilites.UpdateSingleField("SEX", "F", Node);

            if (chkBirth.Checked)
            {
                TmpNode = GEDXMLUtilites.UpdateSingleField("BIRT", GEDXMLUtilites.InsertEmpty, Node);
                MyDate tmpDate = new MyDate(txtBirthYear.Value.ToString(), txtBirthMonth.Text, txtBirthDate.Text);
                GEDXMLUtilites.UpdateSingleField("DATE", tmpDate.MedString(), TmpNode);
                GEDXMLUtilites.UpdateSingleField("PLAC", txtBirth.Text, TmpNode);
                GEDXMLUtilites.UpdateSingleField("NOTE", BirthNote, TmpNode);
            }
            else
            {
                GEDXMLUtilites.UpdateSingleField("BIRT", "", Node);
            }
            
            if (chkDeath.Checked)
            {
                TmpNode = GEDXMLUtilites.UpdateSingleField("DEAT", GEDXMLUtilites.InsertEmpty, Node);
                MyDate tmpDate = new MyDate(txtDeathYear.Value.ToString(), txtDeathMonth.Text, txtDeathDate.Text);
                GEDXMLUtilites.UpdateSingleField("DATE", tmpDate.MedString(), TmpNode);
                GEDXMLUtilites.UpdateSingleField("PLAC", txtDeath.Text, TmpNode);
                GEDXMLUtilites.UpdateSingleField("NOTE", DeathNote, TmpNode);
            }
            else
            {
                GEDXMLUtilites.UpdateSingleField("DEAT", "", Node);
            }
            if (txtAKA.Text != "")
            {
                TmpNode = GEDXMLUtilites.UpdateSingleField("EVEN", txtAKA.Text, Node);
                GEDXMLUtilites.UpdateSingleField("TYPE", "AKA", TmpNode);
            }
            GEDXMLUtilites.UpdateSingleField("IMG", txtImage.Text, Node);
            GEDXMLUtilites.UpdateSingleField("NOTE", Note, Node);

            if (Source != null)
            {
                TmpNode = GEDXMLUtilites.UpdateSingleField("SOUR", GEDXMLUtilites.InsertEmpty, Node);
                GEDXMLUtilites.SetAttribute("REF", Source.ID, TmpNode);
            }

                    //case "EMIG":
                    //    break;
                    //case "OCCU":
                    //    break;

        }

        private bool LoadImage(String FileName)
        {
            try
            {
                string ImgFile = Path.GetDirectoryName(ImageBase) + Path.DirectorySeparatorChar + Path.GetFileName(txtImage.Text);
                pictureBox1.Load(ImgFile);
                return true;
            }
            catch (Exception)
            {
                return false;
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

        private void cmdImage_Click(object sender, EventArgs e)
        {
            ofdFile.AddExtension = true;
            ofdFile.InitialDirectory = ImageBase;
            ofdFile.FileName = txtImage.Text;
            ofdFile.CheckPathExists = true;
            ofdFile.CheckFileExists = true;
            ofdFile.Multiselect = false;

            ofdFile.ShowDialog();

            txtImage.Text = Path.GetFileName(ofdFile.FileName);
            LoadImage(txtImage.Text);
        }

        private void cmdBirth_Click(object sender, EventArgs e)
        {
            NoteEdit NE = new NoteEdit();
            BirthNote = NE.ShowDialogAndReturnString(BirthNote);
        }

        private void cmdDeath_Click(object sender, EventArgs e)
        {
            NoteEdit NE = new NoteEdit();
            DeathNote = NE.ShowDialogAndReturnString(DeathNote);
        }

        private void cmdNote_Click(object sender, EventArgs e)
        {
            NoteEdit NE = new NoteEdit();
            Note = NE.ShowDialogAndReturnString(Note);
        }

        private void cmdSource_Click(object sender, EventArgs e)
        {
            ItemPicker IP = new ItemPicker();
            string ID;
            XmlNode tmpNode;

            if (Source == null)
                ID = IP.ShowDialogAndReturnString("", "SOUR");
            else
                ID = IP.ShowDialogAndReturnString(Source.ID, "SOUR");

            if (ID != "")
            {
                tmpNode = GEDXMLUtilites.GlobalLocateNodeByID(ID, "SOUR", MyNode);
                if (tmpNode != null)
                {
                    Source = new GEDFileEntrySour();
                    Source.Node = tmpNode;
                    lblSource.Text = Source.DisplayName;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void IndiEdit_Load(object sender, EventArgs e)
        {

        }

        private void cmdBirthPick_Click(object sender, EventArgs e)
        {
            if (mcDatePicker.Visible)
            {
                mcDatePicker.Visible = false;
                mcDatePicker.Tag = "";
            }
            else
            {
                mcDatePicker.Top = pnlBirth.Top + pnlBirth.Height;
                mcDatePicker.Left = pnlBirth.Left;
                MyDate tmpDate = new MyDate(txtBirthYear.Value.ToString(), txtBirthMonth.Text, txtBirthDate.Text);
                mcDatePicker.SelectionRange = new SelectionRange(tmpDate.ToDateTime(), tmpDate.ToDateTime());
                mcDatePicker.Visible = true;
                mcDatePicker.Tag = "B";
            }
        }

        private void chkBirth_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBirth.Checked)
            {
                txtBirthDate.Enabled = true;
                txtBirthMonth.Enabled = true;
                txtBirthYear.Enabled = true;
            }
            else
            {
                txtBirthDate.Enabled = false;
                txtBirthMonth.Enabled = false;
                txtBirthYear.Enabled = false;
            }
        }

        private void mcDatePicker_DateChanged(object sender, DateRangeEventArgs e)
        {
            MyDate D = new MyDate(mcDatePicker.SelectionStart);
            if (mcDatePicker.Tag.ToString() == "B")
            {
                txtBirthDate.Text = D.Day();
                txtBirthMonth.Text = D.Month();
                txtBirthYear.Text = D.Year();
            }
            else if (mcDatePicker.Tag.ToString() == "D")
            {
                txtDeathDate.Text = D.Day();
                txtDeathMonth.Text = D.Month();
                txtDeathYear.Text = D.Year();
            }
        }

        private void cmdDetahPick_Click(object sender, EventArgs e)
        {
            if (mcDatePicker.Visible)
            {
                mcDatePicker.Visible = false;
                mcDatePicker.Tag = "";
            }
            else
            {
                mcDatePicker.Top = pnlDeath.Top + pnlDeath.Height;
                mcDatePicker.Left = pnlDeath.Left;
                MyDate tmpDate = new MyDate(txtDeathYear.Value.ToString(), txtDeathMonth.Text, txtDeathDate.Text);
                mcDatePicker.SelectionRange = new SelectionRange(tmpDate.ToDateTime(), tmpDate.ToDateTime());
                mcDatePicker.Visible = true;
                mcDatePicker.Tag = "D";
            }
        }

        private void chkDeath_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeath.Checked)
            {
                txtDeathDate.Enabled = true;
                txtDeathMonth.Enabled = true;
                txtDeathYear.Enabled = true;
            }
            else
            {
                txtDeathDate.Enabled = false;
                txtDeathMonth.Enabled = false;
                txtDeathYear.Enabled = false;
            }

        }

    }
}
