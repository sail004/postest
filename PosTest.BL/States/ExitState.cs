using Pos.BL.Implementation.States;
using Pos.BL.Interfaces;
using Pos.Entities.Commands;
using Pos.Entities.PosStates;

public class ExitState : AbstractState
{
    public ExitState(IAuthenticationContext authenticationContext) : base(authenticationContext)
    {
    }

    public override PosState PosState => PosState.ExitState;

}
