using DAL.VehicleSystem.DALEntities;
using DAL.VehicleSystem.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace DAL.VehicleSystem
{
    public class VehicleRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicleModel"></param>
        public void Save(VehicleEntity vehicleModel)
        {
            VehicleDbContext employeeDbContext = new VehicleDbContext();
            employeeDbContext.Vehicles.Add(vehicleModel);
            employeeDbContext.SaveChanges();
        }

       
    }
}
