namespace Pos.Entities.PosStates;

public enum PosStateEnum
{
    None,
    InitState,
    AuthState,
    OneTimeAuthState,
    MenuState,
    RegistrationState,
    ExitState,
    ErrorState,
    ReportState
}