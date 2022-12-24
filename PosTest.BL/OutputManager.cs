using Pos.BL.Interfaces;
using Pos.Entities;

internal class OutputManager : IOutputManager
{
    public void Notify(TransferModel message)
    {
        NotifyAction?.Invoke(message);
    }

    public Action<TransferModel> NotifyAction { get; set; }
}