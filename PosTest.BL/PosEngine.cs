using Pos.BL.Interfaces;
using Pos.Entities.Commands;
using Pos.Entities.PosStates;

namespace Pos.BL.Implementation;

/// <summary>
///     логика обработки всех главных классов кассовго модуля
/// </summary>
public class PosEngine : IPosEngine
{
    private readonly IInputManager _inputManager;

    private readonly IStateManager _stateManager;


    public PosEngine(IStateManager stateManager, IInputManager inputManager)
    {
        _stateManager = stateManager;
        _inputManager = inputManager;
        _inputManager.CommanReady = cmd => ProcessCommand(cmd);
    }

    public async Task Run()
    {
        _stateManager.SetState(PosStateEnum.InitState);
        _stateManager.SetState(PosStateEnum.AuthState, PosStateEnum.MenuState);
        while (await _inputManager.ProcessInput() && _stateManager.CurrentState.PosStateEnum != PosStateEnum.ExitState)
        {
            // await Task.Delay(100);
        }
    }

    private void ProcessCommand(AbstractCommand cmd)
    {
        try
        {
             _stateManager.ProcessCommand(cmd);
        }
        catch (Exception e)
        {
            _stateManager.CurrentState.ErrorStatus = e.Message;
        }
    }
}