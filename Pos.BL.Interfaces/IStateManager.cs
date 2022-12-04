using Pos.Entities.States;

namespace Pos.BL.Implementation
{
    public interface IStateManager
    {
        AbstractState CurrentState { get; }

        public void CheckAlive();

        public void SetState(PosState state);
    }
}