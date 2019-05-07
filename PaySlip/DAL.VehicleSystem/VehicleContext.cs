using DAL.VehicleSystem.DALEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace DAL.VehicleSystem
{
    public class VehicleContext:DbContext
    {
        public VehicleContext()
         : base("name=VehicleContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<VehicleEntity> Vehicles { get; set; }
    }
}
