using CarRentalSystem.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Entities
{
    internal class Lease
    {
        public int leaseID;
        public int vehicleID;
        public int customerID;
        public DateTime startDate;
        public DateTime enddate;

        public Lease(int leaseID, int vehicleID, int customerID, DateTime startDate, DateTime enddate)
        {
            this.leaseID = leaseID;
            this.vehicleID = vehicleID;
            this.customerID = customerID;
            this.startDate = startDate;
            this.enddate = enddate;
        }

        public Lease() { }

        //public abstract double calculateLeaseCost();

        //public Lease createLease(int customerID, int carID, DateTime startDate, DateTime endDate)
        //{
        //    throw new NotImplementedException();
        //}

        //public abstract void generateLeaseAgreement();

        //public List<Lease> listActiveLeases()
        //{
        //    throw new NotImplementedException();
        //}

        //public List<Lease> listLeaseHistory()
        //{
        //    throw new NotImplementedException();
        //}

        //public void returnCar(int leaseID)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
