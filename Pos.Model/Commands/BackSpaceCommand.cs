namespace Pos.Entities.Commands;

public class BackSpaceCommand : AbstractCommand
{
    public override CommandLabel CommandLabel => CommandLabel.Backspace;
}