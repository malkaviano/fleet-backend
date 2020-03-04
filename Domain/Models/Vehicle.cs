namespace Domain.Models
{
    public abstract class Vehicle
    {
        public ChassisId ChassisId { get; private set; }
        public byte Passengers { get; private set; }
        public string Color { get; internal set; }
        public string Type { get; set; }

        public Vehicle(ChassisId chassisId, byte passengers, string color, string type)
        {
            ChassisId = chassisId;
            Passengers = passengers;
            Color = color;
            Type = type;
        }
    }
}