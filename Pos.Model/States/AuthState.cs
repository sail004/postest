using Pos.Entities.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Entities.States
{
    internal class AuthState : AbstractState
    {
        public override PosState PosState => PosState.AuthState;
        public override PosState NextPosState => PosState.MenuState;
        public override PosState ProcessCommand(AbstractCommand cmd)
        {
            if (CheckPassword(cmd.Body))
            {
                ErrorState = "";
                return NextPosState;
            }


            ErrorState = "Wrong Password";
            return PosState.None;
        }
        private bool CheckPassword(string cmd)
        {
            if (cmd == "3")
                return true;
            return false;
        }
    }
}
