using DataAccess.Interfaces;
using Pos.BL.Interfaces;
using Pos.Entities.Commands;
using Pos.Entities.PosStates;


namespace Pos.BL.Implementation.States
{
    public class MenuState : AbstractState
    {
        public override PosState PosState => PosState.MenuState;

        public string ErrorStatus { get; private set; }

        private Menu _menu = new Menu();
        private IUserRightRepository _userRightRepository;

        public MenuState(IUserRightRepository userRightRepository, IAuthenticationContext authenticationContext):base(authenticationContext)
        {
            _userRightRepository = userRightRepository;
        }

        public override string SendModel()
        {
            return _menu.BuildMenu();
        }
        public override PosActionResult ProcessCommand(AbstractCommand cmd)
        {
            if (cmd is ExitCommand)
            {
                return new PosActionResult { NewPosState = PosState.ExitState, HasRights = true };
            }
            if (cmd is MoveDownCommand)
            {
                _menu.IncrementCurrentIndex();
            }
            if (cmd is MoveUpCommand)
            {
                _menu.DecrementCurrentIndex();
            }
            if (cmd is DataEnterCommand)
            {
                switch (_menu.CurrentIndex)
                {
                    case 2:
                        return new PosActionResult { NewPosState = PosState.ExitState, HasRights = true };
                    case 1:
                        var newAction = new ChangeReportStateAction { };
                        if (AuthenticationContext.User!=null && _userRightRepository.UserHasRight(AuthenticationContext.User.Id, newAction.ActionLabel))
                        {
                            ClearErrorStatus();
                            return new PosActionResult { NewPosState = newAction.NewPosState, HasRights = true };
                        }
                        else
                            ErrorStatus = "Access denied";
                        return new PosActionResult { NewPosState = PosState.MenuState, HasRights = true };
                    case 0:
                        return new PosActionResult { NewPosState = PosState.RegistrationState, HasRights = true };
                }
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
        private readonly List<string> _menuItems = new() { $"1. Registration", "2. Report", "3. Exit" };
        public int CurrentIndex { get; set; }
        public string BuildMenu()
        {
            var result = string.Empty;
            for (int i = 0; i < _menuItems.Count; i++)
            {
                result = result + _menuItems[i];
                if (CurrentIndex == i)
                    result = result + " *";
                result = result + Environment.NewLine;
            }
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

}

