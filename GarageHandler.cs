using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garage1._0.Interface;

namespace Garage1._0
{
    public class GarageHandler : IHandler
    {
        public UI ui;
        public Garage<IVehicle> garage;

        public GarageHandler(UI ui, Garage<IVehicle> garage)
        {
            this.ui = ui;
            this.garage = garage;
        }

        public void HandleMenuInput()
        {
            while (true)
            {
                ui.DisplayMenu();
                Console.WriteLine("Please Enter Your Choice: ");
                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        HandleAddVehicle();
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;

                    case "2":
                        garage.DisplayVehicles();
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;

                    case "3":
                        garage.DisplayVehicleType();
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;

                    case "4":
                        HandleRemoveVehicle();
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case "5":
                        garage.SearchVehicle();
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case "7":
                        ui.ExitApplication();
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 7.");
                        break;
                }
            }
        }

        public void HandleAddVehicle()
        {
            while (true)
            {
                Console.WriteLine("Enter Registeration number: ");
                string? registrationNumber = Console.ReadLine();

                // Validate registration number
                if (!IsValidRegistrationNumber(registrationNumber))
                {
                    Console.WriteLine(
                        "Invalid registration number. Please enter a number between 4 and 8 characters long, containing only letters and numbers."
                    );
                    continue;
                }

                string? color;
                while (true)
                {
                    Console.WriteLine("Enter Color: ");
                    color = Console.ReadLine();

                    // Validate color
                    if (!IsValidColor(color))
                    {
                        Console.WriteLine(
                            "Invalid color. Please enter a color containing only alphabets."
                        );
                        continue;
                    }

                    break;
                }

                int numberOfWheels;
                while (true)
                {
                    Console.WriteLine("Enter number of wheels: ");
                    if (int.TryParse(Console.ReadLine(), out numberOfWheels))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }
                }

                IVehicle vehicle;
                Console.Write(
                    "Enter vehicle type " + "(1 - Motorcycle, " + "2 - Car, " + "3 - Bus): "
                );
                int vehicleType;
                while (true)
                {
                    if (
                        int.TryParse(Console.ReadLine(), out vehicleType)
                        && vehicleType >= 1
                        && vehicleType <= 3
                    )
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
                    }
                }

                switch (vehicleType)
                {
                    case 1:
                        int cylinderVolume;
                        while (true)
                        {
                            Console.Write("Enter cylinder volume: ");
                            if (int.TryParse(Console.ReadLine(), out cylinderVolume))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a valid number.");
                            }
                        }
                        vehicle = new Motorcycle(
                            registrationNumber!,
                            color!,
                            numberOfWheels,
                            cylinderVolume
                        );
                        break;
                    case 2:
                        Console.Write("Enter fuel type (" + "Gasoline" + "/Diesel): ");
                        string? fuelType = Console.ReadLine();
                        vehicle = new Car(registrationNumber!, color!, numberOfWheels, fuelType!);
                        break;
                    case 3:
                        int numberOfSeats;
                        while (true)
                        {
                            Console.Write("Enter number of seats: ");
                            if (int.TryParse(Console.ReadLine(), out numberOfSeats))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a valid number.");
                            }
                        }
                        vehicle = new Bus(
                            registrationNumber!,
                            color!,
                            numberOfWheels,
                            numberOfSeats
                        );
                        break;
                    default:
                        Console.WriteLine("Invalid vehicle type. Please try again.");
                        continue;
                }

                garage.AddVehicle(vehicle); // Add the vehicle to the garage
                break;
            }
        }

        private bool IsValidColor(string? color)
        {
            if (string.IsNullOrEmpty(color))
            {
                return false;
            }

            var regex = new System.Text.RegularExpressions.Regex("^[a-zA-Z]+$");
            return regex.IsMatch(color);
        }

        private bool IsValidRegistrationNumber(string? registrationNumber)
        {
            if (string.IsNullOrEmpty(registrationNumber))
            {
                return false;
            }

            var regex = new System.Text.RegularExpressions.Regex("^[a-zA-Z0-9]{4,8}$");
            return regex.IsMatch(registrationNumber);
        }

        public void HandleRemoveVehicle()
        {
            Console.Write("Enter registration number to remove the vehicle: ");
            string? registrationNumber = Console.ReadLine();

            garage.RemoveVehicle(registrationNumber!);
        }
    }
}
