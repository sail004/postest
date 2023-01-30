namespace Pos.Entities.Commands;

public class ExitCommand : AbstractCommand
{
    public override CommandLabel CommandLabel => CommandLabel.Exit;
}
