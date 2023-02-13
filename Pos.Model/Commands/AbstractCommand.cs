using System.Xml;

namespace Pos.Entities.Commands;

public enum CommandLabel
{
    Data,
    Exit,
    MoveUp,
    MoveDown,
    Registration,
    Backspace
}

public abstract class AbstractCommand
{
    public abstract CommandLabel CommandLabel { get; }
    public string? Body { get; set; } 

    public static AbstractCommand GetCommand(ConsoleKey key, string message)
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
            default:
                return new DataEnterCommand { Body = message };
        }
    }
}