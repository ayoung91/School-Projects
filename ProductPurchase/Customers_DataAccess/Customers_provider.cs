using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Customers_DataAccess
{
    public static class Customers_provider
    {
        public static List<Customer> allCustomers()
        {

            using (var context = new CustomersEntities())
            {

                var cust = from c in context.Customers
                           orderby c.last_name, c.first_name
                           select c;
                return cust.ToList();
            }
        }

            

            //Method #1
        //adds a customer to the datbase
        public static bool addCustomer(Customer newCustomer)
        {
            using (var context = new CustomersEntities())
            {
                context.ContextOptions.LazyLoadingEnabled = false;
                context.Customers.AddObject(newCustomer);

                bool sucess = context.SaveChanges() == 1;
                if (sucess)
                    return true;
                else
                    return false;
            }
        }




	//Method #2
        //Returns an List of customer objects.  
        public static List<Customer> search(Customer myCustomer)
        {
            using (var context = new CustomersEntities())
            {

                context.ContextOptions.LazyLoadingEnabled = false;
                var cust = from c in context.Customers
                               where c.last_name.StartsWith(myCustomer.last_name)
                               && c.first_name.StartsWith(myCustomer.first_name)
                               orderby c.last_name, c.first_name
                               select c;
                return cust.ToList();
            }
        }


	//Method #3
        //Returns an List of customer objects.  
        public static List<Customer> searchByID(int customerID)
        {
            using (var context = new CustomersEntities())
            {
                context.ContextOptions.LazyLoadingEnabled = false;
                var cust = from c in context.Customers
                           where c.CustomerID==customerID
                           orderby c.last_name, c.first_name
                           select c;
                return cust.ToList();
            }
        }



	

	//Method #4
        //Creates an entry in the order table, which generates an order number
        public static bool createNewOrderNumber(Order newOrder)
        {
            using (var context = new CustomersEntities())
            {
                context.ContextOptions.LazyLoadingEnabled = false;
                context.Orders.AddObject(newOrder);

                bool sucess = context.SaveChanges() == 1;
                if (sucess)
                    return true;
                else
                    return false;
            }
        }


	//Method #5
        //Creates an entry in the Items table.
        public static bool addItemToOrder(Order_item newItem)
        {
            using (var context = new CustomersEntities())
            {
                context.ContextOptions.LazyLoadingEnabled = false;
                context.Order_item.AddObject(newItem);

                bool sucess = context.SaveChanges() == 1;
                if (sucess)
                    return true;
                else
                    return false;
            }
        }


	//Method #6
        //Creates an entry in the Items table.
        public static bool removeItemFromOrder(Order_item deleteItem)
        {
            using (var context = new CustomersEntities())
            {
                context.ContextOptions.LazyLoadingEnabled = false;
                context.Attach(deleteItem);
                context.Order_item.DeleteObject(deleteItem);

                bool sucess = context.SaveChanges() == 1;
                if (sucess)
                    return true;
                else
                    return false;
            }
        }




	//Method #7
        //Gets a list of productst that your company sells.
        public static List<Product> getProducts()
        {

            using (var context = new CustomersEntities())
            {
                context.ContextOptions.LazyLoadingEnabled = false;
                var product_items = from c in context.Products
                           orderby c.product_description
                           select c;
                return product_items.ToList();
            }
        }



	//Method #8
        //Gets a list of productst that your company sells.
        public static List<Order_item> getOrderItemsByOrderID(int order_number)
        {

            using (var context = new CustomersEntities())
            {
                context.ContextOptions.LazyLoadingEnabled = false;
                var order_items = from c in context.Order_item
                                  where c.order_number==order_number
                                    orderby c.item_id
                                    select c;
                return order_items.ToList();
            }
        }



        //Gets a list of productst that your company sells.
        public static List<Order> getOrderByID(int order_number)
        {

            using (var context = new CustomersEntities())
            {
                context.ContextOptions.LazyLoadingEnabled = false;
                var order = from c in context.Orders
                                  where c.order_number == order_number
                                  select c;
                return order.ToList();
            }
        }


        }
    }

