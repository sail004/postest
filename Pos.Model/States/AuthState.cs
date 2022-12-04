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
    }
}
