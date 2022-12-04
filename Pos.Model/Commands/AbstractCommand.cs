namespace Pos.Entities.Commands
{
    public abstract class AbstractCommand
    {
        private static int EscapeCode = 27;
        public string Body { get; set; }
        public static AbstractCommand GetCommand(string message)
        {
            if (message[0] == (char)EscapeCode)
                return new ExitCommand() { Body = message };
            return new DataEnterCommand() { Body = message };
        }
    }
}
