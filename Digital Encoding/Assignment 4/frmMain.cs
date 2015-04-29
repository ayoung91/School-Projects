using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_4
{
    public partial class frmMain : Form
    {
        public string result;
        public frmMain()
        {
            InitializeComponent();
            cboEncoding.SelectedIndex = 0;
        }

        private void rdoBinary_CheckedChanged(object sender, EventArgs e)
        {
            lblInput.Text        = "Input binary string:";
            txtInput.Visible     = true;
            lblBinaryString.Text = "";
            btnConvert.Visible   = false;
        }

        private void rdoText_CheckedChanged(object sender, EventArgs e)
        {
            lblInput.Text      = "Input text string:";
            lblInput.Visible   = true;
            btnConvert.Visible = true;
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {   //Converts text string into a binary string
            string input        = txtInput.Text;
            string binaryResult = string.Empty;

            foreach(char ch in input)
            {
                binaryResult += Convert.ToString((int)ch, 2);
            }

            lblBinaryString.Text = binaryResult;
            btnGraph.Visible = true;            
        }

        private void btnGraph_Click(object sender, EventArgs e)
        {
            NRZL nrzl;
            NRZI nrzi;
            BipolarAMI bi;
            Pseudo p;
            Manchester man;
            DiffMan diffman;
            B8ZS b8zs;
            HDB3 hdb3;

            int caseSwitch = 0;

            if (rdoBinary.Checked == true && cboEncoding.SelectedIndex.Equals(0))
            {
                caseSwitch = 1;
            }
            else if (rdoBinary.Checked == false && cboEncoding.SelectedIndex.Equals(0))
            {
                caseSwitch = 2;
            }
            else if (rdoBinary.Checked == true && cboEncoding.SelectedIndex.Equals(1))
            {
                caseSwitch = 3;
            }
            else if (rdoBinary.Checked == false && cboEncoding.SelectedIndex.Equals(1))
            {
                caseSwitch = 4;
            }
            else if (rdoBinary.Checked == true && cboEncoding.SelectedIndex.Equals(2))
            {
                caseSwitch = 5;
            }
            else if (rdoBinary.Checked == false && cboEncoding.SelectedIndex.Equals(2))
            {
                caseSwitch = 6;
            }
            else if (rdoBinary.Checked == true && cboEncoding.SelectedIndex.Equals(3))
            {
                caseSwitch = 7;
            }
            else if (rdoBinary.Checked == false && cboEncoding.SelectedIndex.Equals(3))
            {
                caseSwitch = 8;
            }
            else if (rdoBinary.Checked == true && cboEncoding.SelectedIndex.Equals(4))
            {
                caseSwitch = 9;
            }
            else if (rdoBinary.Checked == false && cboEncoding.SelectedIndex.Equals(4))
            {
                caseSwitch = 10;
            }
            else if (rdoBinary.Checked == true && cboEncoding.SelectedIndex.Equals(5))
            {
                caseSwitch = 11;
            }
            else if (rdoBinary.Checked == false && cboEncoding.SelectedIndex.Equals(5))
            {
                caseSwitch = 12;
            }
            else if (rdoBinary.Checked == true && cboEncoding.SelectedIndex.Equals(6))
            {
                caseSwitch = 13;
            }
            else if (rdoBinary.Checked == false && cboEncoding.SelectedIndex.Equals(6))
            {
                caseSwitch = 14;
            }
            else if (rdoBinary.Checked == true && cboEncoding.SelectedIndex.Equals(7))
            {
                caseSwitch = 15;
            }
            else if (rdoBinary.Checked == false && cboEncoding.SelectedIndex.Equals(7))
            {
                caseSwitch = 16;
            }

            switch (caseSwitch)
            {
                //NRZL
                case 1:      
                    nrzl = new NRZL(txtInput.Text); 
                    result = nrzl.getResult().ToString();
                    lblScheme.Text = "NRZL:";
                    break;
                case 2:
                    nrzl = new NRZL(lblBinaryString.Text);
                    result = nrzl.getResult().ToString();
                    lblScheme.Text = "NRZL:";
                    break;
                //NRZI
                case 3:
                     nrzi = new NRZI(txtInput.Text);
                    result = nrzi.getResult().ToString();
                    lblScheme.Text = "NRZI:";
                    break;
                case 4:
                    nrzi = new NRZI(lblBinaryString.Text);
                    result = nrzi.getResult().ToString();
                    lblScheme.Text = "NRZI:";
                    break;
                //Bipolar-AMI
                case 5:
                    bi = new BipolarAMI(txtInput.Text);
                    result = bi.getResult().ToString();
                    lblScheme.Text = "Bipolar-AMI:";
                    break;
                case 6:
                    bi = new BipolarAMI(lblBinaryString.Text);
                    result = bi.getResult().ToString();
                    lblScheme.Text = "Bipolar-AMI:";
                    break;
                //Pseudoternary
                case 7:
                    p = new Pseudo(txtInput.Text);
                    result = p.getResult().ToString();
                    lblScheme.Text = "Pseudoternary:";
                    break;
                case 8:
                    p = new Pseudo(lblBinaryString.Text);
                    result = p.getResult().ToString();
                    lblScheme.Text = "Pseudoternary:";
                    break;
                //Manchester
                case 9:
                    man = new Manchester(txtInput.Text);
                    result = man.getResult().ToString();
                    lblScheme.Text = "Manchester:";
                    break;
                case 10:
                    man = new Manchester(lblBinaryString.Text);
                    result = man.getResult().ToString();
                    lblScheme.Text = "Manchester:";
                    break;
                //Differential Manchester
                case 11:
                    diffman = new DiffMan(txtInput.Text);
                    result = diffman.getResult().ToString();
                    lblScheme.Text = "Differential Manchester:";
                    break;
                case 12:
                    diffman = new DiffMan(lblBinaryString.Text);
                    result = diffman.getResult().ToString();
                    lblScheme.Text = "Differential Manchester:";
                    break;
                //B8ZS
                case 13:
                    b8zs = new B8ZS(txtInput.Text);
                    result = b8zs.getResult().ToString();
                    lblScheme.Text = "B8ZS:";
                    break;
                case 14:
                    b8zs = new B8ZS(lblBinaryString.Text);
                    result = b8zs.getResult().ToString();
                    lblScheme.Text = "B8ZS:";
                    break;
                //HDB3
                case 15:
                    hdb3 = new HDB3(txtInput.Text);
                    result = hdb3.getResult().ToString();
                    lblScheme.Text = "HDB3:";
                    break;
                case 16:
                    hdb3 = new HDB3(lblBinaryString.Text);
                    result = hdb3.getResult().ToString();
                    lblScheme.Text = "HDB3:";
                    break;
            }
            drawGraph();
            drawWave();
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            //User Validation: Check binary input for characters other than "1" or "0"
            if (txtInput.Text != "")            
                if (rdoBinary.Checked == true)                
                    for (int i = 0; i < txtInput.Text.Length; i++)
                    {
                        if (txtInput.Text.Substring(i, 1) != "1" && txtInput.Text.Substring(i, 1) != "0")
                        {
                            MessageBox.Show("You must enter a binary string of ones and zeros.");
                            btnGraph.Visible = false;
                        }
                        else
                            btnGraph.Visible = true;
                    }

        }

        //Draws the graph without digital frequency wave
        public void drawGraph()
        {
            int i = 0;
            int len = 150;
            int x = 150;
            Pen pen = new Pen(Color.Black);
            Graphics g = this.CreateGraphics();

            g.DrawLine(pen, 100, 250, 10000, 250);

            for (i = 0; i < 10000; i++)
            {
                g.DrawLine(pen, x, 200, x, 300);
                x += 50;
            }
           
            pen.Dispose();
            g.Dispose();
        }

        //Draws the digital frequency wave
        public void drawWave()
        {
            int i = 0;
            int x1 = 100;
            int x2 = 125;
            Pen pen = new Pen(Color.Red, 3);
            Graphics g = this.CreateGraphics();

            g.Clear(Control.DefaultBackColor);
            drawGraph();

            if (cboEncoding.SelectedIndex == 4 || cboEncoding.SelectedIndex == 5)
            {
                x1 += 25;
                x2 += 25;
            }

            for (i = 0; i < result.Length; i++)
            {
                if (result.Substring(i, 1) == "+")
                {
                    g.DrawLine(pen, x1, 225, x2, 225);
                    x1 += 25;
                    x2 += 25;
                }
                else if (result.Substring(i, 1) == "-")
                {
                    g.DrawLine(pen, x1, 275, x2, 275);
                    x1 += 25;
                    x2 += 25;
                }
                else if (result.Substring(i, 1) == "_")
                { 
                    g.DrawLine(pen, x1, 250, x2, 250);
                    x1 += 25;
                    x2 += 25;
                }
                else
                {
                    try
                    {
                        if (result.Substring(i, 1) == "|" && result.Substring(i - 1 , 1) == "+")
                        {
                            x2 -= 25;
                            g.DrawLine(pen, x1, 224, x2, 251);
                            x2 += 25;
                        }
                        else if (result.Substring(i, 1) == "|" && result.Substring(i - 1, 1) == "|")
                        {
                            x2 -= 25;
                            g.DrawLine(pen, x1, 224, x2, 277);
                            x2 += 25;
                        }
                        else
                        {
                            if (result.Substring(i + 1, 1) == "-")
                            { 
                                x2 -= 25;
                                g.DrawLine(pen, x1, 249, x2, 277);
                                x2 += 25;
                            }
                            else if (result.Substring(i + 1, 1) == "_")
                            {
                                x2 -= 25;
                                g.DrawLine(pen, x1, 249, x2, 277);
                                x2 += 25;
                            }
                            else
                            {
                                x2 -= 25;
                                g.DrawLine(pen, x1, 251, x2, 224);
                                x2 += 25;
                            }
                        }
                    }
                    catch
                    {

                    }
                }
            }
            pen.Dispose();
            g.Dispose();
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (txtInput.Text != "")
            {
                drawGraph();
                drawWave();
            }
            else
                drawGraph();
        }
    }
}
