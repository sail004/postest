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


    public void RefreshState()
    {
        _outputManager.Notify(CurrentState.SendModel());
    }

    public void SetState(PosStateEnum posStateEnum)
    {
        var resolveState = _posStateResolver.ResolveState(posStateEnum);

        if (resolveState != null) CurrentState = resolveState;
        RefreshState();
    }

    public void ProcessCommand(AbstractCommand cmd)
    {
        var result = CurrentState.ProcessCommand(cmd);
        
        IPosState? nextPosState;
        
        if (!result.HasRights && CurrentState.PosStateEnum != PosStateEnum.AuthState&& CurrentState.PosStateEnum != PosStateEnum.OneTimeAuthState)
        {
            nextPosState = _posStateResolver.ResolveState(PosStateEnum.OneTimeAuthState);
            ((OneTimeAuthState)nextPosState).OldState = CurrentState.PosStateEnum;
            ((OneTimeAuthState)nextPosState).NewState = result.NewPosState;
            ((OneTimeAuthState)nextPosState).ActionLabel = result.ActionLabel;
        }
        else
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