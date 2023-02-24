using Pos.BL.Implementation.Environment;
using Pos.BL.Interfaces;
using Pos.Entities.PosStates;

namespace Pos.BL.Implementation.States;

internal class InitState : AbstractState
{
    PosEnvironment _posEnvironment;
    public InitState(IAuthenticationContext authenticationContext, PosEnvironment posEnvironment) : base(authenticationContext)
    {
        _posEnvironment = posEnvironment;
    }

    public override PosStateEnum PosStateEnum => PosStateEnum.InitState;
    public override async Task EnterState()
    {
        try
        {
            await _posEnvironment.Init();
        }
        catch (Exception ex)
        {
            ErrorStatus = ex.ToString();
            
            await Task.Delay(1000);
        }
        
    }
}