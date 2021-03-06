﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GedXMLEdit
{
    static class GEDXMLUtilites
    {
        // Code to force UpdateSingleField to create empty element
        public const string InsertEmpty = "\0x1B";

        static public MyDate ParseDate(XmlNode Node)
        {
            foreach (XmlNode Child in Node.ChildNodes)
            {
                if (Child.Name.ToUpper() == "DATE")
                {
                    try
                    {
                        return MyDate.Parse(Child.InnerText);
                    }
                    catch (Exception)
                    {
                        return MyDate.MinValue;
                    }
                }
            }
            return MyDate.MinValue;
        }

        static public String ParsePlace(XmlNode Node)
        {
            //XmlNode titleNode = xmlDoc.SelectSingleNode("//rss/channel/title");
            // root["title"]

            foreach (XmlNode Child in Node.ChildNodes)
            {
                if (Child.Name.ToUpper() == "PLAC")
                    return Child.InnerText;
            }
            return "";
        }

        static public String ParseNote(XmlNode Node)
        {
            //XmlNode titleNode = xmlDoc.SelectSingleNode("//rss/channel/title");
            // root["title"]

            foreach (XmlNode Child in Node.ChildNodes)
            {
                if (Child.Name.ToUpper() == "NOTE")
                    return Child.InnerText;
            }
            return "";
        }

        static public String ParseText(XmlNode Node)
        {
            foreach (XmlNode Child in Node.ChildNodes)
            {
                if (Child.NodeType == XmlNodeType.Text)
                    return Child.InnerText;
            }
            return "";
        }

        static public void ParseCompoundDate(XmlNode Child, MyDatePicker Picker)
        {
            MyDate tmpDateTime;
            tmpDateTime = GEDXMLUtilites.ParseDate(Child);
            if (tmpDateTime != MyDate.MinValue)
            {
                Picker.Checked = true;
                Picker.Date = tmpDateTime;
            }
            else
            {
                Picker.Checked = false;
            }
            Picker.Place = GEDXMLUtilites.ParsePlace(Child);
            Picker.Note = GEDXMLUtilites.ParseNote(Child);
        }

        static public XmlNode UpdateSingleField(String Field, String Value, XmlNode Node)
        {
            XmlNode ChildNode = null;

            if (Value == null)
                Value = "";
            else
                Value = Value.Trim();

            if (Value == "")
            {
                // Value blank - ensure node doesn't exist
                foreach (XmlNode Child in Node.ChildNodes)
                {
                    if (Child.Name.ToUpper() == Field)
                        Node.RemoveChild(Child);
                }
            }
            else
            {
                // Value not blank - ensure node does exist
                foreach (XmlNode Child in Node.ChildNodes)
                {
                    if (Child.Name.ToUpper() == Field)
                    {
                        ChildNode = Child;
                        break;
                    }
                }
                // not found, create it...
                if (ChildNode == null)
                {
                    ChildNode = Node.OwnerDocument.CreateElement(Field);
                    Node.AppendChild(ChildNode);
                }
                if (Value != InsertEmpty)
                    ChildNode.InnerText = Value;
            }
            return ChildNode;
        }

        static public XmlNode SetAttribute(string Field, string ID, XmlNode Node)
        {
            XmlAttribute ChildNode = null;

            if (ID == "")
            {
                // Value blank - ensure node doesn't exist
                foreach (XmlAttribute Child in Node.Attributes)
                {
                    if (Child.Name.ToUpper() == Field)
                        Node.Attributes.Remove(Child);
                }
            }
            else
            {
                // Value not blank - ensure node does exist
                foreach (XmlAttribute Child in Node.Attributes)
                {
                    if (Child.Name.ToUpper() == Field)
                    {
                        ChildNode = Child;
                        break;
                    }
                }
                // not found, create it...
                if (ChildNode == null)
                {
                    ChildNode = Node.OwnerDocument.CreateAttribute(Field);
                    Node.Attributes.Append(ChildNode);
                }
                ChildNode.Value = ID;
            }
            return ChildNode;
        }

        static public XmlNode UpdateMultipleFieldAttr(String Field, String Attr, String[] Values, XmlNode Node)
        {
            XmlNode ChildNode = null;
            XmlAttribute ChildNodeAttr = null;

            // Remove all nodes of type
            for (int i = Node.ChildNodes.Count - 1; i >= 0; i--)
            {
                if (Node.ChildNodes[i].Name.ToUpper() == Field.ToUpper())
                    Node.RemoveChild(Node.ChildNodes[i]);
            }

            foreach(string Value in Values)
            {
                ChildNode = Node.OwnerDocument.CreateElement(Field);
                Node.AppendChild(ChildNode);
                ChildNodeAttr = ChildNode.OwnerDocument.CreateAttribute(Attr);
                ChildNode.Attributes.Append(ChildNodeAttr);
                ChildNodeAttr.Value = Value;
            }
            return ChildNode;
        }

        static public XmlNode UpdateCompoundDateField(string Field, MyDatePicker DatePicker, XmlNode Node)
        {
            if (DatePicker.Checked)
            {
                XmlNode TmpNode = GEDXMLUtilites.UpdateSingleField(Field, GEDXMLUtilites.InsertEmpty, Node);
                GEDXMLUtilites.UpdateSingleField("DATE", DatePicker.Date.MedString(), TmpNode);
                GEDXMLUtilites.UpdateSingleField("PLAC", DatePicker.Place, TmpNode);
                GEDXMLUtilites.UpdateSingleField("NOTE", DatePicker.Note, TmpNode);
                return TmpNode;
            }
            else
            {
                return GEDXMLUtilites.UpdateSingleField(Field, "", Node);
            }

        }

        static public XmlNode GlobalLocateNodeByID(string ID, string NodeType, XmlNode Node)
        {
            XmlNode FoundNode = null;

            FoundNode = Node.OwnerDocument.SelectSingleNode("*/" + NodeType + "[@ID=\"" + ID + "\"]");

            return FoundNode ;
        }
    }
}
