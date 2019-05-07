using DAL.VehicleSystem.DALEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace DAL.VehicleSystem
{
    public class VehicleDbContext: DbContext
    {
        public DbSet<VehicleEntity> Vehicles { get; set; }
    }
}
