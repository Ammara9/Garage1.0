using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage1._0.Interface
{
    public interface IVehicle
    {
        string RegistrationNumber { get; set; }
        string Color { get; set; }
        int NumberOfWheels { get; set; }
    }
}
