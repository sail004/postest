using Pos.Entities;

namespace Pos.BL.Implementation
{
    public interface IStateManager
    {
        PosState CurrentState { get; }

        public void CheckAlive();

        public void SetState(PosState state);
    }
}