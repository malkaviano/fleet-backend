using Domain.Values;

namespace Domain.Models
{
    public class Truck : Vehicle
    {
        public Truck(ChassisId chassisId, string color) : base(chassisId, 1, color, VehicleTypes.TRUCK) { }
    }
}