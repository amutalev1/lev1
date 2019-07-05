namespace Seldat.Amuta.Entities
{
    public class Device
    {
        public enum DeviceType
        {
            Pc,
            Tablet
        }
        public int Id { get; set; }
        public DeviceType Type { get; set; }
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
    }
}