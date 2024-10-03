using Garage1._0.Interface;

namespace Garage1._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a new garage with a capacity of 10 vehicles
            Garage<IVehicle> garage = new Garage<IVehicle>(10);

            // Create a new GarageHandler instance and pass the garage to it
            GarageHandler handler = new GarageHandler(null, garage);

            // Create a new UI instance and pass the handler and garage to it
            UI ui = new UI(handler, garage);

            // Update the handler's UI reference
            handler.ui = ui;

            // Start the program by calling the HandleMenuInput method
            handler.HandleMenuInput();
        }
    }
}
