using DataAccess.Interfaces;
using Pos.BL.Interfaces;
using Pos.Entities.Commands;
using Pos.Entities.PosStates;

namespace Pos.BL.Implementation.States;

public class MenuState : AbstractState
{
    private readonly Menu _menu = new();
    private readonly IUserRightRepository _userRightRepository;


    public MenuState(IUserRightRepository userRightRepository, IAuthenticationContext authenticationContext) : base(
        authenticationContext)
    {
        _userRightRepository = userRightRepository;
    }

    public override PosStateEnum PosStateEnum => PosStateEnum.MenuState;

    public override string SendModel()
    {
        return _menu.BuildMenu(AuthenticationContext.User.Name, ErrorStatus);
    }

    public override PosStateCommandResult ProcessCommand(AbstractCommand cmd)
    {
        switch (cmd)
        {
            case ExitCommand:
                return new PosStateCommandResult { NewPosState = PosStateEnum.ExitState, HasRights = true };
            case MoveDownCommand:
                _menu.IncrementCurrentIndex();
                break;
            case MoveUpCommand:
                _menu.DecrementCurrentIndex();
                break;
            case DataEnterCommand:
                switch (_menu.CurrentIndex)
                {
                    case 2:
                        return new PosStateCommandResult { NewPosState = PosStateEnum.ExitState, HasRights = true };
                    case 1:
                        var newAction = new ChangeReportStateAction();
                        if (AuthenticationContext.User != null &&
                            _userRightRepository.UserHasRight(AuthenticationContext.User.Id, newAction.ActionLabel))
                        {
                            ClearErrorStatus();
                            return new PosStateCommandResult { NewPosState = newAction.NewPosStateEnum, HasRights = true };
                        }

                        ErrorStatus = "Access denied";

                        return new PosStateCommandResult { NewPosState = newAction.NewPosStateEnum, HasRights = false, ActionLabel = newAction.ActionLabel };
                    case 0:
                        return new PosStateCommandResult { NewPosState = PosStateEnum.RegistrationState, HasRights = true };
                }

                break;
        }

        return new PosStateCommandResult { NewPosState = PosStateEnum.MenuState, HasRights = true };
    }

    private void ClearErrorStatus()
    {
        ErrorStatus = string.Empty;
    }
}