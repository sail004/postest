using Pos.BL.Interfaces;
using Pos.Entities.Commands;
using Pos.Entities.PosStates;

namespace Pos.BL.Implementation;

/// <summary>
///     логика обработки всех главных классов кассовго модуля
/// </summary>
internal class PosEngine : IPosEngine
{
    private readonly IInputManager _inputManager;

    private readonly IStateManager _stateManager;


    public PosEngine(IStateManager stateManager, IInputManager inputManager)
    {
        _stateManager = stateManager;
        _inputManager = inputManager;
        _inputManager.CommanReady = ProcessCommand;
    }

    public async Task Run()
    {
        await _stateManager.SetState(PosStateEnum.InitState);
        await _stateManager.SetState(PosStateEnum.AuthState);
        
        while (await _inputManager.ProcessInput() && _stateManager.CurrentState.PosStateEnum != PosStateEnum.ExitState)
        {
             await Task.Delay(100);
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