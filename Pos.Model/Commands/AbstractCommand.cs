using System.Xml;

namespace Pos.Entities.Commands;

public enum CommandLabel
{
    Data,
    Exit,
    MoveUp,
    MoveDown,
    Registration,
    Backspace,
    BarcodeReceived,
    PriceChanged,
    AmountChanged,
    ErrorHandling

}
public abstract class AbstractCommand
{
    public abstract CommandLabel CommandLabel { get; }
    public virtual string? Body { get; set; } 

    public static AbstractCommand GetCommand(ConsoleKey key, string message, string payload)
    {
        switch (key)
        {
            case ConsoleKey.Escape:
                return new ExitCommand();
            case ConsoleKey.UpArrow:
                return new MoveUpCommand();
            case ConsoleKey.DownArrow:
                return new MoveDownCommand();
            case ConsoleKey.Backspace:
                return new BackSpaceCommand();
            case ConsoleKey.P:
                return new PriceChangingCommand(payload);
            case ConsoleKey.Q:
                return new AmountChangedCommand();
            default:
                return new DataEnterCommand { Body = message };
        }
    }
}