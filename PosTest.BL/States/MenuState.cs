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

    public override PosState PosState => PosState.MenuState;

    public override string SendModel()
    {
        return _menu.BuildMenu(AuthenticationContext.User.Name, ErrorStatus);
    }

    public override PosActionResult ProcessCommand(AbstractCommand cmd)
    {
        switch (cmd)
        {
            case ExitCommand:
                return new PosActionResult { NewPosState = PosState.ExitState, HasRights = true };
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
                        return new PosActionResult { NewPosState = PosState.ExitState, HasRights = true };
                    case 1:
                        var newAction = new ChangeReportStateAction();
                        if (AuthenticationContext.User != null && _userRightRepository.UserHasRight(AuthenticationContext.User.Id, newAction.ActionLabel))
                        {
                            ClearErrorStatus();
                            return new PosActionResult { NewPosState = newAction.NewPosState, HasRights = true };
                        }

                        ErrorStatus = "Access denied";

                        return new PosActionResult { NewPosState = PosState.MenuState, HasRights = true };
                    case 0:
                        return new PosActionResult { NewPosState = PosState.RegistrationState, HasRights = true };
                }

                break;
        }

        return new PosActionResult { NewPosState = PosState.MenuState, HasRights = true };
    }

    private void ClearErrorStatus()
    {
        ErrorStatus = string.Empty;
    }
}

public class Menu
{
    private readonly List<string> _menuItems = new() { "1. Registration", "2. Report", "3. Exit" };
    public int CurrentIndex { get; private set; }

    public string BuildMenu(string userName, string errorStatus)
    {
        var result = string.Empty;
        for (var i = 0; i < _menuItems.Count; i++)
        {
            result += _menuItems[i];
            if (CurrentIndex == i)
                result += " *";
            result += Environment.NewLine;
        }

        result += Environment.NewLine;
        result += userName;
        result += Environment.NewLine;
        result += errorStatus;
        return result;
    }

    internal void DecrementCurrentIndex()
    {
        if (CurrentIndex <= 0)
            CurrentIndex = _menuItems.Count - 1;
        else
            CurrentIndex--;
    }

    internal void IncrementCurrentIndex()
    {
        if (CurrentIndex >= _menuItems.Count - 1)
            CurrentIndex = 0;
        else
            CurrentIndex++;
    }
}