using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Entities.States
{
    internal class MenuState : AbstractState
    {
        public override PosState PosState => PosState.MenuState;

        public override string SendModel()
        {
            return $"Enter menu{Environment.NewLine}1. Registration{Environment.NewLine}2. Report{Environment.NewLine}3. Exit{Environment.NewLine}";
        }
    }

}

