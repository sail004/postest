using DataAccess.Interfaces;
using Pos.BL.Interfaces;
using Pos.Entities;
using Pos.Entities.Commands;
using Pos.Entities.PosStates;

namespace Pos.BL.Implementation.States;

public class MenuState : AbstractState
{
    private ISerializer<MenuModel> _serializer;
    private readonly MenuModel _menuModel = new();
    private readonly IUserRightRepository _userRightRepository;


    public MenuState(IUserRightRepository userRightRepository, IAuthenticationContext authenticationContext, ISerializer<MenuModel> serializer) : base(
        authenticationContext)
    {
        _userRightRepository = userRightRepository;
        _serializer = serializer;
    }

    public override PosStateEnum PosStateEnum => PosStateEnum.MenuState;

    public override TransferModel SendModel()
    {
          return new TransferModel { PosStateEnum = PosStateEnum, ErrorStatus = ErrorStatus, JsonData = _serializer.Serialize(_menuModel)};
    }

    public override PosStateCommandResult ProcessCommand(AbstractCommand cmd)
    {
        switch (cmd)
        {
            case ExitCommand:
                return new PosStateCommandResult { NewPosState = PosStateEnum.ExitState, HasRights = true };
            case MoveDownCommand:
                _menuModel.IncrementCurrentIndex();
                break;
            case MoveUpCommand:
                _menuModel.DecrementCurrentIndex();
                break;
            case DataEnterCommand:
                switch (_menuModel.CurrentIndex)
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