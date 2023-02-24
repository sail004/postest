namespace Pos.Entities.Commands;

public  class ErrorHandlingCommand : AbstractCommand
{

    public ErrorHandlingCommand(Exception exception)
    {
        Body = exception.Message;
    }

    public override CommandLabel CommandLabel => CommandLabel.ErrorHandling;
}
