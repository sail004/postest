using Pos.BL.Interfaces;
using Pos.Entities.PosStates;

namespace Pos.BL.Implementation.States;

internal class InitState : AbstractState
{
    public InitState(IAuthenticationContext authenticationContext) : base(authenticationContext)
    {
    }
 
    public override PosStateEnum PosStateEnum => PosStateEnum.InitState;
    public override async Task EnterState()
    {
        await Task.Delay(1000);
    }
}