
using Pos.BL.Implementation;
using Pos.BL.Interfaces;
using Pos.Entities.PosStates;

public class ChangeRegistractionStateAction
    : IPosAction
{
    public string ActionLabel => "Registration";

    public PosState NewPosState => PosState.RegistrationState;
}
public class ChangeReportStateAction
    : IPosAction
{
    public string ActionLabel => "Report";

    public PosState NewPosState =>  PosState.ReportState;
}
public class EmptyAction
    : IPosAction
{
    public string ActionLabel => "Empty";

    public PosState NewPosState => PosState.None;
}