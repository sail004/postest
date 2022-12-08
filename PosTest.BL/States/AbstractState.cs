using DataAccess.Interfaces;
using Pos.BL.Interfaces;
using Pos.Entities.Commands;
using Pos.Entities.PosStates;

namespace Pos.BL.Implementation.States
{
    public abstract class AbstractState : IPosState
    {

        public abstract PosState PosState { get; }
        public virtual PosState NextPosState => PosState.None;

        public string ErrorState { get; set; }

        public virtual string SendModel()
        {
            return $"Activate state {PosState}{Environment.NewLine}";
        }

        public virtual PosState ProcessCommand(AbstractCommand cmd)
        {
            return PosState.None;
        }
    }
}