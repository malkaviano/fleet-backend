using Domain.Values;

namespace Domain.Models
{
    public class Bus : Vehicle
    {
        public Bus(ChassisId chassisId, string color) : base(chassisId, 42, color, VehicleTypes.BUS) { }
    }
}