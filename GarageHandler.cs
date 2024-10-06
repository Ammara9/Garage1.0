using System; // Importing essential namespaces for basic functionalities
using System.Collections.Generic; // For working with generic collections
using System.Linq; // Provides LINQ functionalities
using System.Text; // Provides support for string manipulation
using System.Threading.Tasks; // Enables asynchronous programming
using Garage1._0.Interface; // Imports necessary interfaces defined in the project

namespace Garage1._0
{
    // The GarageHandler class handles user interaction and garage operations
    public class GarageHandler : IHandler
    {
        // UI instance to handle user interface actions
        public UI ui;

        // Garage instance to manage the garage and its vehicles
        public Garage<IVehicle> garage;

        // Constructor to initialize the GarageHandler with a UI and a garage
        public GarageHandler(UI ui, Garage<IVehicle> garage)
        {
            this.ui = ui;
            this.garage = garage;
        }

        // Method to handle input from the main menu and trigger corresponding actions
        public void HandleMenuInput()
        {
            while (true)
            {
                ui.DisplayMenu(); // Display the menu options to the user
                Console.WriteLine("Please Enter Your Choice: ");
                string? input = Console.ReadLine(); // Read the user's input

                // Switch to handle different menu options based on user input
                switch (input)
                {
                    case "1":
                        HandleAddVehicle(); // Add a new vehicle to the garage
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;

                    case "2":
                        garage.DisplayVehicles(); // Display all vehicles in the garage
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;

                    case "3":
                        garage.DisplayVehicleType(); // Display vehicle types and counts
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;

                    case "4":
                        HandleRemoveVehicle(); // Remove a vehicle from the garage
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;

                    case "5":
                        garage.SearchVehicle(); // Search for a vehicle by its attributes
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;

                    case "6":
                        HandleCreateGarage(); // Create a new garage with a specified capacity
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;

                    case "7":
                        ui.ExitApplication(); // Exit the application
                        break;

                    default:
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 7.");
                        break;
                }
            }
        }

        // Method to handle adding a vehicle to the garage
        public void HandleAddVehicle()
        {
            while (true)
            {
                Console.WriteLine("Enter Registration number: ");
                string? registrationNumber = Console.ReadLine();

                // Validate the registration number input
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

                    // Validate the color input
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
                    // Validate number of wheels input
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
                // Get vehicle type input from the user
                Console.Write("Enter vehicle type (1 - Motorcycle, 2 - Car, 3 - Bus): ");
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

                // Handle vehicle creation based on the selected type
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
                        Console.Write("Enter fuel type (Gasoline/Diesel): ");
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

                garage.AddVehicle(vehicle); // Add the created vehicle to the garage
                break;
            }
        }

        // Method to validate the vehicle's color input
        private bool IsValidColor(string? color)
        {
            if (string.IsNullOrEmpty(color))
            {
                return false;
            }

            var regex = new System.Text.RegularExpressions.Regex("^[a-zA-Z]+$"); // Color should contain only alphabets
            return regex.IsMatch(color);
        }

        // Method to validate the registration number input
        private bool IsValidRegistrationNumber(string? registrationNumber)
        {
            if (string.IsNullOrEmpty(registrationNumber))
            {
                return false;
            }

            var regex = new System.Text.RegularExpressions.Regex("^[a-zA-Z0-9]{4,8}$"); // Registration number validation: 4-8 alphanumeric characters
            return regex.IsMatch(registrationNumber);
        }

        // Method to handle vehicle removal from the garage
        public void HandleRemoveVehicle()
        {
            Console.Write("Enter registration number to remove the vehicle: ");
            string? registrationNumber = Console.ReadLine();

            garage.RemoveVehicle(registrationNumber!); // Remove the vehicle by its registration number
        }

        // Method to handle creating a new garage
        public void HandleCreateGarage()
        {
            Console.Write("Enter garage capacity: ");
            int capacity = Convert.ToInt32(Console.ReadLine());

            // Create a new garage with the specified capacity
            Garage<IVehicle> garage = Garage<IVehicle>.CreateGarage(capacity);

            Console.WriteLine($"Garage created with capacity {capacity}."); // Confirmation message for garage creation
        }
    }
}
