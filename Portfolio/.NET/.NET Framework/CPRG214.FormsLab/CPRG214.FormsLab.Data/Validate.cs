using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CPRG214.FormsLab.Data
{
    class Validate
    {
        public bool ValidateCustomer(Customer cust)
        {
            if (ValidatePhone(cust.Phone) && ValidateNameCity(cust.City) && ValidateNameCity(cust.LastName) && ValidateNameCity(cust.FirstName) && ValidateDoesNotExist(cust.FirstName, cust.LastName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ValidatePhone(string phone)
        {
            string regex = @"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$";
            if (Regex.IsMatch(phone, regex) && phone != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ValidateNameCity(string item)
        {
            string regex = @"^[A-Za-z ,.'-]+$";
            if (Regex.IsMatch(item, regex) && item != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ValidateDoesNotExist(string firstName, string lastName)
        {
            var db = new MarinaEntities();
            var existingCustomers = new List<Customer>();
            using (db)
            {
                var query = from cust in db.Customers
                            where cust.FirstName == firstName && cust.LastName == lastName
                            select cust;
                foreach (var c in query) existingCustomers.Add(c);
            }
            if (existingCustomers.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
