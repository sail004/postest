using Pos.Entities;

namespace Pos.BL.Implementation
{
    /// <summary>
    /// класс управления состояниями кассового модуля
    /// отвественность: знает какие стостяния в какие можно менять (лигика смены состояний)
    /// </summary>
    public class StateManager : IStateManager
    {
        private readonly IOutputManager _outputManager;
        private PosState _currentState;
        public StateManager(IOutputManager outputManager)
        {
            _outputManager = outputManager;
        }

        public PosState CurrentState => _currentState;

        public void CheckAlive()
        {
            _outputManager.Notify($"Awaiting input {_currentState}");
            
        }

   
        public void SetState(PosState state)
        {
            _currentState = state;
            _outputManager.Notify($"Activate state {state}");
        }
    }
}
