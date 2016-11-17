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
    public partial class NoteEdit : Form
    {
        string mNote;
        public NoteEdit()
        {
            InitializeComponent();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            mNote = txtNote.Text;
            this.Close();
        }

        public string ShowDialogAndReturnString(string Note)
        {
            mNote = Note;
            txtNote.Text = Note;
            this.ShowDialog();
            return mNote;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
