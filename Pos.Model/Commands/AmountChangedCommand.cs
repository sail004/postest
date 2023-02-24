namespace Pos.Entities.Commands
{
    public class AmountChangedCommand : AbstractCommand
    {
        public override CommandLabel CommandLabel => CommandLabel.AmountChanged;
    }
}