using CarRentalSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Dao
{
    internal interface ICarLeaseRepositoryImpl
    {

        //Methods for Customer Management
        int addCustomer(Customer customer);
        List<Customer> listCustomers();
        int removeCustomer(int customerID);
        Customer findCustomerById(int customerID);


        //Methods for Car management
        int addCar(Car car);
        int removeCar(int carID);
        List<Car> listAvailableCars();
        List<Car> listRentedCars();
        Car findCarById(int carID);


        //Methods for Lease Management
        int createLease(int customerID, int carID, DateTime startDate, DateTime endDate);
        void returnCar(int leaseID);
        List<Lease> listActiveLeases();
        List<Lease> listLeaseHistory();


        //Methods for Payment Management
        void recordPayment(Lease lease, double amount);
        List<Payment> listPayments(Lease lease);
    }
}
