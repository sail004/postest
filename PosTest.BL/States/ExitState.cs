using Pos.BL.Implementation.States;
using Pos.Entities.PosStates;

public class ExitState : AbstractState
{
    public override PosState PosState => PosState.ExitState;
}

