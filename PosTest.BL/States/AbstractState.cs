using Pos.BL.Interfaces;
using Pos.Entities.Commands;
using Pos.Entities.PosStates;

namespace Pos.BL.Implementation.States;

public abstract class AbstractState : IPosState
{
    protected readonly IAuthenticationContext AuthenticationContext;

    protected AbstractState(IAuthenticationContext authenticationContext)
    {
        AuthenticationContext = authenticationContext;
    }

    public abstract PosStateEnum PosStateEnum { get; }

    public string ErrorStatus { get; set; }

    public virtual string SendModel()
    {
        return $"Activate state {PosStateEnum}{Environment.NewLine}{ErrorStatus}{Environment.NewLine}";
    }

    public virtual PosStateCommandResult ProcessCommand(AbstractCommand cmd)
    {
        var posAction = GetAction(cmd);

        if (CheckRights(posAction))
            return new PosStateCommandResult { NewPosState = posAction.NewPosStateEnum, HasRights = true };

        return new PosStateCommandResult { NewPosState = posAction.NewPosStateEnum, HasRights = false };
        
    }

    private bool CheckRights(IPosAction posAction)
    {
        return AuthenticationContext.User != null;
    }

    private IPosAction GetAction(AbstractCommand cmd)
    {
        return new EmptyAction();
    }
}