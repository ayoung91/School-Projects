using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomersFinal;
using Customers_DataAccess;

namespace CustomersFinal
{
    public partial class frmPlaceOrder : Form
    {
        Order _newOrder;
        Customer _selectedCustomer;
        List<Order_item> _order_items = new List<Order_item>();

        public frmPlaceOrder()
        {
            InitializeComponent();
        }

        private void frmPlaceOrder_Load(object sender, EventArgs e)
        {
            txtCustomerID.TextAlign = HorizontalAlignment.Right;
            txtCustomerName.TextAlign = HorizontalAlignment.Left;
            txtOrderNumber.TextAlign = HorizontalAlignment.Right;

            cbxItem.DataSource = Customers_provider.getProducts();
            cbxItem.DisplayMember = "product_description";
            cbxItem.DisplayMember = "prodcut_id";
            cbxQuantity.SelectedIndex = 0;
            this.Text = "Placing New Order For: " + _selectedCustomer.last_name + ", " + _selectedCustomer.first_name;
            this.cbxItem.Focus();
        }
        private void updateOrderList()
        {
            this.dgvItemsOrdered.DataSource = null;
            this.dgvItemsOrdered.DataSource = this._order_items;
            this.dgvItemsOrdered.RowHeadersVisible = false;
            this.dgvItemsOrdered.Columns["Order"].Visible = false;
            this.dgvItemsOrdered.Columns["Product"].Visible = false;
            this.cbxItem.Focus();
        }

        public void setOrder(Customer selectedCustomer, Order newOrder)
        {
            txtCustomerID.Text = selectedCustomer.CustomerID.ToString();
            txtCustomerName.Text = selectedCustomer.last_name.ToString() + ", " + selectedCustomer.first_name.ToString();
            txtOrderNumber.Text = newOrder.order_number.ToString();
            _selectedCustomer = selectedCustomer;
            _newOrder = newOrder;
        }        

        private void dgvItemsOrdered_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DataGridViewRow dr = this.dgvItemsOrdered.Rows[e.RowIndex];
            Order_item selectedOrderItem = dr.DataBoundItem as Order_item;

            DialogResult dialog = MessageBox.Show("Are you sure you want to delete this order?", "Delete?" , MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                _order_items.Remove(selectedOrderItem);
                Customers_provider.removeItemFromOrder(selectedOrderItem);
                updateOrderList();
            }
                else if(dialog == DialogResult.No)
                {}
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Boolean add;
            Product item = (Product)cbxItem.SelectedItem;
            int quantity = int.Parse(cbxQuantity.SelectedItem.ToString());
            Order_item order = new Order_item();

            order.order_number = int.Parse(txtOrderNumber.Text);
            order.product_id = item.product_id;
            order.product_desc = item.product_description;
            order.quantity = quantity;

            add = Customers_DataAccess.Customers_provider.addItemToOrder(order);

            if (add)
            {
                _order_items.Add(order);
                updateOrderList();
            }            
        }









    }
}
