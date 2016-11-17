using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml ;
using System.Windows.Forms;

namespace GedXMLEdit
{

    public class GEDFile
    {
        private List<GEDFileEntry> Entries = new List<GEDFileEntry>() ;

        public GEDFile(XmlDocument Doc)
        {
            GEDFileEntry Entry ;
            // Top level nodes are "Head", "Subm", "Indi", "Fam", "Sour"
            foreach(XmlNode Node in Doc.DocumentElement.ChildNodes) 
            {
                Entry = null;

                switch (Node.Name.ToUpper())
                {
                    case "HEAD":
                        Entry = new GEDFileEntryHead() ;
                        break ;
                    case "SUBM":
                        Entry = new GEDFileEntrySubm();
                        break;
                    case "INDI":
                        Entry = new GEDFileEntryIndi();
                        break;
                    case "FAM":
                        Entry = new GEDFileEntryFam();
                        break;
                    case "SOUR":
                        Entry = new GEDFileEntrySour();
                        break;
                    default:
                        
                    frmGEDXmlEditor.Log("Node type not recognised: " + Node.Name);
                        break ;
                }
                if (Entry != null)
                {
                    Entry.Node = Node;
                    Entries.Add(Entry);
                }
            }
            
            // Now, for each family, cross-reference individuals
            foreach (GEDFileEntry FEntry in Entries)
            {
                if (FEntry.ListType() == "FAM")
                {
                    ((GEDFileEntryFam)FEntry).ResolveXrefs();
                }
            }
        }

        public static bool IsGedXMLFile(XmlDocument Doc)
        {
            if (Doc.DocumentElement.Name == "GED")
                return true;
            else
                return false; 
        }

        internal void Display(System.Windows.Forms.ListBox lstItems, string Type)
        {
            lstItems.Items.Clear();

            foreach (GEDFileEntry Entry in Entries)
            {
                if (Type == "OTHER")
                {
                    if((Entry.ListType() == "SOUR") || (Entry.ListType() == "SUBM") || (Entry.ListType() == "HEAD"))
                        lstItems.Items.Add(Entry);
                }
                else if (Type == Entry.ListType())
                    lstItems.Items.Add(Entry);
            }
        }
    }

    class GEDFileEntry
    {
        //public String Type;
        public String ID;
        public String DisplayName;
        public String ImageBase;
        protected XmlNode pNode;

        public XmlNode Node 
        {
            get
            {
                return pNode;
            }
            set
            {
                pNode = value;
                ParseNode(pNode);
            }
        }

        virtual public string ListType()
        {
            return "OTHER";
        }

        override public string ToString()
        {
            return DisplayName;
        }

        virtual protected void ParseNode(XmlNode vNode)
        {
            ID = "";
            DisplayName = "";
        }

        virtual public void Edit()
        {
            MessageBox.Show(DisplayName, "Unable to Edit Item", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    class GEDFileEntryHead : GEDFileEntry
    {
        override protected void ParseNode(XmlNode vNode)
        {
            ID = "";
            DisplayName = "<Header>";
        }

        override public string ListType()
        {
            return "HEAD";
        }
    }

    class GEDFileEntrySubm : GEDFileEntry
    {
        override protected void ParseNode(XmlNode vNode)
        {
            ID = vNode.Attributes.GetNamedItem("ID").Value;
            DisplayName = "?";
            foreach (XmlNode Child in vNode.ChildNodes)
            {
                if (Child.Name.ToUpper() == "NAME")
                    DisplayName = "Submitter: " + Child.InnerText;
            }
        }

        override public string ListType()
        {
            return "SUBM";
        }
    }

    class GEDFileEntryIndi : GEDFileEntry
    {
        override protected void ParseNode(XmlNode vNode)
        {
            ID = vNode.Attributes.GetNamedItem("ID").Value;
            DisplayName = "?";
            foreach (XmlNode Child in vNode.ChildNodes)
            {
                if (Child.Name.ToUpper() == "NAME")
                    DisplayName = Child.InnerText.Trim(); 
            }
        }

        override public string ListType()
        {
            return "INDI";
        }


        override public void Edit()
        {
            IndiEdit EditDialog = new IndiEdit(pNode, ImageBase);

            EditDialog.ShowDialog();
        }
    }

    class GEDFileEntryFam : GEDFileEntry
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
        GEDFileEntry Husb;
        GEDFileEntry Wife;

        override protected void ParseNode(XmlNode vNode)
        {
            ID = vNode.Attributes.GetNamedItem("ID").Value;
            DisplayName = ID;
        }

        override public string ListType()
        {
            return "FAM";
        }

        public void ResolveXrefs()
        {
            XmlNode tmpNode ;

            foreach (XmlNode Child in pNode.ChildNodes)
            {
                switch (Child.Name.ToUpper())
                {
                    case "HUSB":
                        try
                        {
                            string SourceID = Child.Attributes["REF"].Value;
                            tmpNode = GEDXMLUtilites.GlobalLocateNodeByID(SourceID, "INDI", Child);
                            if (tmpNode != null)
                            {
                                Husb = new GEDFileEntryIndi();
                                Husb.Node = tmpNode;
                            }
                        }
                        catch (Exception ex) { }
                        break;
                    case "WIFE":
                        try
                        {
                            string SourceID = Child.Attributes["REF"].Value;
                            tmpNode = GEDXMLUtilites.GlobalLocateNodeByID(SourceID, "INDI", Child);
                            if (tmpNode != null)
                            {
                                Wife = new GEDFileEntryIndi();
                                Wife.Node = tmpNode;
                            }
                        }
                        catch (Exception ex) { }
                        break;
                    default:
                        break;
                }
            }
            if (Husb != null)
            {
                if (Wife != null)
                    DisplayName = Husb.DisplayName + " + " + Wife.DisplayName;
                else
                    DisplayName = Husb.DisplayName + " + ?";
            }
            else
            {
                if (Wife != null)
                    DisplayName = "? + " + Wife.DisplayName;
                else
                    DisplayName = "? + ?" + ID;
            }
        }
    }

    class GEDFileEntrySour : GEDFileEntry
    {
  //<SOUR ID="S1">
  //  <ABBR>HP</ABBR>
  //  <TITL>Folder preapred by Henry Poirier</TITL>
  //  <AUTH>Henry Poirier</AUTH>
  //</SOUR>

        override protected void ParseNode(XmlNode vNode)
        {
            ID = vNode.Attributes.GetNamedItem("ID").Value;
            DisplayName = "?";
            foreach (XmlNode Child in vNode.ChildNodes)
            {
                if (Child.Name.ToUpper() == "AUTH")
                    DisplayName = Child.InnerText;
            }
        }

        override public string ListType()
        {
            return "SOUR";
        }
    }


}
