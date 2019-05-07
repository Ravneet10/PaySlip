using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.VehicleSystem.Interface
{
   public interface IUnitOfWork:IDisposable
    {
        IVehicleRepository Vehicles { get; }
        int Complete();
    }
}
