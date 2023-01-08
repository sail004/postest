using Pos.BL.Implementation.States;
using Pos.BL.Interfaces;
using Pos.Entities.PosStates;

public class RegistrationState : AbstractState
{
    public RegistrationState(IAuthenticationContext authenticationContext) : base(authenticationContext)
    {
    }

    public override PosStateEnum PosStateEnum => PosStateEnum.RegistrationState;
}