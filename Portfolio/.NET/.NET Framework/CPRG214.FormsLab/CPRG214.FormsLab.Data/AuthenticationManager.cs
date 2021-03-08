using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG214.FormsLab.Data
{
    public class AuthenticationManager
    {
        public static Customer Authenticate(string firstName, string lastName)
        {
            Customer sessionCustomer = null;
            var db = new MarinaEntities();
            var customer = db.Customers.SingleOrDefault(cust => cust.FirstName == firstName && cust.LastName == lastName);

            if (customer != null)
            {
                sessionCustomer = new Customer
                {
                    ID = customer.ID,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    City = customer.City,
                    Phone = customer.Phone
                };
            }
            return sessionCustomer;
        }
        public bool IsNotNull(string firstName, string lastName)
        {
            if (firstName != "" && lastName != "")
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
