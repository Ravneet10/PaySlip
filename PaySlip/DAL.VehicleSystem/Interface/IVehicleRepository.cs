using DAL.VehicleSystem.DALEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.VehicleSystem.Interface
{
    public interface IVehicleRepository:IRepository<VehicleEntity>
    {
        void Save(VehicleEntity vehicleModel);
    }
}
