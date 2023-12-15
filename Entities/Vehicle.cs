using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Entities
{
    internal class Vehicle
    {
        public int vehicleID;
        public string make;
        public string model;
        public int year;
        public double dailyRate;
        public string isAvailable;

        public Vehicle() { }

        public Vehicle(int vehicleID, string make, string model, int year, double dailyRate, string isAvailable)
        {
            this.vehicleID = vehicleID;
            this.make = make;
            this.model = model;
            this.year = year;
            this.dailyRate = dailyRate;
            this.isAvailable = isAvailable;
        }

        public int VehicleID
        {
            get { return vehicleID; }
            set { vehicleID = value; }
        }

        public string Make 
        { 
            get { return make; } 
            set { make = value; } 
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public double DailyRate
        {
            get { return dailyRate; }
            set { dailyRate = value; }
        }

        public string IsAvailable
        {
            get { return isAvailable; }
            set { isAvailable = value; }
        }
    }
}
