using Pos.BL.Implementation.States;
using Pos.BL.Interfaces;
using Pos.Entities.PosStates;

public class ReportState : AbstractState
{
    public ReportState(IAuthenticationContext authenticationContext) : base(authenticationContext)
    {
    }

    public override PosState PosState => PosState.ReportState;
}