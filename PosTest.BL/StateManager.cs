using Pos.Entities;

namespace Pos.BL.Implementation
{
    public class StateManager : IStateManager
    {
        private PosState _currentState;


        public Action<string> NotifyAction { get; set; }

        public PosState CurrentState => _currentState;

        public void CheckAlive()
        {
            NotifyAction?.Invoke($"Awaiting input {_currentState}");
        }

        public void ProcessCommand(string cmd)
        {
            if (_currentState == PosState.AuthState && CheckPassword(cmd))
                SetState(PosState.MenuState);
            
            if (cmd[0] == (char)27)
                SetState(PosState.ExitState);
        }

        private bool CheckPassword(string cmd)
        {
            if (cmd == "3")
                return true;
            else
                NotifyAction?.Invoke($"Wrong password. Try again");
            return false;
        }

        public void SetState(PosState state)
        {
            _currentState = state;
            NotifyAction?.Invoke($"Activate state {state}");
        }
    }
}
