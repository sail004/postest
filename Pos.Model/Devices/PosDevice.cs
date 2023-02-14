using Pos.Entities.User;

namespace Pos.Entities.Devices
{
    public record PosDevice : DataEntity
    {
        public string Name { get; set; }
        public int ComPort { get; set; }
        public DeviceTypes DeviceType { get; set; }
    }
}
