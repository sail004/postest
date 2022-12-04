using Pos.BL.Interfaces;
using System.Security.Cryptography;

namespace Pos.BL.Implementation
{
    /// <summary>
    /// Ответсвенность класс обработка вводимиых данных
    /// </summary>

    public class InputManager : IInputManager
    {
        private char CommandStringTerminator = '\r';
        private int EscapeCode = 27;
        private string _command = String.Empty;
        public Task<bool> ProcessInput()
        {
            var data = InputData?.Invoke();


            if (data == CommandStringTerminator || data == EscapeCode)
            {
                CommanReady?.Invoke(_command);
                _command = String.Empty;
            }
            else
                _command += data;
            return Task.FromResult(true);
        }
        public Func<char> InputData { get; set; }
        public Action<string> CommanReady { get; set; }

    }
}
