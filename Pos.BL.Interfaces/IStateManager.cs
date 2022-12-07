using Pos.Entities.States;

namespace Pos.BL.Implementation
{
    public interface IStateManager
    {
        AbstractState CurrentState { get; }

        public void CheckAlive();
        void RefreshState();
        public void SetState(PosState state);
    }
}