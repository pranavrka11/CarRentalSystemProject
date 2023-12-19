

using CarRentalSystem.Dao;
using CarRentalSystem.Entities;
using CarRentalSystem.Exceptions;
using System.Collections;

bool inLoop = true;
while(inLoop)
{
    Console.WriteLine("\n");
    Console.WriteLine("--------Welcome to the Car Rental System--------");
    Console.WriteLine("Select an option:");
    Console.WriteLine("1. Customer Management");
    Console.WriteLine("2. Car Management");
    Console.WriteLine("3. Lease Management");
    Console.WriteLine("4. Payment Management");
    Console.WriteLine("5. Exit\n");

    Console.WriteLine("Enter your Choice: ");
    int choice = int.Parse(Console.ReadLine());
    int exitChoice;
    bool subLoop = true;
    int subLoopChoice;

    //Switch for Main Menu
    switch (choice)
    {
        //Customer Management Portal Submenu
        case 1:
            while(subLoop)
            {
                Console.WriteLine("\nWelcome to the  Customer Management Portal");
                Console.WriteLine("Here are your choices:");
                Console.WriteLine("1. Get All Customers");
                Console.WriteLine("2. Add a User");
                Console.WriteLine("3. Find a customer");
                Console.WriteLine("4. Remove a customer");
                Console.WriteLine("5. Go to Main Menu\n");
                Console.Write("Enter your choice: ");
                int customerChoice = int.Parse(Console.ReadLine());
                //Awitch for Customer Management Portal
                switch (customerChoice)
                {
                    case 1:
                        Console.WriteLine();
                        ICarLeaseRepositoryImpl customer = new CarLeaseRepositoryImpl();
                        List<Customer> l = customer.listCustomers();
                        Console.WriteLine();
                        foreach (var v in l)
                        {
                            Console.WriteLine(v);
                        }
                        Console.Write("\nTo go back to Customer Management Portal, press 1. To go back to main menu, press 2: ");
                        subLoopChoice= int.Parse(Console.ReadLine());
                        if (subLoopChoice == 2)
                            subLoop = false;
                        break;
                    case 2:
                        Console.WriteLine("\nTo add a user to the system, please enter following details:");
                        Console.Write("First Name: ");
                        string firstName= Console.ReadLine();
                        Console.Write("Last Name: ");
                        string lastName= Console.ReadLine();
                        Console.Write("Email: ");
                        string email= Console.ReadLine();
                        Console.Write("Phone Number: ");
                        string phone= Console.ReadLine();
                        Customer c = new Customer() { firstName = firstName, lastName = lastName, email = email, phone = phone };
                        ICarLeaseRepositoryImpl addCustomer = new CarLeaseRepositoryImpl();
                        int stat = addCustomer.addCustomer(c);
                        if (stat > 0)
                        {
                            Console.WriteLine("\nCustomer added successfully");
                        }
                        else
                            Console.WriteLine("\nSome error occured");
                        Console.Write("\nTo go back to Customer Management Portal, press 1. To go back to main menu, press 2: ");
                        subLoopChoice = int.Parse(Console.ReadLine());
                        if (subLoopChoice == 2)
                            subLoop = false;
                        break;
                    case 3:
                        Console.Write("\nPlease enter the ID of the Customer: ");
                        int custID= int.Parse(Console.ReadLine());
                        ICarLeaseRepositoryImpl findCustomer = new CarLeaseRepositoryImpl();
                        Customer c1 = new Customer();
                        try
                        {
                            c1 = findCustomer.findCustomerById(custID);
                            Console.WriteLine(c1);
                        }
                        catch (CustomerNotFoundException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        Console.Write("\nTo go back to Customer Management Portal, press 1. To go back to main menu, press 2: ");
                        subLoopChoice = int.Parse(Console.ReadLine());
                        if (subLoopChoice == 2)
                            subLoop = false;
                        break;
                    case 4:
                        Console.Write("\nPlease enter the ID of the customer you wish to remove from the system: ");
                        int cid= int.Parse(Console.ReadLine());
                        ICarLeaseRepositoryImpl removeCustomer=new CarLeaseRepositoryImpl();
                        int removeStatus=removeCustomer.removeCustomer(cid);
                        if (removeStatus > 0)
                        {
                            Console.WriteLine("\nCustomer removed successfully");
                        }
                        else
                        {
                            Console.WriteLine("\nIt seems like the customer you're trying to remove does not exist in the database");
                        }
                        Console.Write("\nTo go back to Customer Management Portal, press 1. To go back to main menu, press 2: ");
                        subLoopChoice = int.Parse(Console.ReadLine());
                        if (subLoopChoice == 2)
                            subLoop = false;
                        break;
                    case 5:
                        subLoop = false;
                        break;
                    default:
                        Console.WriteLine("\nPlease enter a valid choice");
                        break;
                }
            }
            break;

        //Car Management Portal Submenu
        case 2:
            while(subLoop)
            {
                Console.WriteLine("\nWelcome to the Car Management Portal");
                Console.WriteLine("Here are your choices:");
                Console.WriteLine("1. Get All cars that are available to lease");
                Console.WriteLine("2. Get All cars that are not available");
                Console.WriteLine("3. Add a car to the portal");
                Console.WriteLine("4. Remove a car");
                Console.WriteLine("5. Find a car by ID");
                Console.WriteLine("6. Go to Main Menu\n");
                Console.Write("Enter your choice: ");
                int carChoice = int.Parse(Console.ReadLine());

                //Switch for Car Management Portal Submenu
                switch(carChoice)
                {
                    case 1:
                        Console.WriteLine();
                        ICarLeaseRepositoryImpl carList = new CarLeaseRepositoryImpl();
                        List<Car> cars = new List<Car>();
                        cars= carList.listAvailableCars();
                        foreach (var v in cars)
                        {
                            Console.WriteLine(v);
                        }
                        Console.Write("\nTo go back to Car Management Portal, press 1. To go back to main menu, press 2: ");
                        subLoopChoice = int.Parse(Console.ReadLine());
                        if (subLoopChoice == 2)
                            subLoop = false;
                        break;
                    case 2:
                        Console.WriteLine();
                        ICarLeaseRepositoryImpl carList2=new CarLeaseRepositoryImpl();
                        List<Car> c1=carList2.listRentedCars();
                        foreach(var v in  c1)
                        {
                            Console.WriteLine(v);
                        }
                        Console.Write("\nTo go back to Car Management Portal, press 1. To go back to main menu, press 2: ");
                        subLoopChoice = int.Parse(Console.ReadLine());
                        if (subLoopChoice == 2)
                            subLoop = false;
                        break;
                    case 3:
                        Console.WriteLine("\nTo add a car to the portal, give following details: ");
                        Console.Write("Make: ");
                        string make = Console.ReadLine();
                        Console.Write("Model: ");
                        string model = Console.ReadLine();
                        Console.Write("Year: ");
                        int year=int.Parse(Console.ReadLine());
                        Console.Write("DailyRate: ");
                        double dr=double.Parse(Console.ReadLine());
                        Console.Write("Passenger Capacity: ");
                        int pc=int.Parse(Console.ReadLine());

                        ICarLeaseRepositoryImpl addCar=new CarLeaseRepositoryImpl();
                        Car c2 = new Car() { make = make, model = model, year=year, dailyRate=dr, passengerCapacity=pc };
                        int addStatus = addCar.addCar(c2);
                        if(addStatus > 0)
                            Console.WriteLine("\nCar added successfully");
                        else
                            Console.WriteLine("\nCar already exists");
                        Console.Write("\nTo go back to Car Management Portal, press 1. To go back to main menu, press 2: ");
                        subLoopChoice = int.Parse(Console.ReadLine());
                        if (subLoopChoice == 2)
                            subLoop = false;
                        break;
                    case 4:
                        Console.Write("\nEnter the ID of the car which you wish to remove from the Portal: ");
                        int removeID = int.Parse(Console.ReadLine());
                        ICarLeaseRepositoryImpl removeCar=new CarLeaseRepositoryImpl();
                        int removeStatus = removeCar.removeCar(removeID);
                        if(removeStatus>0)
                            Console.WriteLine("\nCar removed Successfully");
                        else
                            Console.WriteLine("\nIt seems like the customer you're trying to remove does not exist in the database");
                        Console.Write("\nTo go back to Car Management Portal, press 1. To go back to main menu, press 2: ");
                        subLoopChoice = int.Parse(Console.ReadLine());
                        if (subLoopChoice == 2)
                            subLoop = false;
                        break;
                    case 5:
                        Console.Write("\nTo get the information of a car, please enter the ID: ");
                        Console.WriteLine();
                        int findID=int.Parse(Console.ReadLine());
                        ICarLeaseRepositoryImpl findCar=new CarLeaseRepositoryImpl();
                        Car c3 = new Car();
                        try
                        {
                            c3 = findCar.findCarById(findID);
                            Console.WriteLine(c3);
                        }
                        catch(CarNotFoundException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        Console.Write("\nTo go back to Car Management Portal, press 1. To go back to main menu, press 2: ");
                        subLoopChoice = int.Parse(Console.ReadLine());
                        if (subLoopChoice == 2)
                            subLoop = false;
                        break;
                    case 6:
                        subLoop = false;
                        break;
                    default:
                        Console.WriteLine("\nPlease enter a valid choice");
                        break;
                }
            }
            break;
        //Lease Management Portal
        case 3:
            while(subLoop)
            {
                Console.WriteLine("\nWelcome to the Lease Management Portal");
                Console.WriteLine("Here are your choices:");
                Console.WriteLine("1. Lease a Car");
                Console.WriteLine("2. Get details of a specific lease");
                Console.WriteLine("3. View all the active leases");
                Console.WriteLine("4. View lease history");
                Console.WriteLine("5. Return a car to the lessor");
                Console.WriteLine("6. Go to Main Menu\n");
                Console.Write("Enter your choice: ");
                int leaseChoice = int.Parse(Console.ReadLine());

                switch(leaseChoice)
                {
                    case 1:
                        Console.WriteLine("\nLease agreement creation");
                        Console.WriteLine("Here are all the cars that are currently available to lease:\n");
                        ICarLeaseRepositoryImpl carLease = new CarLeaseRepositoryImpl();
                        List<Car> avblCars = carLease.listAvailableCars();
                        foreach(var v in avblCars)
                        {
                            Console.WriteLine(v);
                        }
                        Console.WriteLine("\nIf you lease a car for anywhere between 1 to 29 days, you will be charged with standard daily rates for the lease.");
                        Console.WriteLine("If you lease a car for an entire month, a discount of 20% will be applied to your total lease amount.");
                        Console.WriteLine("If you lease car for more than a month, rate will be calculated based on charges for a month plus additional days.");
                        Console.Write("\nPlease enter the ID of the car you would like to lease:");
                        int leaseCarId=int.Parse(Console.ReadLine());
                        Console.Write("Please enter your customer ID: ");
                        int customerid=int.Parse(Console.ReadLine());
                        Console.Write("Please enter the start date of the lease(YYYY-MM-DD):");
                        DateTime sDate=DateTime.Parse(Console.ReadLine());
                        Console.Write("Please enter the end date for the lease(YYYY-MM-DD):");
                        DateTime eDate=DateTime.Parse(Console.ReadLine());
                        Car c3 = new Car();
                        Lease lease = new Lease();
                        c3 = carLease.findCarById(leaseCarId);
                        if(c3.isAvailable=="available")
                        {
                            Console.WriteLine("\nHere are the details of your lease:");
                            Console.WriteLine($"Car ID: {c3.vehicleID}, Make: {c3.make}, Model: {c3.model}, Year: {c3.year}");
                            TimeSpan diff = eDate - sDate;
                            double totalAmount;
                            double finalAmount;
                            if(diff.Days<29)
                            {
                                finalAmount = diff.Days * c3.dailyRate;

                                Console.WriteLine($"Your total lease amount is: {finalAmount}");
                            }
                            else if(diff.Days==30)
                            {
                                totalAmount= diff.Days * c3.dailyRate;
                                finalAmount = totalAmount + (totalAmount * 0.2);
                                Console.WriteLine($"As you have created a monthly lease, the total lease amount after discount is: {finalAmount}");
                            }
                            else
                            {
                                int addDays = diff.Days - 30;
                                totalAmount = 30 * c3.dailyRate;
                                finalAmount = (totalAmount + (totalAmount * 0.2))+(addDays*c3.dailyRate);
                                Console.WriteLine($"Your total lease amount is: {finalAmount}");
                            }
                            Console.WriteLine("\nDo you wish to confirm the lease by making payment?(Press 1 if yes, 0 if no:)");
                            int leaseMakeChoice=int.Parse(Console.ReadLine());
                            if(leaseMakeChoice==1)
                            {
                                int leaseStatId=carLease.createLease(customerid, leaseCarId, sDate, eDate);
                                Console.WriteLine("\nSuccessfully created the lease agreement.");
                                Console.WriteLine("\nGenerating the payment");
                                carLease.recordPayment(sDate, finalAmount);
                                Thread.Sleep(3000);
                                Console.WriteLine("Payment successful!");
                                Console.WriteLine("\nHere are the details of your lease:\n");
                                Console.WriteLine($"Car make: {c3.make}\t Model: {c3.model}, Start Date: {sDate}\t End Date: {eDate}\t Total amount: {finalAmount}");
                                Console.WriteLine("\nThank you for choosing our Leasing Services. We wish you a safe and memorable experience!\n");                               
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nSorry, it seems the car you have selected is not available at the moment. Please enter correct car ID.");
                        }
                        Console.Write("\nTo go back to Lease Management Portal, press 1. To go back to main menu, press 2: ");
                        subLoopChoice = int.Parse(Console.ReadLine());
                        if (subLoopChoice == 2)
                            subLoop = false;
                        break;
                    case 2:
                        Console.Write("\nPlease enter the ID of the lease you wish to fetch details:");
                        int lid = int.Parse(Console.ReadLine());
                        ICarLeaseRepositoryImpl findLease = new CarLeaseRepositoryImpl();
                        try
                        {
                            ArrayList leasedata=findLease.displayLeaseInfo(lid);
                            Console.WriteLine($"\nHere are all the details of lease agreement with leaseID: {lid}:");
                            Console.WriteLine($"\nName of the customer: {leasedata[0]} {leasedata[1]}\t Make and Model of car: {leasedata[2]} {leasedata[3]}\n Start Date: {leasedata[4]}\t End Date: {leasedata[5]}\n");
                        }
                        catch (LeaseNotFoundException e)
                        {
                            Console.WriteLine();
                            Console.WriteLine(e.Message);
                        }
                        Console.Write("\nTo go back to Lease Management Portal, press 1. To go back to main menu, press 2: ");
                        subLoopChoice = int.Parse(Console.ReadLine());
                        if (subLoopChoice == 2)
                            subLoop = false;
                        break;
                    case 3:
                        Console.WriteLine();
                        ICarLeaseRepositoryImpl activeLease = new CarLeaseRepositoryImpl();
                        List<Lease> activeLeases=activeLease.listActiveLeases();
                        foreach(var v in activeLeases)
                        {
                            Console.WriteLine(v);
                        }
                        Console.Write("\nTo go back to Lease Management Portal, press 1. To go back to main menu, press 2: ");
                        subLoopChoice = int.Parse(Console.ReadLine());
                        if (subLoopChoice == 2)
                            subLoop = false;
                        break;
                    case 4:
                        Console.WriteLine();
                        ICarLeaseRepositoryImpl leaseHistoryObj = new CarLeaseRepositoryImpl();
                        List<Lease> leaseHistory=leaseHistoryObj.listLeaseHistory();
                        foreach(var v in leaseHistory)
                        {
                            Console.WriteLine(v);
                        }
                        Console.Write("\nTo go back to Lease Management Portal, press 1. To go back to main menu, press 2: ");
                        subLoopChoice = int.Parse(Console.ReadLine());
                        if (subLoopChoice == 2)
                            subLoop = false;
                        break;
                    case 5:
                        Console.Write("Enter the ID of the car which you'd like to return to the lessor: ");
                        int returnID=int.Parse(Console.ReadLine());
                        ICarLeaseRepositoryImpl returnCar = new CarLeaseRepositoryImpl();
                        int returnStatus = returnCar.returnCar(returnID);
                        if(returnStatus>0)
                            Console.WriteLine("Car returned successfully!");
                        else
                            Console.WriteLine("Something went wrong");
                        break;
                    case 6:
                        subLoop = false;
                        break;
                }
            }
            break;
        case 4:
            Console.WriteLine("\nWelcome to Payment Management Portal");
            Console.WriteLine("Here are the details of all the Payments:\n");
            ICarLeaseRepositoryImpl listPayment= new CarLeaseRepositoryImpl();
            List<Payment> paymentsList = listPayment.listPayments();
            foreach (var v in paymentsList)
            {
                Console.WriteLine(v);
            }
            break;
        case 5:
            Console.WriteLine("\nThank you! Visit Again");
            inLoop=false;
            break;
        default:
            Console.WriteLine("\nPlease enter a valid choice");
            break;
    }
}

//ICarLeaseRepositoryImpl customer=new CarLeaseRepositoryImpl();
//Customer c = new Customer() { customerID = 6, firstName = "Rohit", lastName = "Anant", email = "rohit@gmail.com", phone = "7796520120" };

//int stat = customer.addCustomer(c);
//if (stat > 0)
//{
//    Console.WriteLine("Customer added successfully");
//}
//else
//    Console.WriteLine("Some error occured");

//List<Customer> l=customer.listCustomers();
//foreach(var v in l)
//{
//    Console.WriteLine(v);
//}

//Customer c=new Customer();
//c=customer.findCustomerById(4);
//Console.WriteLine($"Customer Name: {c.FirstName} {c.LastName}\t Email: {c.email}\t Phone Number: {c.phone}");

//int s = customer.removeCustomer(6);
//if (s > 0)
//{
//    Console.WriteLine("Customer removed successfully");
//}
//else
//{
//    Console.WriteLine("Some error occured");
//}

//List<Customer> l=customer.listCustomers();
//foreach(Customer cs in l)
//{
//    Console.WriteLine(cs);
//}