using Pos.BL.Implementation.States;
using Pos.BL.Interfaces;
using Pos.Entities.PosStates;

namespace Pos.BL.Implementation
{
    /// <summary>
    /// класс управления состояниями кассового модуля
    /// отвественность: знает какие стостяния в какие можно менять (лигика смены состояний)
    /// </summary>
    public class StateManager : IStateManager
    {
        private readonly IOutputManager _outputManager;
        private readonly PosStateResolver _posStateResolver;
        private IPosState _currentState;
        public StateManager(IOutputManager outputManager, PosStateResolver posStateResolver)
        {
            _outputManager = outputManager;
            _posStateResolver = posStateResolver;
        }

        public IPosState CurrentState => _currentState;

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
            _currentState = _posStateResolver.ResolveState(state);
            RefreshState();
        }
    }
    public class PosStateResolver
    {
        private readonly IEnumerable<IPosState> _posStates;

        public PosStateResolver(IEnumerable<IPosState> posStates)
        {
            _posStates = posStates;
        }
        public IPosState ResolveState(PosState state)
        {
            return _posStates.FirstOrDefault(o => o.PosState == state);
        }
    }
}
