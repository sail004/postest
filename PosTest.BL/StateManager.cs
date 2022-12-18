using Pos.BL.Implementation.States;
using Pos.BL.Interfaces;
using Pos.Entities.Commands;
using Pos.Entities.PosStates;

namespace Pos.BL.Implementation;

/// <summary>
///     класс управления состояниями кассового модуля
///     отвественность: знает какие стостяния в какие можно менять (лигика смены состояний)
/// </summary>
public class StateManager : IStateManager
{
    private readonly IOutputManager _outputManager;
    private readonly PosStateResolver _posStateResolver;

    public StateManager(IOutputManager outputManager, PosStateResolver posStateResolver)
    {
        _outputManager = outputManager;
        _posStateResolver = posStateResolver;
    }

    public IPosState CurrentState { get; private set; }
    private PosStateEnum _nextState { get; set; }

    public void RefreshState()
    {
        _outputManager.Notify(CurrentState.SendModel());
    }

    public void SetState(PosStateEnum posStateEnum, PosStateEnum nextStateEnum)
    {
        CurrentState = _posStateResolver.ResolveState(posStateEnum);
        _nextState = nextStateEnum;
        RefreshState();
    }

    public void ProcessCommand(AbstractCommand cmd)
    {
        var result = CurrentState.ProcessCommand(cmd);
        var nextPosState = _posStateResolver.ResolveState(_nextState);
        if (result.HasRights && result.NewPosState != PosStateEnum.None)
            nextPosState = _posStateResolver.ResolveState(result.NewPosState);

        if (nextPosState != null)
            CurrentState = nextPosState;
        RefreshState();
    }

    public void CheckAlive()
    {
        _outputManager.Notify($"Awaiting input {CurrentState}");
    }
}