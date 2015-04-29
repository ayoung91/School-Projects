using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Young_Program4
{
    public partial class frmMain : Form 
    {
        private int Count = 1;
        public frmMain()
        {
            InitializeComponent();
        }

        //File--------------------------------------------------------------- 
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChild child = new frmChild();
            child.Text = "Untitled " + Count;
            child.MdiParent = this;
            child.Show();
            Count++;
        }
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveMdiChild.Close();
        }
        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                foreach (Form children in this.MdiChildren)
                    children.Close();
            }
            
        } 
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChild child = new frmChild();
            child.MdiParent = this;
            child.Show();

            Form activeChild = this.ActiveMdiChild;

            if (activeChild != null)
            {            
                RichTextBox theBox = (RichTextBox)activeChild.ActiveControl;
                if (theBox != null)
                {
                    // Create an OpenFileDialog to request a file to open.
                    OpenFileDialog openFile1 = new OpenFileDialog();

                    // Initialize the OpenFileDialog to look for RTF files.
                    openFile1.DefaultExt = "*.rtf";
                    openFile1.Filter = "RTF Files|*.rtf|Text files (*.txt)|*.txt|All files (*.*)|*.*";

                    // Determine whether the user selected a file from the OpenFileDialog.
                    if (openFile1.ShowDialog() == DialogResult.OK &&
                       openFile1.FileName.Length > 0)
                    {
                        // Load the contents of the file into the RichTextBox.
                        theBox.LoadFile(openFile1.FileName, RichTextBoxStreamType.PlainText);
                        child.Text = openFile1.FileName;                     
                    }
                }                
            }
        }
        private void saveCtrlSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;

            if (activeChild != null)
            {

                RichTextBox theBox = (RichTextBox)activeChild.ActiveControl;
                if (theBox != null)
                {
                    // Create a SaveFileDialog to request a path and file name to save to.
                   SaveFileDialog saveFile1 = new SaveFileDialog();

                   // Initialize the SaveFileDialog to specify the RTF extension for the file.
                   saveFile1.DefaultExt = "*.rtf";
                   saveFile1.Filter = "RTF Files|*.rtf|Text files (*.txt)|*.txt|All files (*.*)|*.*";

                   // Determine if the user selected a file name from the saveFileDialog.
                   if(saveFile1.ShowDialog() == DialogResult.OK &&
                      saveFile1.FileName.Length > 0) 
                   {
                      // Save the contents of the RichTextBox into the file.
                      theBox.SaveFile(saveFile1.FileName, RichTextBoxStreamType.PlainText);
                   }
                }   
                
            }
        }

        //Edit---------------------------------------------------------------
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            Form activeChild = this.ActiveMdiChild;

            if (activeChild != null)
            {
                RichTextBox theBox = (RichTextBox)activeChild.ActiveControl;
                if (theBox != null)
                {
                    theBox.Cut();
                }               
            }
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    Form activeChild = this.ActiveMdiChild;

                    if (activeChild != null)
                    {
                        RichTextBox theBox = (RichTextBox)activeChild.ActiveControl;
                        if (theBox != null)
                        {
                            IDataObject data = Clipboard.GetDataObject();
                            if (data.GetDataPresent(DataFormats.Text))
                            {
                                //theBox.SelectedText = data.GetData(DataFormats.Text).ToString();
                                theBox.Paste();
                            }
                        }
                    }
                }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {         
            Form activeChild = this.ActiveMdiChild;
                       
            if (activeChild != null)
            {               
                RichTextBox theBox = (RichTextBox)activeChild.ActiveControl;
                if (theBox != null)
                {
                    //Clipboard.SetDataObject(theBox.SelectedText);
                    theBox.Copy();
                }
            }
        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;


            if (activeChild != null)
            {
                RichTextBox theBox = (RichTextBox)activeChild.ActiveControl;
                if (theBox != null)
                {
                    theBox.SelectAll();
                }
            }
        }

        //Format-------------------------------------------------------------
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;


            if (activeChild != null)
            {
                RichTextBox theBox = (RichTextBox)activeChild.ActiveControl;
                if (theBox != null)
                {                 
                    fontDialog1.ShowColor = true;

                    if (theBox.SelectedText != "")
                    {
                        //Next two lines are not needed
                        fontDialog1.Font = theBox.SelectionFont;
                        fontDialog1.Color = theBox.ForeColor;
                        
                        try
                        {
                            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
                            {
                                theBox.SelectionFont = fontDialog1.Font;
                                theBox.ForeColor = fontDialog1.Color;
                            }
                        }
                        catch
                        {
                            theBox.SelectionFont = fontDialog1.Font;
                            theBox.ForeColor = fontDialog1.Color;
                        }
                    }
                }
            }

        }
        private void leftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;


            if (activeChild != null)
            {
                RichTextBox theBox = (RichTextBox)activeChild.ActiveControl;
                if (theBox != null)
                {
                    theBox.SelectionAlignment = HorizontalAlignment.Left;
                }
            }
        }   
        private void rightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;


            if (activeChild != null)
            {
                RichTextBox theBox = (RichTextBox)activeChild.ActiveControl;
                if (theBox != null)
                {
                    theBox.SelectionAlignment = HorizontalAlignment.Right;
                }
            }
        }
        private void centerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;


            if (activeChild != null)
            {
                RichTextBox theBox = (RichTextBox)activeChild.ActiveControl;
                if (theBox != null)
                {
                    theBox.SelectionAlignment = HorizontalAlignment.Center;
                }
            }
        }

        //About--------------------------------------------------------------
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //not implemented
             
        }
        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAbout about = new frmAbout();
            about.Show();
        }

        
    }
}
