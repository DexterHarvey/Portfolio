using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG214.FormsLab.Data
{
    public class MarinaManager
    {
        public IList GetAvailableSlips(int dockID)
        {
            var db = new MarinaEntities();
            var result = new List<Slip>();
            using (db)
            {
                var query = from slips in db.Slips
                            join docks in db.Docks
                            on slips.DockID equals dockID
                            where !(from l in db.Leases
                                    select l.SlipID)
                                    .Contains(slips.ID)
                            select slips;
                foreach (var slip in query) result.Add(slip);
            }
            return result;
        }
        public List<int> GetAvailableSlipIDs(int dockID)
        {
            var db = new MarinaEntities();
            var result = new List<int>();
            var myList = new List<int>();
            using (db)
            {
                var query = from slips in db.Slips
                            join docks in db.Docks
                            on slips.DockID equals dockID
                            where !(from l in db.Leases
                                    select l.SlipID)
                                    .Contains(slips.ID)
                            select slips.ID;
                foreach (var slip in query) myList.Add(slip);
            }
            result = myList.GroupBy(slip => slip)
                   .Select(grp => grp.First())
                   .ToList();
            return result;
        }
        public List<int> GetSlipIDs(int dockID)
        {
            var db = new MarinaEntities();
            var result = new List<int>();
            using (db)
            {
                var query = from slips in db.Slips
                            join docks in db.Docks
                            on slips.DockID equals dockID
                            //where !(from l in db.Leases
                            //        select l.SlipID)
                            //        .Contains(slips.ID)
                            select slips.ID;
                foreach (var slip in query) result.Add(slip);
            }
            return result;
        }
        public int GetSlipLength(int slipID)
        {
            var db = new MarinaEntities();
            var query = (from slip in db.Slips
                        where slip.ID == slipID
                        select slip.Length).Single();
            int result = Convert.ToInt32(query);
            return result;
        }
        public int GetSlipWidth(int slipID)
        {
            var db = new MarinaEntities();
            var query = (from slip in db.Slips
                        where slip.ID == slipID
                        select slip.Width).Single();
            int result = Convert.ToInt32(query);
            return result;
        }
        public IList GetLeasesByCustomer(int custID)
        {
            var db = new MarinaEntities();
            var result = new List<Lease>();
            using (db)
            {
                var query = from c in db.Customers
                            join l in db.Leases
                            on c.ID equals l.CustomerID
                            where c.ID == custID
                            select l;
                foreach (var lease in query) result.Add(lease);
            }
            return result;
        }
        public IList GetDocks()
        {
            var db = new MarinaEntities();
            var result = new List<int>();
            using (db)
            {
                var query = from d in db.Docks
                            select d.ID;
                foreach (var dock in query) result.Add(dock);
            }
            return result;
        }

        public bool RegisterUser(Customer cust)
        {
            Validate vl = new Validate();
            var db = new MarinaEntities();
            if (vl.ValidateCustomer(cust))
            {
                db.Customers.Add(cust);
            }
            else
            {
                return false;
            }
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (DbEntityValidationException)
            {
                return false;
            }
        }
        public Customer GetCustomerByID(int id)
        {
            var db = new MarinaEntities();
            var customer = new Customer();
            using (db)
            {
                var query = from c in db.Customers
                            where c.ID == id
                            select c;
                foreach (var cust in query)
                {
                    customer.FirstName = cust.FirstName;
                    customer.LastName = cust.LastName;
                    customer.City = cust.City;
                    customer.Phone = cust.Phone;
                }
            }
            return customer;
        }
        public Slip GetSlip(int dockID, int slipID)
        {
            var db = new MarinaEntities();
            var slip = new Slip();
            using (db)
            {
                var query = from s in db.Slips
                            where s.ID == slipID && s.DockID == dockID
                            select s;
                foreach (var slip1 in query)
                {
                    slip.Width = slip1.Width;
                    slip.Length = slip1.Length;
                    slip.DockID = slip1.DockID;
                }
            }
            return slip;
        }
        public void AddLeaseToCust(int custID, int slipID)
        {
            var db = new MarinaEntities();
            var lease = new Lease();
            lease.CustomerID = custID;
            lease.SlipID = slipID;
            db.Leases.Add(lease);
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }
    }
}
