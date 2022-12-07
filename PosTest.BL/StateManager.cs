using Pos.Entities.States;

namespace Pos.BL.Implementation
{
    /// <summary>
    /// класс управления состояниями кассового модуля
    /// отвественность: знает какие стостяния в какие можно менять (лигика смены состояний)
    /// </summary>
    public class StateManager : IStateManager
    {
        private readonly IOutputManager _outputManager;
        private AbstractState _currentState;
        public StateManager(IOutputManager outputManager)
        {
            _outputManager = outputManager;
        }

        public AbstractState CurrentState => _currentState;

        public void CheckAlive()
        {
            _outputManager.Notify($"Awaiting input {_currentState}");
            
        }

        public void RefreshState()
        {
            _outputManager.Notify(_currentState.SendModel());
        }

        public void SetState(PosState state)
        {
            _currentState = AbstractState.GetInstance(state);
            RefreshState();
        }
    }
}
