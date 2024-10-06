using Garage1._0.Interface; // Importing the required interface for UI functionalities

namespace Garage1._0
{
    // UI class to manage the user interface and interact with the garage system
    public class UI : IUI
    {
        // Reference to the handler responsible for handling operations
        public IHandler handler;

        // Garage instance to manage vehicles within the garage
        public Garage<IVehicle> garage;

        // Constructor to initialize the UI with a handler and a garage
        public UI(IHandler handler, Garage<IVehicle> garage)
        {
            this.handler = handler;
            this.garage = garage;
        }

        // Method to display the main menu options to the user
        public void DisplayMenu()
        {
            Console.WriteLine("Garage Management System");
            Console.WriteLine("-------------------------");
            Console.WriteLine("1. Park a vehicle");
            Console.WriteLine("2. Display vehicle list");
            Console.WriteLine("3. Display vehicle types");
            Console.WriteLine("4. Remove a vehicle");
            Console.WriteLine("5. Search for vehicles");
            Console.WriteLine("6. Create a new garage");
            Console.WriteLine("7. Exit application");
        }

        // Method to exit the application gracefully
        public void ExitApplication()
        {
            Console.WriteLine("Exiting application...");
            Environment.Exit(0); // Exits the application with a status code of 0 (normal exit)
        }
    }
}
