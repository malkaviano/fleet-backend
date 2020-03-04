namespace EFRepository.Entities
{
    public class VehicleEntity
    {
        public string Series { get; internal set; }
        public uint Number { get; internal set; }
        public byte Passengers { get; internal set; }
        public string Color { get; internal set; }
        public string Type { get; internal set; }
    }
}