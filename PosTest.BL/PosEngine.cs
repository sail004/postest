using Pos.BL.Interfaces;
using Pos.Entities.Commands;
using Pos.Entities.States;

namespace Pos.BL.Implementation
{
    /// <summary>
    /// логика обработки всех главных классов кассовго модуля
    /// </summary>
    public class PosEngine : IPosEngine
    {

        private readonly IStateManager _stateManager;
        private readonly IInputManager _inputManager;


        public PosEngine(IStateManager stateManager, IInputManager inputManager)
        {
            _stateManager = stateManager;
            _inputManager = inputManager;
            _inputManager.CommanReady = (cmd) => ProcessCommand(cmd);
        }

        private void ProcessCommand(AbstractCommand cmd)
        {
            var newState = _stateManager.CurrentState.ProcessCommand(cmd);
            if (newState != PosState.None)
                _stateManager.SetState(newState);
            else
                _stateManager.RefreshState(); 
            //_outputManager.Notify($"Error stateChange {_stateManager.CurrentState.ErrorState }");
        }

        public async Task Run()
        {
            _stateManager.SetState(PosState.InitState);
            _stateManager.SetState(PosState.AuthState);
            while (await _inputManager.ProcessInput() && _stateManager.CurrentState.PosState != PosState.ExitState)
            {
                // await Task.Delay(100);
            }

        }
    }
}
