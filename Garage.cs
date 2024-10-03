using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garage1._0.Interface;

namespace Garage1._0
{
    public class Garage<T> : IEnumerable<T>
        where T : IVehicle
    {
        public T[] vehicles;
        public int capacity;
        public int count;

        //constructor capacity of garage
        public Garage(int capacity)
        {
            this.capacity = capacity;
            //this.vehicles = new T[capacity];
            vehicles = new T[capacity];
            count = 3;

            vehicles[0] = (T)(object)new Car("Car123", "Red", 4, "Diesesl");
            vehicles[1] = (T)(object)new Motorcycle("Motorcycle456", "Blue", 2, 500);
            vehicles[2] = (T)(object)new Bus("Bus789", "Red", 4, 2000);
        }

        // Method to add vehicle in the garage
        public void AddVehicle(T vehicle)
        {
            if (count < capacity)
            {
                vehicles[count] = vehicle;
                count++;
                Console.WriteLine(
                    $"Vehicle {vehicle.RegistrationNumber} {vehicle.Color} colour {vehicle.NumberOfWheels} wheels, Parked to garage successfully!"
                );
            }
            else
            {
                Console.WriteLine("Garage is full. Cannot Park more vehicles.");
            }
        }

        public void DisplayVehicles()
        {
            Console.WriteLine($"Garage has {count} vehicles:");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(
                    $"  {i + 1} - {vehicles[i].RegistrationNumber} {vehicles[i].Color} colour {vehicles[i].NumberOfWheels} wheels"
                );
            }
        }

        public void RemoveVehicle(string registrationNumber)
        {
            for (int i = 0; i < count; i++)
            {
                if (vehicles[i].RegistrationNumber == registrationNumber)
                {
                    // Store the removed vehicle's details
                    string removedRegistrationNumber = vehicles[i].RegistrationNumber;
                    string removedColor = vehicles[i].Color;
                    int removedNumberOfWheels = vehicles[i].NumberOfWheels;

                    // Shift all vehicles after the removed vehicle down by one position
                    for (int j = i; j < count - 1; j++)
                    {
                        vehicles[j] = vehicles[j + 1];
                    }
                    count--;
                    Console.WriteLine(
                        $"Vehicle {removedRegistrationNumber} {removedColor} colour {removedNumberOfWheels} wheels removed successfully."
                    );
                    return;
                }
            }
            Console.WriteLine($"Vehicle with registration number {registrationNumber} not found.");
        }

        public void DisplayVehicleType()
        {
            int motorcycleCount = 0;
            int carCount = 0;
            int busCount = 0;

            for (int i = 0; i < count; i++)
            {
                if (vehicles[i] is Motorcycle)
                {
                    motorcycleCount++;
                }
                else if (vehicles[i] is Car)
                {
                    carCount++;
                }
                else if (vehicles[i] is Bus)
                {
                    busCount++;
                }
            }

            Console.WriteLine("Vehicle Types:");
            Console.WriteLine($"  Motorcycles: {motorcycleCount}");
            Console.WriteLine($"  Cars: {carCount}");
            Console.WriteLine($"  Buses: {busCount}");

            Console.WriteLine("Vehicle Details:");
            for (int i = 0; i < count; i++)
            {
                if (vehicles[i] is Motorcycle motorcycle)
                {
                    Console.WriteLine(
                        $"  Motorcycle: {motorcycle.RegistrationNumber} {motorcycle.Color} colour {motorcycle.NumberOfWheels} wheels, Cylinder Volume: {motorcycle.CylinderVolume}"
                    );
                }
                else if (vehicles[i] is Car car)
                {
                    Console.WriteLine(
                        $"  Car: {car.RegistrationNumber} {car.Color} colour {car.NumberOfWheels} wheels, Fuel Type: {car.FuelType}"
                    );
                }
                else if (vehicles[i] is Bus bus)
                {
                    Console.WriteLine(
                        $"  Bus: {bus.RegistrationNumber} {bus.Color} colour {bus.NumberOfWheels} wheels, Number of Seats: {bus.NumberOfSeats}"
                    );
                }
            }
        }

        public void SearchVehicle()
        {
            Console.Write("Enter search term: ");
            string? searchTerm = Console.ReadLine();

            bool found = false;

            for (int i = 0; i < count; i++)
            {
                if (
                    vehicles[i]
                        .RegistrationNumber.Contains(
                            searchTerm!,
                            StringComparison.OrdinalIgnoreCase
                        )
                    || vehicles[i].Color.Contains(searchTerm!, StringComparison.OrdinalIgnoreCase)
                    || vehicles[i]
                        .NumberOfWheels.ToString()
                        .Contains(searchTerm!, StringComparison.OrdinalIgnoreCase)
                )
                {
                    Console.WriteLine(
                        $"  {i + 1} - {vehicles[i].RegistrationNumber} {vehicles[i].Color} colour {vehicles[i].NumberOfWheels} wheels"
                    );
                    found = true;

                    if (vehicles[i] is Motorcycle motorcycle)
                    {
                        Console.WriteLine($"    Cylinder Volume: {motorcycle.CylinderVolume}");
                    }
                    else if (vehicles[i] is Car car)
                    {
                        Console.WriteLine($"    Fuel Type: {car.FuelType}");
                    }
                    else if (vehicles[i] is Bus bus)
                    {
                        Console.WriteLine($"    Number of Seats: {bus.NumberOfSeats}");
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine("No vehicles found matching the search term.");
            }
        }

        public void CreateGarage() { }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)vehicles).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
