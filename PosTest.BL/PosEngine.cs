using Pos.BL.Interfaces;
using Pos.Entities;

namespace Pos.BL.Implementation
{
    public class PosEngine : IPosEngine
    {

        public PosEngine(IStateManager stateManager, IInputManager inputManager)
        {
            _stateManager = stateManager;
            _inputManager = inputManager;

            _inputManager.CommanReady = (cmd)=> _stateManager.ProcessCommand( cmd);
        }

        private IStateManager _stateManager { get; }
        private IInputManager _inputManager { get; }

        public async Task Run()
        {
            _stateManager.SetState(PosState.InitState);
            _stateManager.SetState(PosState.AuthState);
            while (await _inputManager.ProcessInput() && _stateManager.CurrentState != PosState.ExitState)
            {
              // await Task.Delay(100);
            }
            
        }
    }
}
