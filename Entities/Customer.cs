using CarRentalSystem.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Entities
{
    public class Customer
    {
        public int customerID;
        public string firstName;
        public string lastName;
        public string email;
        public string phone;

        public Customer()
        {
        }

        public Customer(int customerID,  string firstName, string lastName, string email, string phone)
        {
            this.customerID = customerID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.phone = phone;
        }

        public int CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public override string ToString()
        {
            return $"Customer Name: {firstName} {lastName}\t Email: {email}\t Phone number: {phone}";
        }
    }
}
