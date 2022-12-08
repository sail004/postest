using Pos.Entities.Commands;

namespace Pos.Entities.States
{
    internal class MenuState : AbstractState
    {
        public override PosState PosState => PosState.MenuState;
        private Menu _menu = new Menu();
        public override string SendModel()
        {
            return _menu.BuildMenu();
        }
        public override PosState ProcessCommand(AbstractCommand cmd)
        {
            if (cmd is ExitCommand)
            {
                return PosState.ExitState;
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
                if (_menu.CurrentIndex == 2)
                {
                    return PosState.ExitState;
                }
                if (_menu.CurrentIndex == 1)
                {
                    return PosState.ReportState;
                }
                if (_menu.CurrentIndex == 0)
                {
                    return PosState.RegistrationState;
                }
            }

            return PosState.None;
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
            if (CurrentIndex >= _menuItems.Count-1)
                CurrentIndex = 0;
            else
                CurrentIndex++;
        }
    }

}

