using CarRentalSystem.Entities;
using CarRentalSystem.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Dao
{
    internal class CarLeaseRepositoryImpl:ICarLeaseRepositoryImpl
    {
        //Creating Lists
        List<Customer> customers;
        List<Car> cars;
        List<MotorCycle> motorcycle;
        List<Lease> leases;
        List<Payment> payment;


        //Adding database connectivity
        public string connectionString;
        SqlCommand cmd = null;

        public CarLeaseRepositoryImpl()
        {
            //customers = new List<Customer>()
            //{
            //    new Customer() {customerID=1, firstName="Aditya", lastName="Pandit", email="aditya@gmail.com", phone="8854120236"},
            //    new Customer() {customerID=2, firstName="Suvidha", lastName="Ghosh", email="gsuvidha@gmail.com", phone="7789002103"},
            //};

            //cars = new List<Car>()
            //{
            //    new Car() {VehicleID=1, Make="Maruti", Model="Dzire", Year=2020, DailyRate=3000, IsAvailable=true, passengerCapacity=5},
            //    new Car() {VehicleID=2, Make="Mahindra", Model="Thar", Year=2021, DailyRate=5000, IsAvailable=false, passengerCapacity=4},
            //};

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
                    cmd.CommandText = "insert into Customers values(@id, @firstname, @lastname, @email, @phone)";
                    cmd.Parameters.AddWithValue("@id", customer.customerID);
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
            try
            {
                using(SqlConnection conn=new SqlConnection(connectionString))
                {
                    cmd.CommandText = "select * from Customers where customerID=@customerid";
                    cmd.Parameters.AddWithValue("@customerid", customerID);
                    cmd.Connection = conn;
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        customer.customerID = (int)reader["customerID"];
                        customer.firstName = (string)reader["firstname"];
                        customer.lastName = (string)reader["lastname"];
                        customer.email = (string)reader["email"];
                        customer.phone = (string)reader["phone"];
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
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
                cmd.CommandText = "insert into Vehicles values(@id, @make, @model, @year, @dailyRate, 'available', @pcap, null)";
                cmd.Parameters.AddWithValue("@id", car.vehicleID);
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
                return c;
            }
        }

        //Implementing methods for Lease management
        public int createLease(int customerID, int carID, DateTime startDate, DateTime endDate)
        {
            Lease addLease = new Lease();
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
                cmd.CommandText=("select SCOPE_IDENTITY()");
                int leaseID = Convert.ToInt32(cmd.ExecuteScalar());
                return leaseID;
            }          
        }

        public void returnCar(int leaseID)
        {
            throw new NotImplementedException();
        }

        public List<Lease> listActiveLeases()
        {
            throw new NotImplementedException();
        }

        public List<Lease> listLeaseHistory()
        {
            throw new NotImplementedException();
        }

        public List<Payment> listPayments(Lease lease)
        {
            throw new NotImplementedException();
        }

        public void recordPayment(Lease lease, double amount)
        {
            throw new NotImplementedException();
        }
    }
}
