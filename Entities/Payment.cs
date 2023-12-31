﻿using CarRentalSystem.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Entities
{
    public class Payment
    {
        public int paymentID;
        public int leaseID;
        public DateTime paymentDate;
        public double amount;

        public Payment()
        {
        }

        public Payment(int paymentID, int leaseID, DateTime paymentDate, double amount)
        {
            this.paymentID = paymentID;
            this.leaseID = leaseID;
            this.paymentDate = paymentDate;
            this.amount = amount;
        }

        public int PaymentID
        {
            get { return paymentID; }
            set { paymentID = value; }
        }

        public int LeaseID
        {
            get { return leaseID; }
            set { leaseID = value; }
        }

        public DateTime PaymentDate
        {
            get { return paymentDate; }
            set { paymentDate = value; }
        }

        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        //public List<Payment> listPayment(Lease lease)
        //{
        //    throw new NotImplementedException();
        //}

        //public void recordPayment()
        //{
        //    throw new NotImplementedException();
        //}

        //public void recordPayment(Lease lease, double amount)
        //{
        //    throw new NotImplementedException();
        //}

        public override string ToString()
        {
            return $"PaymentID: {paymentID}\t LeaseID: {LeaseID}\t Payment date: {paymentDate}\t Payment Amount: {amount}";
        }
    }
}
