using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Entities
{
    internal class MotorCycle:Vehicle
    {
        int engineCapacity;

        public MotorCycle(int id, string make, string model, int year, double dailyRate, string isAvailable, int engineCapacity):base(id, make, model, year, dailyRate, isAvailable)
        {
            this.engineCapacity = engineCapacity;
        }

        public int EngineCapacity
        {
            get { return engineCapacity; }
            set { engineCapacity = value; }
        }
    }
}
