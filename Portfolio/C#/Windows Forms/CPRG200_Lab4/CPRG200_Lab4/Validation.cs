using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG200_Lab4
{
    public class Validation
    {
        //method to check if the value of a textbox is "null" (an empty text string)
        public bool ValidateIsNull(string possiblyEmptyString)
        {
            bool isNull;
            if (possiblyEmptyString == "")
            {
                isNull = true;
            }
            else
            {
                isNull = false;
            }
            return isNull;
        }
        //method to test the validity of the format of an entered date
        public bool ValidateDateTimeEntryFormat(string shipDateTime)
        {
            bool isValid;
            DateTime validShipDate;
            //date is valid if "null" (an empty string)
            if (shipDateTime == "")
            {
                isValid = true;
            }
            //if date is not an empty string
            else
            {
                try
                {
                    //method tries to convert string to a date time object. if this is possible, date string has been entered in a valid way
                    validShipDate = Convert.ToDateTime(shipDateTime);
                    isValid = true;
                }
                //if system cannot convert string to datetime it will throw a format exception, which is caught and the boolean value of isValid is set to false (failed validity)
                catch (System.FormatException)
                {
                    isValid = false;
                }
            }
            return isValid;
        }
        //uses the parameters of order date, required date, and entered ship date to test if ship date is after order but before required date. a return or true indicates passed validity
        public bool ValidateDateTimeEntryDate(DateTime validDate, DateTime orderDate, DateTime reqDate)
        {
            bool isInRange;
            if (validDate >= orderDate && validDate <= reqDate)
            {
                isInRange = true;
            }
            else
            {
                isInRange = false;
            }
            return isInRange;
        }
        //used to check if a searched order exists (is not null)
        public bool ValidateOrderExists(Order1 order)
        {
            if (order != null)
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
            bool isValid;
            try
            {
                //method tries to convert string to an int. if this is possible, orderid has been entered in a valid way
                int validInt = Convert.ToInt32(possibleOrderId);
                isValid = true;
            }
            //if system cannot convert string to int it will throw a format exception, which is caught and the boolean value of isValid is set to false (failed validity)
            catch (System.FormatException)
            {
                isValid = false;
            }
            return isValid;
        }
    }
}
