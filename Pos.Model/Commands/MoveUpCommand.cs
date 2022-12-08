namespace Pos.Entities.Commands
{
    public class MoveUpCommand : AbstractCommand
    {
        public override CommandLabel CommandLabel => CommandLabel.MoveDown;
    }

}


