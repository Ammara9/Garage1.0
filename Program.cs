using System.IO;
using System.Text.Json;
using Garage1._0.Interface;

namespace Garage1._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a new garage with a capacity of 10 vehicles
            Garage<IVehicle> garage1 = new Garage<IVehicle>(10);

            // Create a new GarageHandler instance and pass the garage to it
            GarageHandler handler = new GarageHandler(null!, garage1);

            // Create a new UI instance and pass the handler and garage to it
            UI ui = new UI(handler, garage1);

            // Update the handler's UI reference
            handler.ui = ui;

            // Start the program by calling the HandleMenuInput method
            handler.HandleMenuInput();
        }
    }
}
