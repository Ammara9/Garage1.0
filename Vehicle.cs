using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garage1._0.Interface;

namespace Garage1._0
{
    public class Vehicle : IVehicle
    {
        public string RegistrationNumber { get; set; }
        public string Color { get; set; }
        public int NumberOfWheels { get; set; }

        public Vehicle(string registrationNumber, string color, int numberOfWheels)
        {
            RegistrationNumber = registrationNumber;
            Color = color;
            NumberOfWheels = numberOfWheels;
        }
    }

    public class Motorcycle : Vehicle
    {
        public int CylinderVolume { get; set; }

        public Motorcycle(
            string registrationNumber,
            string color,
            int numberOfWheels,
            int cylinderVolume
        )
            : base(registrationNumber, color, numberOfWheels)
        {
            CylinderVolume = cylinderVolume;
        }

        // Override ToString in Motorcycle
        public override string ToString()
        {
            return $"{base.ToString()}, CylinderVolume: {CylinderVolume} cc";
        }
    }

    public class Car : Vehicle
    {
        public string FuelType { get; set; }

        public Car(string registrationNumber, string color, int numberOfWheels, string fuelType)
            : base(registrationNumber, color, numberOfWheels)
        {
            FuelType = fuelType;
        }

        // Override ToString in Car
        public override string ToString()
        {
            return $"{base.ToString()}, FuelType: {FuelType}";
        }
    }

    public class Bus : Vehicle
    {
        public int NumberOfSeats { get; set; }

        public Bus(string registrationNumber, string color, int numberOfWheels, int numberOfSeats)
            : base(registrationNumber, color, numberOfWheels)
        {
            NumberOfSeats = numberOfSeats;
        }

        // Override ToString in Bus
        public override string ToString()
        {
            return $"{base.ToString()}, NumberOfSeats: {NumberOfSeats}";
        }
    }
}
