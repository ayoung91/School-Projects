using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Young_Program4
{
    public partial class frmChild : Form
    {
        public frmChild()
        {
            InitializeComponent();
        }

        private void frmChild_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Would you like to save changes?", "", MessageBoxButtons.YesNoCancel);

            if (dlg == DialogResult.Yes)
            {
                SaveMyFile();
                e.Cancel = false;
            }

            else if (dlg == DialogResult.No)
            {
                e.Cancel = false;
            }

            else if (dlg == DialogResult.Cancel)
            {
                e.Cancel = true;

            }
        }


        public void SaveMyFile()
        {
            // Create a SaveFileDialog to request a path and file name to save to.
            SaveFileDialog saveFile1 = new SaveFileDialog();

            // Initialize the SaveFileDialog to specify the RTF extension for the file.
            saveFile1.DefaultExt = "*.rtf";
            saveFile1.Filter = "RTF Files|*.rtf|Text files (*.txt)|*.txt|All files (*.*)|*.*";

            // Determine if the user selected a file name from the saveFileDialog.
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               saveFile1.FileName.Length > 0)
            {
                // Save the contents of the RichTextBox into the file.
                rchRichTextBox.SaveFile(saveFile1.FileName, RichTextBoxStreamType.PlainText);
            }
        }

    }
}
