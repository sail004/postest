using Pos.Entities.PosStates;

namespace Pos.BL.Interfaces
{
    public interface IStateManager
    {
        IPosState CurrentState { get; }

        public void CheckAlive();
        void RefreshState();
        public void SetState(PosState state);
    }
}