using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GedXMLEdit
{
    public partial class MyDatePicker : UserControl
    {
        private MyDate pDate;
        private string pNote;

        public MyDatePicker ()
        {
            InitializeComponent();
            pDate = new MyDate(DateTime.MinValue);
        }

        public MyDate Date 
        {
            get { return pDate; }
            set { 
                pDate = value ; 
                txtDate.Text = pDate.day;
                txtMonth.Text = pDate.month;
                txtYear.Text = pDate.year;
            }
        }

        public Boolean Checked {
            get { return chkEnabled.Checked; }
            set { chkEnabled.Checked = value; }
        }

        public string Note
        {
            get { return pNote; }
            set
            {
                pNote = value;
                //                if (pNote != "")
                //                    cmdNote.x;
                //                else ;
            }
        }

        public string Place
        {
            get { return txtPlace.Text; }
            set { txtPlace.Text = value; }
        }

        public override string Text 
        {
            get { return pDate.MedString(); }
            set { pDate = MyDate.Parse(value); }
        }

        private void MyDatePicker_Load(object sender, EventArgs e)
        {
            cmdPick_Click(null, null);
            chkEnabled_CheckedChanged(null, null);
        }

        private void cmdPick_Click(object sender, EventArgs e)
        {
            this.Width = cmdNote.Left + cmdNote.Width + chkEnabled.Left;
            if (calPick.Visible)
            {
                calPick.Visible = false;
                this.Height = (3 * pnlDate.Top) + pnlDate.Height;
            }
            else
            {
                calPick.Visible = true;
                calPick.Top = pnlDate.Top + pnlDate.Height;
                calPick.Left = chkEnabled.Left;
                this.Height = calPick.Top + calPick.Height + calPick.Left;

                calPick.SelectionRange = new SelectionRange(pDate.ToDateTime(), pDate.ToDateTime());
            }

        }

        private void chkEnabled_CheckedChanged(object sender, EventArgs e)
        {
                txtDate.Enabled = chkEnabled.Checked;
                txtMonth.Enabled = chkEnabled.Checked;
                txtYear.Enabled = chkEnabled.Checked;
                txtPlace.Enabled = chkEnabled.Checked;
                cmdPick.Enabled = chkEnabled.Checked;
                cmdNote.Enabled = chkEnabled.Checked;
        }

        private void txtDate_TextChanged(object sender, EventArgs e)
        {
            pDate.day = txtDate.Text ;
        }

        private void txtMonth_TextChanged(object sender, EventArgs e)
        {
            pDate.month = txtMonth.Text;
        }

        private void txtYear_ValueChanged(object sender, EventArgs e)
        {
            pDate.year = txtYear.Value.ToString();
        }

        private void calPick_DateChanged(object sender, DateRangeEventArgs e)
        {
            MyDate D = new MyDate(calPick.SelectionStart);
            this.Date = D;
        }

        private void cmdNote_Click(object sender, EventArgs e)
        {
            NoteEdit NE = new NoteEdit();
            Note = NE.ShowDialogAndReturnString(Note);
        }
    }
}
