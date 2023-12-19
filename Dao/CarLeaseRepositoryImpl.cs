using CarRentalSystem.Entities;
using CarRentalSystem.Exceptions;
using CarRentalSystem.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Dao
{
    public class CarLeaseRepositoryImpl:ICarLeaseRepositoryImpl
    {
        //Creating Lists
        public List<Customer> customers;
        public List<Car> cars;
        //public List<MotorCycle> motorcycle;
        public List<Lease> leases;
        public List<Payment> payment;


        //Adding database connectivity
        public string connectionString;
        SqlCommand cmd = null;

        public string ConnectionString
        {
            get { return  connectionString; } 
            set {  connectionString = value; }
        }
        public CarLeaseRepositoryImpl()
        {
            connectionString = DbConnUtil.getConnectionString();
            cmd = new SqlCommand();
        }


        //Implementing methods for Customer Management
        public List<Customer> listCustomers()
        {
            customers=new List<Customer>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "select * from Customers";
                    cmd.Connection = conn;
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Customer customer = new Customer();
                        customer.customerID = (int)reader["customerID"];
                        customer.firstName = (string)reader["firstname"];
                        customer.lastName = (string)reader["lastname"];
                        customer.email = (string)reader["email"];
                        customer.phone = (string)reader["phone"];
                        customers.Add(customer);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return customers;
        }

        public int addCustomer(Customer customer)
        {
            
            
                using(SqlConnection conn=new SqlConnection(connectionString))
                {
                    cmd.CommandText = "insert into Customers(firstname, lastname, email, phone) values(@firstname, @lastname, @email, @phone)";
                    cmd.Parameters.AddWithValue("@firstname", customer.firstName);
                    cmd.Parameters.AddWithValue("@lastname", customer.lastName);
                    cmd.Parameters.AddWithValue("@email", customer.email);
                    cmd.Parameters.AddWithValue("@phone", customer.phone);
                    cmd.Connection = conn;
                    conn.Open();
                    int status = cmd.ExecuteNonQuery();
                    return status;
                }
            

        }

        public Customer findCustomerById(int customerID)
        {
            Customer customer = new Customer();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                cmd.CommandText = "select * from Customers where customerID=@customerid";
                cmd.Parameters.AddWithValue("@customerid", customerID);
                cmd.Connection = conn;
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    customer.customerID = (int)reader["customerID"];
                    customer.firstName = (string)reader["firstname"];
                    customer.lastName = (string)reader["lastname"];
                    customer.email = (string)reader["email"];
                    customer.phone = (string)reader["phone"];
                }

                if (customer.customerID == customerID)
                    return customer;
                else
                    throw new CustomerNotFoundException($"Customer with ID {customerID} does not exist in the database");
            }


            return customer;
        }

        public int removeCustomer(int customerID)
        {
            int status=0;
            try
            {
                using(SqlConnection conn=new SqlConnection(connectionString))
                {
                    cmd.CommandText = "delete from Customers where customerID=@customerid";
                    cmd.Parameters.AddWithValue("@customerid", customerID);
                    cmd.Connection = conn;
                    conn.Open();
                    status=cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return status;
        }

        //Implementing Methods for Car Management
        public List<Car> listAvailableCars()
        {
            cars= new List<Car>();
            try
            {
                using(SqlConnection conn= new SqlConnection(connectionString))
                {
                    cmd.CommandText = "select * from Vehicles where vstatus='Available' and enginecapacity is null";
                    cmd.Connection = conn;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        Car c = new Car();
                        c.vehicleID = (int)reader["vehicleID"];
                        c.make = (string)reader["make"];
                        c.model = (string)reader["model"];
                        c.year = (int)reader["myear"];
                        c.dailyRate = Convert.ToDouble(reader["dailyrate"]);
                        //c.isAvailable = (bool)reader["vstatus"];
                        cars.Add(c);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return cars;
        }

        public List<Car> listRentedCars()
        {
            cars=new List<Car>();
            try
            {
                using(SqlConnection conn=new SqlConnection(connectionString))
                {
                    cmd.CommandText = "select * from Vehicles where vstatus='notAvailable' and enginecapacity is null";
                    cmd.Connection = conn;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        Car c = new Car();
                        c.vehicleID = (int)reader["vehicleID"];
                        c.make = (string)reader["make"];
                        c.model = (string)reader["model"];
                        c.year = (int)reader["myear"];
                        c.dailyRate = Convert.ToDouble(reader["dailyrate"]);
                        cars.Add(c);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return cars;
        }

        public int addCar(Car car)
        {
            using(SqlConnection conn=new SqlConnection(connectionString))
            {
                cmd.CommandText = "insert into Vehicles(make, model, myear, dailyrate, vstatus, passengercapacity) values(@make, @model, @year, @dailyRate, 'available', @pcap)";
                cmd.Parameters.AddWithValue("@make", car.make);
                cmd.Parameters.AddWithValue ("@model", car.model);
                cmd.Parameters.AddWithValue("@year", car.year);
                cmd.Parameters.AddWithValue("@dailyRate", car.dailyRate);
                cmd.Parameters.AddWithValue("@pcap", car.passengerCapacity);
                cmd.Connection = conn;
                conn.Open();

                int status = cmd.ExecuteNonQuery();
                return status;
            }
        }

        public int removeCar(int carID)
        {
            int status = 0;
            try
            {
                using(SqlConnection conn=new SqlConnection(connectionString))
                {
                    cmd.CommandText = "delete from Vehicles where vehicleID=@vid";
                    cmd.Parameters.AddWithValue("@vid", carID);
                    cmd.Connection = conn;
                    conn.Open();
                    status = cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return status;
        }

        public Car findCarById(int carID)
        {
            Car c = new Car();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                cmd.CommandText = "select * from Vehicles where vehicleID=@vid";
                cmd.Parameters.AddWithValue("@vid", carID);
                cmd.Connection = conn;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    c.vehicleID = (int)reader["vehicleID"];
                    c.make = (string)reader["make"];
                    c.model = (string)reader["model"];
                    c.year = (int)reader["myear"];
                    c.isAvailable = (string)reader["vstatus"];
                    c.dailyRate= Convert.ToDouble(reader["dailyrate"]);
                }
                if (c.vehicleID == carID)
                    return c;
                else
                    throw new CarNotFoundException($"Vehicle with ID {carID} does not exist in our system.");
            }
        }

        //Implementing methods for Lease management
        public int createLease(int customerID, int carID, DateTime startDate, DateTime endDate)
        {
            //Lease addLease = new Lease();
            using(SqlConnection conn=new SqlConnection(connectionString)) 
            {
                string dl = "DailyLease";
                string ml = "MonthlyLease";
                cmd.CommandText = "insert into Leases(vehicleID, customerID, startdate, enddate, leasetype) values(@custid, @carid, @sdate, @edate, @type)";
                cmd.Parameters.AddWithValue("@custid", customerID);
                cmd.Parameters.AddWithValue("@carid", carID);
                cmd.Parameters.AddWithValue("@sdate", startDate);
                cmd.Parameters.AddWithValue("@edate", endDate);
                TimeSpan diff = endDate - startDate;
                if ((diff.Days >= 1 && diff.Days<30) || diff.Days>30)
                    cmd.Parameters.AddWithValue("@type", dl);
                else
                    cmd.Parameters.AddWithValue("@type", ml);
                cmd.Connection= conn;
                conn.Open();
                int addLeaseStatus = cmd.ExecuteNonQuery();
                cmd.CommandText = "update Vehicles set vstatus='notAvailable' where vehicleID=@veid";
                cmd.Parameters.AddWithValue("@veid", carID);
                int vupdate = cmd.ExecuteNonQuery();
                //cmd.CommandText = ("select SCOPE_IDENTITY() as sc");
                //SqlDataReader read=cmd.ExecuteReader();
                //int leaseid=0;
                //while(read.Read())
                //{
                //    leaseid = (int)read["sc"];
                //}
                //int leaseid = Convert.ToInt32(cmd.ExecuteScalar());
                //addLease.leaseID= leaseID;
                //addLease.vehicleID = carID;
                //addLease.customerID = customerID;
                //addLease.startDate = startDate;
                //addLease.enddate = endDate;
                return addLeaseStatus;
            }          
        }

        public ArrayList displayLeaseInfo (int leaseID)
        {
            ArrayList leased = new ArrayList();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                //select * from Leases where leaseID=@lid
                cmd.CommandText = "select c.firstname, c.lastname, v.make, v.model, l.startdate, l.enddate from Customers c join Leases l on c.customerID=l.customerID join Vehicles v on l.vehicleID=v.vehicleID where l.leaseID=@lid";
                cmd.Parameters.AddWithValue("@lid", leaseID);
                cmd.Connection = conn;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    leased.Add((string)reader["firstname"]);
                    leased.Add((string)reader["lastname"]);
                    leased.Add((string)reader["make"]);
                    leased.Add((string)reader["model"]);
                    leased.Add((DateTime)reader["startdate"]);
                    leased.Add((DateTime)reader["enddate"]);
                }

                if (leased.Count != 0)
                    return leased;
                else
                    throw new LeaseNotFoundException($"Lease with ID {leaseID} does not exist");
            }
        }

        public List<Lease> listActiveLeases()
        {
            List<Lease> activeLeases=new List<Lease>();
            using( SqlConnection conn=new SqlConnection(connectionString ))
            {
                cmd.CommandText = "select * from Leases where GETDATE()<=enddate";               
                cmd.Connection= conn;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Lease lease = new Lease();
                    lease.leaseID = (int)reader["leaseID"];
                    lease.vehicleID = (int)reader["vehicleID"];
                    lease.customerID = (int)reader["customerID"];
                    lease.startDate= (DateTime)reader["startdate"];
                    lease.enddate = (DateTime)reader["enddate"];
                    activeLeases.Add(lease);
                }
            }
            return activeLeases;
        }

        public List<Lease> listLeaseHistory()
        {
            List<Lease> leaseHistory = new List<Lease>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                cmd.CommandText = "select * from Leases where GETDATE()>=enddate";
                cmd.Connection = conn;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Lease lease = new Lease();
                    lease.leaseID = (int)reader["leaseID"];
                    lease.vehicleID = (int)reader["vehicleID"];
                    lease.customerID = (int)reader["customerID"];
                    lease.startDate = (DateTime)reader["startdate"];
                    lease.enddate = (DateTime)reader["enddate"];
                    leaseHistory.Add(lease);
                }
            }
            return leaseHistory;
        }

        public int returnCar(int carID)
        {
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                cmd.CommandText = "update Vehicles set vstatus='available' where vehicleID=@cid";
                cmd.Parameters.AddWithValue("@cid", carID);

                cmd.Connection= conn;
                conn.Open();

                int returnStat = cmd.ExecuteNonQuery();

                return returnStat;
            }
        }

        //Implementing methods for Payment Management
        public void recordPayment(DateTime paymentDate, double amount)
        {
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                int leaseid=0;
                cmd.CommandText = "select top 1 * from Leases order by leaseID desc";
                cmd.Connection = conn;
                conn.Open();
                SqlDataReader r = cmd.ExecuteReader();
                Lease l = new Lease();
                while (r.Read())
                {              
                    l.leaseID = (int)r["leaseID"];
                }

                r.Close();
                
                cmd.CommandText = "insert into Payments(leaseID, paymentdate, amount) values(@lid, @pdate, @amt)";
                cmd.Parameters.AddWithValue("@lid", l.leaseID);
                cmd.Parameters.AddWithValue("@pdate", paymentDate);
                cmd.Parameters.AddWithValue("@amt", amount);

                int addPaymentStatus=cmd.ExecuteNonQuery();
            }
        }

        public List<Payment> listPayments()
        {
            List<Payment> paymentsList=new List<Payment>();
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                cmd.CommandText = "select * from Payments";
                cmd.Connection = conn;
                conn.Open();
                SqlDataReader r = cmd.ExecuteReader();
                while(r.Read())
                {
                    Payment p = new Payment();
                    p.paymentID = (int)r["paymentID"];
                    p.leaseID = (int)r["leaseID"];
                    p.paymentDate = (DateTime)r["paymentdate"];
                    p.amount = Convert.ToDouble(r["amount"]);
                    paymentsList.Add(p);
                }
            }

            return paymentsList;
        }
    }
}
