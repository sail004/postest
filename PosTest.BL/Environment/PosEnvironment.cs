using DataAccess.Interfaces;
using Pos.BL.Implementation.Devices;
using Pos.Entities.Devices;

namespace Pos.BL.Implementation.Environment
{
    public class PosEnvironment
    {
        private readonly IPosDeviceRepository _posDeviceRepository;

        public PosEnvironment(IPosDeviceRepository posDeviceRepository)
        {
            _posDeviceRepository = posDeviceRepository;
        }
        public Action<string> BarcodeReceivedHandler { get; set; }
        List<Scanner> Scanners { get; set; }=new List<Scanner>();
        public  IEnumerable<PosDevice> PosDevices { get; set; }
        public async Task Init()
        {
            PosDevices = await _posDeviceRepository.ReadAllAsync();
            foreach (var scanner in PosDevices.Where(device=>device.DeviceType==DeviceTypes.Scanner))
            {
                Scanner item = new Scanner(scanner);
                item.BarcodeReceived = (barcode) => { BarcodeReceivedHandler?.Invoke(barcode); };
                Scanners.Add(item);

            }
        }
    }
}
