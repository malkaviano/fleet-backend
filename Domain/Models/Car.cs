using Domain.Values;

namespace Domain.Models
{
    public class Car : Vehicle
    {
        public Car(ChassisId chassisId, string color) : base(chassisId, 4, color, VehicleTypes.CAR) { }
    }
}