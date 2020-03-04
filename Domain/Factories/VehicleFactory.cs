using Domain.Models;
using Domain.Values;

namespace Domain.Factories
{
    public static class VehicleFactory
    {
        public static ChassisId CreateChassisId(string series, uint number)
        {
            return new ChassisId(series, number);
        }

        public static Vehicle CreateVehicle(
            ChassisId chassisId,
            string type,
            string color
        )
        {
            switch (type.ToUpper())
            {
                case VehicleTypes.CAR:
                    return new Car(chassisId, color);
                case VehicleTypes.BUS:
                    return new Bus(chassisId, color);;
                case VehicleTypes.TRUCK:
                    return new Truck(chassisId, color);
                default:
                    return null;
            }
        }
    }
}