namespace Pos.Entities.Commands
{
    public abstract class AbstractCommand
    {
        private static int EscapeCode = 27;
        public string Body { get; set; }
        public static AbstractCommand GetCommand(ConsoleKey key, string message)
        {
            switch (key)
            {
                case ConsoleKey.Escape:
                    return new ExitCommand() { };
                case ConsoleKey.UpArrow:
                    return new MoveUpCommand { };
                case ConsoleKey.DownArrow:
                    return new MoveDownCommand { };
                default:
                    return new DataEnterCommand() { Body = message.Substring(0, message.Length - 1) };
            }
        }
    }
}
