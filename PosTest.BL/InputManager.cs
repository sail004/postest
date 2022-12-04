using Pos.BL.Interfaces;
using Pos.Entities.Commands;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;

namespace Pos.BL.Implementation
{
    /// <summary>
    /// Ответсвенность класс обработка вводимиых данных
    /// </summary>

    public class InputManager : IInputManager
    {
        private char CommandStringTerminator = '\r';
        private static int EscapeCode = 27;
        private string _strCommand = String.Empty;
        public Task<bool> ProcessInput()
        {
            var data = InputData?.Invoke();

            if (data == (char)EscapeCode)
            {
                var command = AbstractCommand.GetCommand(data.ToString());
                CommanReady?.Invoke(command);
                _strCommand = String.Empty;
            }
            else
            if (data == CommandStringTerminator )
            {
                var command=AbstractCommand.GetCommand(_strCommand);
                CommanReady?.Invoke(command);
                _strCommand = String.Empty;
            }
            else
                _strCommand += data;
            return Task.FromResult(true);
        }
        public Func<char> InputData { get; set; }
        public Action<AbstractCommand> CommanReady { get; set; }

    }
}
