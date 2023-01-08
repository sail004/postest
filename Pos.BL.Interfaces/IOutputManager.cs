using Pos.Entities;

namespace Pos.BL.Interfaces;

public interface IOutputManager
{
    Action<TransferModel> NotifyAction { get; set; }

    public void Notify(TransferModel message);
}