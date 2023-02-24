using DataAccess.Interfaces;
using Pos.Entities.Devices;

namespace DataAccess.Implementation;

internal class PosDeviceRepoistory : IPosDeviceRepository
{
    public async Task<IEnumerable<PosDevice>> ReadAllAsync()
    {
        return new List<PosDevice> {
            //new PosDevice { ComPort = 3, Name = "Scanner", DeviceType = DeviceTypes.Scanner }
            };
    }

    public PosDevice ReadById(int id)
    {
        throw new NotImplementedException();
    }
}