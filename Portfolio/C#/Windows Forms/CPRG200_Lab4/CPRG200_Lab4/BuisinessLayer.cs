using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG200_Lab4
{
    //the buisiness layer is largely middleware, used to keep the UI "dumb" (seperate from the database and validation)
    public class BuisinessLayer
    {
        //data being passed through the buisiness layer will often be sent to the validation layer before either being sent to the database layer or returned to the form layer
        public DataLayer dl = new DataLayer();
        public Validation vl = new Validation();

        public Order1 GetOrderByID(int ID)
        {
            return dl.GetOrderByID(ID);
        }
        public int GetFirstOrderID()
        {
            return dl.GetFirstOrderID();
        }
        public Order1 GetNextOrder(int currentId)
        {
            var nextId = dl.GetNextOrderID(currentId);
            return dl.GetOrderByID(nextId);
        }
        public Order1 GetPreviousOrder(int currentId)
        {
            var previousId = dl.GetPreviousOrderID(currentId);
            return dl.GetOrderByID(previousId);
        }
        public Order1 GetLastOrder()
        {
            var lastOrderId = dl.GetLastOrderID();
            return dl.GetOrderByID(lastOrderId);
        }
        public Order1 GetFirstOrder()
        {
            var firstOrderId = dl.GetFirstOrderID();
            return dl.GetOrderByID(firstOrderId);
        }
        public bool UpdateShippedDate(Order1 updatedOrder)
        {
            if(dl.UpdateShippedDate(updatedOrder))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataTable CreateDataTable(int id)
        {
            return dl.CreateDataTable(id);
        }
        public bool ValidateDateTimeEntryFormat(string shipDateTime)
        {
            return vl.ValidateDateTimeEntryFormat(shipDateTime);
        }
        public bool ValidateDateTimeEntryDate(DateTime validDate, DateTime orderDate, DateTime reqDate)
        {
            return vl.ValidateDateTimeEntryDate(validDate, orderDate, reqDate);
        }
        public bool ValidateIsNull(string shipDateTime)
        {
            return vl.ValidateIsNull(shipDateTime);
        }
        public DateTime? ConvertDateToNull()
        {
            DateTime? date = null;
            return date;
        }
        public bool ValidateOrderExists(int orderId)
        {
            Order1 unknownOrder = dl.GetOrderByID(orderId);
            if (vl.ValidateOrderExists(unknownOrder))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ValidateOrderIdFormat(string possibleOrderId)
        {
            return vl.ValidateOrderIdFormat(possibleOrderId);
        }
        public void RefreshDataBase()
        {
            dl.RefreshDataBase();
        }
    }
}
