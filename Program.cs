

using CarRentalSystem.Dao;
using CarRentalSystem.Entities;

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
                Console.WriteLine("Enter your choice: ");
                int customerChoice = int.Parse(Console.ReadLine());
                //Awitch for Customer Management Portal
                switch (customerChoice)
                {
                    case 1:
                        ICarLeaseRepositoryImpl customer = new CarLeaseRepositoryImpl();
                        List<Customer> l = customer.listCustomers();
                        Console.WriteLine();
                        foreach (var v in l)
                        {
                            Console.WriteLine(v);
                        }
                        Console.WriteLine("\nTo go back to Customer Management Portal, press 1. To go back to main menu, press 2");
                        subLoopChoice= int.Parse(Console.ReadLine());
                        if (subLoopChoice == 2)
                            subLoop = false;
                        break;
                    case 2:
                        Console.WriteLine("\nTo add a user to the system, please enter following details:");
                        Console.WriteLine("User ID: ");
                        int userID= int.Parse(Console.ReadLine());
                        Console.WriteLine("First Name: ");
                        string firstName= Console.ReadLine();
                        Console.WriteLine("Last Name: ");
                        string lastName= Console.ReadLine();
                        Console.WriteLine("Email: ");
                        string email= Console.ReadLine();
                        Console.WriteLine("Phone Number: ");
                        string phone= Console.ReadLine();
                        Customer c = new Customer() { customerID = userID, firstName = firstName, lastName = lastName, email = email, phone = phone };
                        ICarLeaseRepositoryImpl addCustomer = new CarLeaseRepositoryImpl();
                        int stat = addCustomer.addCustomer(c);
                        if (stat > 0)
                        {
                            Console.WriteLine("Customer added successfully");
                        }
                        else
                            Console.WriteLine("Some error occured");
                        Console.WriteLine("\nTo go back to Customer Management Portal, press 1. To go back to main menu, press 2");
                        subLoopChoice = int.Parse(Console.ReadLine());
                        if (subLoopChoice == 2)
                            subLoop = false;
                        break;
                    case 3:
                        Console.WriteLine("Please enter the ID of the Customer: ");
                        int custID= int.Parse(Console.ReadLine());
                        ICarLeaseRepositoryImpl findCustomer = new CarLeaseRepositoryImpl();
                        Customer c1 = new Customer();
                        c1 = findCustomer.findCustomerById(custID);
                        if(c1.customerID!=0)
                            Console.WriteLine($"Customer Name: {c1.FirstName} {c1.LastName}\t Email: {c1.email}\t Phone Number: {c1.phone}");
                        else
                            Console.WriteLine("Customer Not Found");
                        Console.WriteLine("\nTo go back to Customer Management Portal, press 1. To go back to main menu, press 2");
                        subLoopChoice = int.Parse(Console.ReadLine());
                        if (subLoopChoice == 2)
                            subLoop = false;
                        break;
                    case 4:
                        Console.WriteLine("\nPlease enter the ID of the customer you wish to remove from the system: ");
                        int cid= int.Parse(Console.ReadLine());
                        ICarLeaseRepositoryImpl removeCustomer=new CarLeaseRepositoryImpl();
                        int removeStatus=removeCustomer.removeCustomer(cid);
                        if (removeStatus > 0)
                        {
                            Console.WriteLine("Customer removed successfully");
                        }
                        else
                        {
                            Console.WriteLine("It seems like the customer you're trying to remove does not exist in the database");
                        }
                        Console.WriteLine("\nTo go back to Customer Management Portal, press 1. To go back to main menu, press 2");
                        subLoopChoice = int.Parse(Console.ReadLine());
                        if (subLoopChoice == 2)
                            subLoop = false;
                        break;
                    case 5:
                        subLoop = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid choice");
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
                Console.WriteLine("Enter your choice: ");
                int carChoice = int.Parse(Console.ReadLine());

                //Switch for Car Management Portal Submenu
                switch(carChoice)
                {
                    case 1:
                        ICarLeaseRepositoryImpl carList = new CarLeaseRepositoryImpl();
                        List<Car> cars = new List<Car>();
                        cars= carList.listAvailableCars();
                        foreach (var v in cars)
                        {
                            Console.WriteLine(v);
                        }
                        Console.WriteLine("\nTo go back to Car Management Portal, press 1. To go back to main menu, press 2");
                        subLoopChoice = int.Parse(Console.ReadLine());
                        if (subLoopChoice == 2)
                            subLoop = false;
                        break;
                    case 2:
                        ICarLeaseRepositoryImpl carList2=new CarLeaseRepositoryImpl();
                        List<Car> c1=carList2.listRentedCars();
                        foreach(var v in  c1)
                        {
                            Console.WriteLine(v);
                        }
                        Console.WriteLine("\nTo go back to Car Management Portal, press 1. To go back to main menu, press 2");
                        subLoopChoice = int.Parse(Console.ReadLine());
                        if (subLoopChoice == 2)
                            subLoop = false;
                        break;
                    case 3:
                        Console.WriteLine("To add a car to the portal, give following details: ");
                        Console.WriteLine("ID: ");
                        int id=int.Parse(Console.ReadLine());
                        Console.WriteLine("Make: ");
                        string make = Console.ReadLine();
                        Console.WriteLine("Model: ");
                        string model = Console.ReadLine();
                        Console.WriteLine("Year: ");
                        int year=int.Parse(Console.ReadLine());
                        Console.WriteLine("DailyRate: ");
                        double dr=double.Parse(Console.ReadLine());
                        Console.WriteLine("Passenger Capacity: ");
                        int pc=int.Parse(Console.ReadLine());

                        ICarLeaseRepositoryImpl addCar=new CarLeaseRepositoryImpl();
                        Car c2 = new Car() { vehicleID = id, make = make, model = model, year=year, dailyRate=dr, passengerCapacity=pc };
                        int addStatus = addCar.addCar(c2);
                        if(addStatus > 0)
                            Console.WriteLine("Car added successfully");
                        else
                            Console.WriteLine("Car already exists");
                        Console.WriteLine("\nTo go back to Car Management Portal, press 1. To go back to main menu, press 2");
                        subLoopChoice = int.Parse(Console.ReadLine());
                        if (subLoopChoice == 2)
                            subLoop = false;
                        break;
                    case 4:
                        Console.WriteLine("Enter the ID of the car which you wish to remove from the Portal: ");
                        int removeID = int.Parse(Console.ReadLine());
                        ICarLeaseRepositoryImpl removeCar=new CarLeaseRepositoryImpl();
                        int removeStatus = removeCar.removeCar(removeID);
                        if(removeStatus>0)
                            Console.WriteLine("Car removed Successfully");
                        else
                            Console.WriteLine("It seems like the customer you're trying to remove does not exist in the database");
                        Console.WriteLine("\nTo go back to Car Management Portal, press 1. To go back to main menu, press 2");
                        subLoopChoice = int.Parse(Console.ReadLine());
                        if (subLoopChoice == 2)
                            subLoop = false;
                        break;
                    case 5:
                        Console.WriteLine("To get the information of a car, please enter the ID: ");
                        int findID=int.Parse(Console.ReadLine());
                        ICarLeaseRepositoryImpl findCar=new CarLeaseRepositoryImpl();
                        Car c3 = new Car();
                        c3 = findCar.findCarById(findID);
                        
                        if(c3.vehicleID!=0)
                            Console.WriteLine($"Car ID: {c3.vehicleID}\t Make: {c3.make}\t Model: {c3.model}\t Year: {c3.year}");
                        else
                            Console.WriteLine("Car not found");
                        Console.WriteLine("\nTo go back to Car Management Portal, press 1. To go back to main menu, press 2");
                        subLoopChoice = int.Parse(Console.ReadLine());
                        if (subLoopChoice == 2)
                            subLoop = false;
                        break;
                    case 6:
                        subLoop = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid choice");
                        break;
                }
            }
            break;
        case 3:
            while(subLoop)
            {
                Console.WriteLine("\nWelcome to the Lease Management Portal");
                Console.WriteLine("Here are your choices:");
                Console.WriteLine("1. Lease a Car");
                Console.WriteLine("2. Get details of a specific lease");
                Console.WriteLine("3. View all the active leases");
                Console.WriteLine("4. View lease history");
                Console.WriteLine("5. Go to Main Menu\n");
                Console.WriteLine("Enter your choice: ");
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
                        Console.WriteLine("\nPlease enter the ID of the car you would like to lease:");
                        int leaseCarId=int.Parse(Console.ReadLine());
                        Console.WriteLine("Please enter your customer ID: ");
                        int customerid=int.Parse(Console.ReadLine());
                        Console.WriteLine("Please enter the start date of the lease(YYYY-MM-DD):");
                        DateTime sDate=DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Please enter the end date for the lease(YYYY-MM-DD):");
                        DateTime eDate=DateTime.Parse(Console.ReadLine());
                        Car c3 = new Car();
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
                            Console.WriteLine("\nDo you wish to confirm the lease?(Press 1 if yes, 0 if no:)");
                            int leaseMakeChoice=int.Parse(Console.ReadLine());
                            if(leaseMakeChoice==1)
                            {
                                int leaseStatus=carLease.createLease(customerid, leaseCarId, sDate, eDate);
                                if(leaseStatus>0)
                                {
                                    Console.WriteLine("\nSuccessfully created the lease agreement.");
                                    Console.WriteLine("Generating the payment");
                                    Thread.Sleep(3000);
                                    Console.WriteLine("Payment successful!");
                                    Console.WriteLine("\nHere are the details of your lease:");
                                    Console.WriteLine($"Lease ID:{leaseStatus}\t Car make: {c3.make}\t Model: {c3.model}, Start Date: {sDate}\t End Date: {eDate}");
                                    Console.WriteLine("Thank you for choosing our Leasing Services. We wish you a safe and memorable experience!");
                                }
                                else
                                    Console.WriteLine("It seems there was some problem with creating your lease. Please try again.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Sorry, it seems the car you have selected is not available at the moment. Please enter correct car ID.");
                        }
                        break;
                    case 5:
                        subLoop = false;
                        break;
                }
            }

            //Console.WriteLine("Do you wish to exit?(1 or 0)");
            //exitChoice = int.Parse(Console.ReadLine());
            //if (exitChoice == 1)
            //{
            //    inLoop = false;
            //    Console.WriteLine("Thank you! Visit Again");
            //}
            break;
        case 4:
            Console.WriteLine("This is Payment Management Portal");
            Console.WriteLine("Do you wish to exit?(1 or 0)");
            exitChoice = int.Parse(Console.ReadLine());
            if (exitChoice == 1)
            {
                inLoop = false;
                Console.WriteLine("Thank you! Visit Again");
            }
            break;
        case 5:
            Console.WriteLine("\nThank you! Visit Again");
            inLoop=false;
            break;
        default:
            Console.WriteLine("Please enter a valid choice");
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