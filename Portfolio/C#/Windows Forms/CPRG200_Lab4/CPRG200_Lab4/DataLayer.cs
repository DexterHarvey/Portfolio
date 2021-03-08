using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG200_Lab4
{
    public class DataLayer
    {
        //create an instance of the datacontext
        public DataClasses1DataContext db = new DataClasses1DataContext();

        public System.Data.Linq.Table<Order1> Orders
        {
            get
            {
                return this.Orders;
            }
        }
        //use order id to search db for matching order
        public Order1 GetOrderByID(int id)
        {
            Order1 order = db.Order1s.FirstOrDefault(x => x.OrderID == id);
            return order;
        }
        //method to get the next orderid in the db
        public int GetNextOrderID (int id)
        {
            //gets the idea of the last orderid in the db
            int lastId = GetLastOrderID();
            int nextOrderId;
            //checks that current order id is not equal to or greater than last orderid in db 
            if (id >= lastId)
            {
                //if it is, sets orderid to last order in db
                nextOrderId = lastId;
            }
            else
            {
                //if not, uses following linq expression to find next order (while skipping over missing orderids)
                nextOrderId = (from x in db.Order1s where x.OrderID > id select x.OrderID).Min();
            }
            return nextOrderId;
        }
        //exact same as previous method, but reversed
        public int GetPreviousOrderID(int id)
        {
            int firstId = GetFirstOrderID();
            int previousOrderId;
            if (id <= firstId)
            {
                previousOrderId = firstId;
            }
            else
            {
                previousOrderId = (from x in db.Order1s where x.OrderID < id select x.OrderID).Max();
            }
            return previousOrderId;
        }
        //method to find first orderid in db
        public int GetFirstOrderID()
        {
            var firstId = (from o in db.Order1s select o.OrderID).Min();
            return firstId;
        }
        //method to find last orderid in db
        public int GetLastOrderID()
        {
            var lastId = (from o in db.Order1s select o.OrderID).Max();
            return lastId;
        }
        //method to update db with new data 
        public bool UpdateShippedDate(Order1 oldOrder)
        {
            //creates a new order object based on updated order orderId
            var newOrder = db.Order1s.First(o => o.OrderID == oldOrder.OrderID);
            //changes ship date in order to new value
            newOrder.ShippedDate = oldOrder.ShippedDate;
            try
            {
                //attempts to update database with new information
                db.SubmitChanges();
                return true;
            }
            //if a concurrency error exists, a changeconflictexception will be thrown and the method will return false, telling the form that a concurrency error has occured
            catch (System.Data.Linq.ChangeConflictException)
            {
                return false;
            }
        }
        //method to create a data table for the order details datagridview
        public DataTable CreateDataTable(int id)
        {
            //linq query to get appropriate columns and create new ordertotal column
            var linqQueryTable = from o in db.Order_Details
                                 where o.OrderID == Convert.ToInt32(id)
                                 select new { o.OrderID, o.ProductID, o.UnitPrice, o.Quantity, o.Discount, OrderTotal = o.UnitPrice * (1 - Convert.ToDecimal(o.Discount)) * o.Quantity };
            //commands to create, adapt, fill, and return datatable
            SqlCommand cmdTable = db.GetCommand(linqQueryTable) as SqlCommand;
            DataTable orderDetailsDataTable = new DataTable();
            SqlDataAdapter adapterMainTable = new SqlDataAdapter(cmdTable);
            adapterMainTable.Fill(orderDetailsDataTable);
            return orderDetailsDataTable;
        }
        //method to refresh order information in db (called on concurrency error)
        public void RefreshDataBase()
        {
            db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues,
                    db.Order1s);
        }
    }
}
