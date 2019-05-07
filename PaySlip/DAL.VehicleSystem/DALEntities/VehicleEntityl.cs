using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.VehicleSystem.DALEntities
{
    public class VehicleEntity
    {
        public string Model { get; set; }
        public string Make { get; set; }
        public string VehicleType { get; set; }
        public string Engine { get; set; }
        //   public int NumberOfDoors { get; set; }
        public int WheelsCount { get; set; }
        public string BodyType { get; set; }
        public VehiclePropertiesEntity vehiclePropertiesEntity { get; set; }
    }

    public class VehiclePropertiesEntity
    {
        public int? NumberofDoors { get; set; }
        public int? PassengerSeats { get; set; }

    }
}
