using Pos.BL.Implementation.States;
using Pos.BL.Interfaces;
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

    public void CheckAlive()
    {
        _outputManager.Notify($"Awaiting input {CurrentState}");
    }

    public void RefreshState()
    {
        _outputManager.Notify(CurrentState.SendModel());
    }

    public void SetState(PosState state)
    {
        CurrentState =  _posStateResolver.ResolveState(state);
        RefreshState();
    }
}