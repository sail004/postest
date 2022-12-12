using Pos.BL.Implementation.States;
using Pos.BL.Interfaces;
using Pos.Entities.PosStates;

public class RegistrationState : AbstractState
{
    public RegistrationState(IAuthenticationContext authenticationContext) : base(authenticationContext)
    {
    }

    public override PosState PosState => PosState.RegistrationState;

}
