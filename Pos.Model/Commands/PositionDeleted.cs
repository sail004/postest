namespace Pos.Entities.Commands
{
    internal class PositionDeleted : AbstractCommand
    {
        public override CommandLabel CommandLabel => CommandLabel.DeletingPosition;
    }
}