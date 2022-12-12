using Pos.BL.Interfaces;
using Pos.Entities.PosStates;

namespace Pos.BL.Implementation.States
{
    public class InitState : AbstractState
    {
        public InitState(IAuthenticationContext authenticationContext) : base(authenticationContext)
        {
        }

        public override PosState PosState => PosState.InitState;
    }
}