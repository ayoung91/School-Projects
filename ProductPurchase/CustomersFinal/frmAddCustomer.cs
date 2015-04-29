using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Customers_DataAccess;

namespace addCustomer
{
    public partial class frmAddCustomer : Form
    {
        public frmAddCustomer()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Customer add = new Customer();
            add.first_name = txtFirstName.Text;
            add.last_name = txtLastName.Text;
            add.address_1 = txtAddress1.Text;
            add.address_2 = txtAddress2.Text;
            add.City = txtCity.Text;
            add.State = cbxState.Text;
            add.Zip = txtZip.Text;

            Customers_DataAccess.Customers_provider.addCustomer(add);
            this.DialogResult = DialogResult.OK;
        }

        
    }
}
