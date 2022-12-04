using Pos.Entities.Commands;

namespace Pos.Entities.States
{
    internal class MenuState : AbstractState
    {
        public override PosState PosState => PosState.MenuState;

        public override string SendModel()
        {
            return $"Enter menu{Environment.NewLine}1. Registration{Environment.NewLine}2. Report{Environment.NewLine}3. Exit{Environment.NewLine}";
        }
        public override PosState ProcessCommand(AbstractCommand cmd)
        {
            if (cmd is ExitCommand || cmd.Body=="3")
            {
                return PosState.ExitState;
            }
            return PosState.None;
        }
    }

}

