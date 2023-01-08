using Pos.BL.Implementation.States;
using Pos.BL.Interfaces;
using Pos.Entities.Commands;
using Pos.Entities.PosStates;

internal class ReportState : AbstractState
{
    public ReportState(IAuthenticationContext authenticationContext) : base(authenticationContext)
    {
    }

    public override PosStateCommandResult ProcessCommand(AbstractCommand cmd)
    {
        switch (cmd)
        {
            case ExitCommand:
                return new PosStateCommandResult { NewPosState = PosStateEnum.MenuState, HasRights = true };
        }

        return null;
    }

    public override PosStateEnum PosStateEnum => PosStateEnum.ReportState;
}