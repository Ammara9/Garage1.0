using Garage1._0.Interface;

namespace Garage1._0
{
    public class UI : IUI
    {
        public IHandler handler;
        public Garage<IVehicle> garage;

        public UI(IHandler handler, Garage<IVehicle> garage)
        {
            this.handler = handler;
            this.garage = garage;
        }

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

        public void ExitApplication()
        {
            Console.WriteLine("Exiting application...");
            Environment.Exit(0);
        }
    }
}
