﻿using Pos.Entities.PosStates;

namespace Pos.BL.Implementation.States
{
    public class InitState : AbstractState
    {
        public override PosState PosState => PosState.InitState;
    }
}