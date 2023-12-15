using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Entities
{
    internal class Car : Vehicle
    {
        public int passengerCapacity;

        public Car()
        {
        }

        //public Car()
        //{
        //}

        public Car(int vehicleID, string make, string model, int year, double dailyRate, string isAvailable, int passengerCapacity) : base(vehicleID, make, model, year, dailyRate, isAvailable)
        {
            this.passengerCapacity = passengerCapacity;
        }

        public override string ToString()
        {
            return $"Car ID: {vehicleID}\t Car Make: {make}\t Model: {model}\t Year: {year}\t Daily Rate: {dailyRate}";
        }
    };
}
