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
        
        private string _strCommand = String.Empty;

        private List<ConsoleKey> _commandKeys = new List<ConsoleKey> { ConsoleKey.Enter, ConsoleKey.Escape, ConsoleKey.UpArrow, ConsoleKey.DownArrow };
        public Task<bool> ProcessInput()
        {
            var data = InputData?.Invoke();
            _strCommand += data.Value.KeyChar;
            if (_commandKeys.Contains(data.Value.Key))
            {
                var command = AbstractCommand.GetCommand(data.Value.Key, _strCommand);
                CommanReady?.Invoke(command);
                _strCommand = String.Empty;
            }
            
            return Task.FromResult(true);
        }
        public Func<ConsoleKeyInfo> InputData { get; set; }
        public Action<AbstractCommand> CommanReady { get; set; }

    }
}
