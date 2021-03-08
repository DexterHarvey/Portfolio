using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPRG200_Lab4
{
    public partial class Form1 : Form
    {
        //create a new instance of the buisiness layer, the only layer the form communicates with
        BuisinessLayer bl = new BuisinessLayer();
        public Form1()
        {
            InitializeComponent();
        }
        //method to populate form with data from order object
        public void PopulateTextBoxes(Order1 order)
        {
            orderIDTextBox.Text = Convert.ToString(order.OrderID);
            string orderDate = $"{order.OrderDate:yyyy-MM-dd}";
            customerIDTextBox.Text = Convert.ToString(order.CustomerID);
            string reqDate = $"{order.RequiredDate:yyyy-MM-dd}";
            string shipDate = $"{order.ShippedDate:yyyy-MM-dd}";
            txtOrderDate.Text = orderDate;
            txtReqDate.Text = reqDate;
            txtShipDate.Text = shipDate;
        }
        //methods used to convert text box strings to datatime objects
        public DateTime GetOrderDateTime()
        {
            DateTime orderDateTime = Convert.ToDateTime(txtOrderDate.Text);
            return orderDateTime;
        }
        public DateTime GetRequiredDateTime()
        {
            DateTime reqDateTime = Convert.ToDateTime(txtReqDate.Text);
            return reqDateTime;
        }
        //method to use data in form to construct an order object (allows nulls in shipdate)
        public Order1 CreateOrderFromForm(DateTime? shipDate)
        {
            int orderID = Convert.ToInt32(orderIDTextBox.Text);
            DateTime orderDate = Convert.ToDateTime(txtOrderDate.Text);
            string customerID = customerIDTextBox.Text;
            DateTime reqDate = Convert.ToDateTime(txtReqDate.Text);
            var newOrder = new Order1
            {
                OrderID = orderID,
                OrderDate = orderDate,
                CustomerID = customerID,
                RequiredDate = reqDate,
                ShippedDate = shipDate
            };
            return newOrder;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //uses method to find first order in db by OrderID asc 
            int firstOrderId = bl.GetFirstOrderID();
            //builds object from first order
            Order1 order = bl.GetOrderByID(firstOrderId);
            //fills form with data of order object
            PopulateTextBoxes(order);
            //creates an order details data table based on the orderId and uses it to populate datagridview
            dataGridView1.DataSource = bl.CreateDataTable(Convert.ToInt32(orderIDTextBox.Text));
        }

        private void btnOrderNext_Click(object sender, EventArgs e)
        {
            int orderId = Convert.ToInt32(orderIDTextBox.Text);
            //uses method to get next order in table and builds order object
            Order1 order = bl.GetNextOrder(orderId);
            PopulateTextBoxes(order);
            dataGridView1.DataSource = bl.CreateDataTable(Convert.ToInt32(orderIDTextBox.Text));
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            string orderIdString = txtGetById.Text;
            //checks if the order field is empty, if not does the following:
            if (!bl.ValidateIsNull(orderIdString))
            {
                //checks if the entered data is a valid data type (intager)
                if (bl.ValidateOrderIdFormat(txtGetById.Text))
                {
                    int orderId = Convert.ToInt32(txtGetById.Text);
                    //checks if information entered in orderId field matches an orderId in the database
                    if (bl.ValidateOrderExists(orderId))
                    {
                        //if orderId is valid, uses methods to retrieve order and populate relevant data fields
                        Order1 order = bl.GetOrderByID(orderId);
                        PopulateTextBoxes(order);
                        dataGridView1.DataSource = bl.CreateDataTable(Convert.ToInt32(orderIDTextBox.Text));
                    }
                    //if order id is invalid, prompts user to reenter data
                    else
                    {
                        txtGetById.Text = "";
                        txtGetById.Focus();
                        MessageBox.Show("Please enter a valid order Id");
                    }
                }
                else
                {
                    //entered data was not an intager
                    MessageBox.Show("Please enter a whole number");
                }
            }
            //orderid field was left empty
            else 
            {
                txtGetById.Text = "";
                txtGetById.Focus();
                MessageBox.Show("Please enter an order Id");
            }
        }
        //method to update db with new ship date
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //checks if the ship date field is empty
            if (bl.ValidateIsNull(txtShipDate.Text))
            {
                //if ship date field is empty, constructs an order object with a null ship date
                Order1 updatedOrder = CreateOrderFromForm(bl.ConvertDateToNull());
                //attempts to update database with new order object
                if (bl.UpdateShippedDate(updatedOrder))
                {
                    //if update is successful
                    MessageBox.Show("Order updated successfully with null date");
                }
                else
                {
                    //if update is unsuccessful, this indicated a concurrency error has occurred. data refreshes with changed info and user is informed
                    bl.RefreshDataBase();
                    Order1 newOrder = bl.GetOrderByID(Convert.ToInt32(orderIDTextBox.Text));
                    PopulateTextBoxes(newOrder);
                    MessageBox.Show("Concurrency Error: Data has been altered or deleted");
                }
            }
            //if the ship date field is not empty, checks if it is a valid datetime
            else if (bl.ValidateDateTimeEntryFormat(txtShipDate.Text))
            {
                //if the date is entered in a valid format, it is checked to make sure it is in the valid range (after order date but before required date)
                if (bl.ValidateDateTimeEntryDate(Convert.ToDateTime(txtShipDate.Text), GetOrderDateTime(), GetRequiredDateTime()))
                {
                    //if date is in acceptable range, order object is built from form and an attempt is made to update the database with it
                    Order1 updatedOrder = CreateOrderFromForm(Convert.ToDateTime(txtShipDate.Text));
                    if (bl.UpdateShippedDate(updatedOrder))
                    {
                        MessageBox.Show("Order updated successfully with valid date");
                    }
                    //if update is unsuccessful, this indicated a concurrency error has occurred. data refreshes with changed info and user is informed
                    else
                    {
                        bl.RefreshDataBase();
                        Order1 newOrder = bl.GetOrderByID(Convert.ToInt32(orderIDTextBox.Text));
                        PopulateTextBoxes(newOrder);
                        MessageBox.Show("Concurrency Error: Data has been altered or deleted");
                    }

                }
                //date failed range validation
                else
                {
                    txtShipDate.Text = "";
                    txtShipDate.Focus();
                    MessageBox.Show("Please enter a valid date that is after the order date and before the required date");
                }

            }
            //date failed format validation
            else
            {
                txtShipDate.Text = "";
                txtShipDate.Focus();
                MessageBox.Show("Please enter a valid date in the form yyyy-mm-dd");
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            int orderId = Convert.ToInt32(orderIDTextBox.Text);
            Order1 order = bl.GetPreviousOrder(orderId);
            PopulateTextBoxes(order);
            dataGridView1.DataSource = bl.CreateDataTable(Convert.ToInt32(orderIDTextBox.Text));
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            Order1 order = bl.GetLastOrder();
            PopulateTextBoxes(order);
            dataGridView1.DataSource = bl.CreateDataTable(Convert.ToInt32(orderIDTextBox.Text));
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            Order1 order = bl.GetFirstOrder();
            PopulateTextBoxes(order);
            dataGridView1.DataSource = bl.CreateDataTable(Convert.ToInt32(orderIDTextBox.Text));
        }

        //formats cells that represent currency to display in an appropriate way
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            var orderTotalColumn = dataGridView1.Columns[e.ColumnIndex];
            if (orderTotalColumn.Name == "OrderTotal" && e.Value != null)
            {
                var value = (decimal)e.Value;
                // Display only two digits of decimals without rounding
                var twoDigitsValue = Math.Truncate(value * 100) / 100;
                e.Value = twoDigitsValue.ToString("C2");
            }

            var unitPriceColumn = dataGridView1.Columns[e.ColumnIndex];
            if (unitPriceColumn.Name == "UnitPrice" && e.Value != null)
            {
                var value = (decimal)e.Value;
                // Display only two digits of decimals without rounding
                var twoDigitsValue = Math.Truncate(value * 100) / 100;
                e.Value = twoDigitsValue.ToString("C2");
            }
        }
    }
}
