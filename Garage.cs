using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garage1._0.Interface;

// Garage class implementation
// This class represents a garage that can hold a certain number of vehicles
// It provides methods to add, remove, display, and search vehicles
namespace Garage1._0
{
    // Garage class that implements IEnumerable<T> interface
    public class Garage<T> : IEnumerable<T>
        where T : IVehicle
    {
        // Array to store vehicles
        public T[] vehicles;

        // Capacity of the garage
        public int capacity;

        // Count of vehicles currently in the garage
        public int count;

        // Constructor to initialize the garage with a given capacity
        public Garage(int capacity)
        {
            // Initialize capacity and count
            this.capacity = capacity;
            vehicles = new T[capacity];
            count = 3;

            // Initialize some sample vehicles
            vehicles[0] = (T)(object)new Car("Car123", "Red", 4, "Diesel");
            vehicles[1] = (T)(object)new Motorcycle("Motorcycle456", "Blue", 2, 500);
            vehicles[2] = (T)(object)new Bus("Bus789", "Red", 4, 2000);
        }

        // Method to add a vehicle to the garage
        public void AddVehicle(T vehicle)
        {
            // Check if the garage is not full
            if (count < capacity)
            {
                // Add the vehicle to the array
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

        // Method to display all vehicles in the garage
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

        // Method to remove a vehicle from the garage
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

        // Method to display the count of each vehicle type
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

        // Method to search for vehicles based on a search term
        public void SearchVehicle()
        {
            Console.Write("Enter search term (e.g., black 4 , pink 3, truck): ");
            string? searchTerm = Console.ReadLine();

            string[] searchTerms = searchTerm!.Split(' ');

            bool found = false;

            for (int i = 0; i < count; i++)
            {
                bool match = true;

                foreach (string term in searchTerms)
                {
                    if (term.ToLower() == "motorcycle" && !(vehicles[i] is Motorcycle))
                    {
                        match = false;
                        break;
                    }
                    else if (term.ToLower() == "car" && !(vehicles[i] is Car))
                    {
                        match = false;
                        break;
                    }
                    else if (term.ToLower() == "bus" && !(vehicles[i] is Bus))
                    {
                        match = false;
                        break;
                    }
                    else if (
                        !vehicles[i]
                            .RegistrationNumber.Contains(term, StringComparison.OrdinalIgnoreCase)
                        && !vehicles[i].Color.Contains(term, StringComparison.OrdinalIgnoreCase)
                        && !vehicles[i]
                            .NumberOfWheels.ToString()
                            .Contains(term, StringComparison.OrdinalIgnoreCase)
                    )
                    {
                        match = false;
                        break;
                    }
                }

                if (match)
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

        // Method to create a garage
        // Static method to create a garage
        public static Garage<IVehicle> CreateGarage(int capacity)
        {
            return new Garage<IVehicle>(capacity);
        }

        // GetEnumerator method implementation for IEnumerable<T> interface
        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)vehicles).GetEnumerator();
        }

        // GetEnumerator method implementation for IEnumerable interface
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
