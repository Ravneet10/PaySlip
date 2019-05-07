using System;
using System.Collections.Generic;
using System.Text;
using DAL.VehicleSystem.Interface;

namespace DAL.VehicleSystem
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly VehicleContext _context;
        public IVehicleRepository Vehicles { get;  set; }

      //  public IVehicleRepository Vehicles => throw new NotImplementedException();

        public UnitOfWork(VehicleContext context)
        {
            _context = context;
           // Vehicles = new VehicleRepository(_context);
        }
        public int Complete()
            {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
