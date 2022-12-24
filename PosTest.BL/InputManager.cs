using Pos.BL.Interfaces;
using Pos.Entities.Commands;

namespace Pos.BL.Implementation;

/// <summary>
///     Ответсвенность класс обработка вводимиых данных
/// </summary>
internal class InputManager : IInputManager
{
    private readonly List<ConsoleKey> _commandKeys = new()
        { ConsoleKey.Enter, ConsoleKey.Escape, ConsoleKey.UpArrow, ConsoleKey.DownArrow };

    private string _strCommand = string.Empty;
    private char CommandStringTerminator = '\r';

    public Task<bool> ProcessInput()
    {
        var data = InputData?.Invoke();
        _strCommand += data.Value.KeyChar;
        if (_commandKeys.Contains(data.Value.Key))
        {
            var command = AbstractCommand.GetCommand(data.Value.Key, _strCommand);
            CommanReady?.Invoke(command);
            _strCommand = string.Empty;
        }

        return Task.FromResult(true);
    }

    public Func<ConsoleKeyInfo> InputData { get; set; }
    public Action<AbstractCommand> CommanReady { get; set; }
}