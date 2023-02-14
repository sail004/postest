namespace Pos.Entities.Commands;

public class BarcodeReceivedCommand : AbstractCommand
{
    public BarcodeReceivedCommand(string barcode)
    {
        Body = barcode;
    }
    public override CommandLabel CommandLabel => CommandLabel.BarcodeReceived;
}