namespace Domain.Models
{
    public struct ChassisId
    {
        public string Series { get; private set; }
        public uint Number { get; private set; }

        public ChassisId(string series, uint number)
        {
            Series = series;
            Number = number;
        }
    }
}
