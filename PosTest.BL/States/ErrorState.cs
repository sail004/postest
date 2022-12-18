using Pos.BL.Implementation.States;
using Pos.BL.Interfaces;
using Pos.Entities.PosStates;

public class ErrorState : AbstractState
{
    public ErrorState(IAuthenticationContext authenticationContext) : base(authenticationContext)
    {
    }

    public override PosState PosState => PosState.ErrorState;
}