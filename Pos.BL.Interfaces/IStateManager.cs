using Pos.Entities;

namespace Pos.BL.Implementation
{
    public interface IStateManager
    {
        public Action<string> NotifyAction { get; set; }
        PosState CurrentState { get; }

        public void CheckAlive();

        void ProcessCommand(string cmd);
        public void SetState(PosState state);
    }
}