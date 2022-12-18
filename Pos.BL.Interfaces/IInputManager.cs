using Pos.Entities.Commands;

namespace Pos.BL.Interfaces;

public interface IInputManager
{
    Func<ConsoleKeyInfo> InputData { get; set; }
    Action<AbstractCommand> CommanReady { get; set; }

    Task<bool> ProcessInput();
}