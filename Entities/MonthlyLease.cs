using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Entities
{
    internal class MonthlyLease : Lease
    {
        public MonthlyLease(int leaseID, int vehicleID, int customerID, DateTime startDate, DateTime enddate) : base(leaseID, vehicleID, customerID, startDate, enddate)
        {
        }

        //public override double calculateLeaseCost()
        //{
        //    throw new NotImplementedException();
        //}

        //public override void generateLeaseAgreement()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
