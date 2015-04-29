using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Customers_DataAccess;
using CustomersFinal;

namespace searchCustomer
{
    public partial class frmSearchCustomer : Form
    {
        public frmSearchCustomer()
        {
            InitializeComponent();
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            int i;
            bool good = Int32.TryParse(txtCustomerID.Text, out i);
            
            Customers_DataAccess.Customer search = new Customers_DataAccess.Customer();

            if (good == true)
            {
                search.CustomerID = Convert.ToInt32(txtCustomerID.Text);

                List<Customer> customer1 = new List<Customer>();
                customer1 = Customers_DataAccess.Customers_provider.searchByID(search.CustomerID);
                dataGridView1.DataSource = customer1;
            }
            else if(txtCustomerID.Text.Length != 0 && good == false)
            {
                MessageBox.Show("CustomerID must be an Integer!");
            }
            if (txtCustomerID.Text.Length == 0 && txtFirstName.Text.Length != 0 && txtLastName.Text.Length != 0)
            {
                search.first_name = txtFirstName.Text;
                search.last_name = txtLastName.Text;

                List<Customer> customer = new List<Customer>();
                customer = Customers_DataAccess.Customers_provider.search(search);
                dataGridView1.DataSource = customer;
            }
            if (txtCustomerID.Text == "" && txtFirstName.Text == "" && txtLastName.Text == "")
            {
            }

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DataGridViewRow dr = this.dataGridView1.Rows[e.RowIndex];
            Customer selectedCustomer = dr.DataBoundItem as Customer;

            Order newOrder = new Order();

            newOrder.customerID = selectedCustomer.CustomerID;
            newOrder.date_ordered = DateTime.Now;
            bool success = Customers_provider.createNewOrderNumber(newOrder);
            
            frmPlaceOrder frmNewOrder = new frmPlaceOrder();
            frmNewOrder.setOrder(selectedCustomer, newOrder);
            frmNewOrder.Show();
        }

        private void btnPlace_Click(object sender, EventArgs e)
        {

        }

        private void frmSearchCustomer_Load(object sender, EventArgs e)
        {
            txtCustomerID.TextAlign = HorizontalAlignment.Right;
            txtFirstName.TextAlign = HorizontalAlignment.Left;
            txtLastName.TextAlign = HorizontalAlignment.Left;
        }

        
    }
}
