using Pos.BL.Interfaces;
using Pos.Entities.PosStates;

public class ChangeRegistractionStateAction
    : IPosAction
{
    public string ActionLabel => "Registration";

    public PosStateEnum NewPosStateEnum => PosStateEnum.RegistrationState;
}

public class ChangeReportStateAction
    : IPosAction
{
    public string ActionLabel => "Report";

    public PosStateEnum NewPosStateEnum => PosStateEnum.ReportState;
}

public class EmptyAction
    : IPosAction
{
    public string ActionLabel => "Empty";

    public PosStateEnum NewPosStateEnum => PosStateEnum.None;
}