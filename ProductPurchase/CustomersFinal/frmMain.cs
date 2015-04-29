using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using addCustomer;
using searchCustomer;
using Customers_DataAccess;


namespace CustomersFinal
{
    public partial class frmMain : Form
    {       
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Form Login = new frmLogin();
            Login.ShowDialog();
            DialogResult res = Login.DialogResult;
            if (res == DialogResult.OK)
            {

            }
            else
            {
                this.Close();
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Form> openForms = new List<Form>();
            foreach (Form f in Application.OpenForms)
                openForms.Add(f);

            foreach (Form f in openForms)
            {
                if (f != this)
                    f.Close();
            }

            this.frmMain_Load(sender, e);
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddCustomer adding = new frmAddCustomer();

            if (adding.ShowDialog() == DialogResult.OK)
                adding.Close();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSearchCustomer searching = new frmSearchCustomer();

            if (searching.ShowDialog() == DialogResult.OK)
                searching.Close();
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Customers_DataAccess.Customer> all = new List<Customer>();
            all = Customers_DataAccess.Customers_provider.allCustomers();
            dataGridView1.DataSource = all;
        }
    }
}
