using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MovieBoxOffice
{
    

    public partial class Form1 : Form
    {
        //STATIC GLOBALS
        static double MATINEE_DISCOUNT = 3.5;
        static double TICKET_PRICE = 5.0;

        // VARS
        bool MatineeDiscount;
        int NumberOfTickets;
        
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboMovie.Items[0] = "";
            cboMovie.Items[1] = "Gone with the Wind";
            cboMovie.Items[2] = "Psycho";
            cboMovie.Items[3] = "North by Northwest";
            cboMovie.Items[4] = "Exodus";
        }

        private void chkMatinee_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMatinee.Checked)
            {
                MatineeDiscount = true;
                lstAmount.Items.Clear();
                lstAmount.Items.Add("Matinee Discount Applied!");
            }
            else
            {
                MatineeDiscount = false;
                lstAmount.Items.Clear();
                lstAmount.Items.Add("Matinee Discount Removed!");
            }
        }

        private string CalcTicketPrice(RadioButton selection)
        {
            if (MatineeDiscount)
                return (Convert.ToDouble(selection.Text) * MATINEE_DISCOUNT).ToString();

            return (Convert.ToDouble(selection.Text) * TICKET_PRICE).ToString();
        }

        private void rb1_Click(object sender, EventArgs e)
        {
            NumberOfTickets = 1;
            lstAmount.Items.Clear();
            lstAmount.Items.Add(CalcTicketPrice(rb1));
        }

        private void rb2_Click(object sender, EventArgs e)
        {
            NumberOfTickets = 2;
            lstAmount.Items.Clear();
            lstAmount.Items.Add(CalcTicketPrice(rb2));
        }

        private void rb3_Click(object sender, EventArgs e)
        {
            NumberOfTickets = 3;
            lstAmount.Items.Clear();
            lstAmount.Items.Add(CalcTicketPrice(rb3));
        }

        private void rb4_Click(object sender, EventArgs e)
        {
            NumberOfTickets = 4;
            lstAmount.Items.Clear();
            lstAmount.Items.Add(CalcTicketPrice(rb4));
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            lstRecord.Items.Add(NumberOfTickets + " " + cboMovie.Text);
            cboMovie.SelectedIndex = 0;
            chkMatinee.Checked = false;
            lstAmount.Text = " ";
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
