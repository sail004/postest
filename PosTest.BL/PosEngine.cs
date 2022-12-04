using Pos.BL.Interfaces;
using Pos.Entities;

namespace Pos.BL.Implementation
{
    /// <summary>
    /// логика обработки всех главных классов кассовго модуля
    /// </summary>
    public class PosEngine : IPosEngine
    {

        private readonly IStateManager _stateManager;
        private readonly IInputManager _inputManager;
        private readonly IOutputManager _outputManager;


        public PosEngine(IStateManager stateManager, IInputManager inputManager, IOutputManager outputManager)
        {
            _stateManager = stateManager;
            _inputManager = inputManager;
            _outputManager = outputManager;
            _inputManager.CommanReady = (cmd) => ProcessCommand(cmd);
        }

        private void ProcessCommand(string cmd)
        {
            if (_stateManager.CurrentState == PosState.AuthState && CheckPassword(cmd))
                _stateManager.SetState(PosState.MenuState);

            if (cmd[0] == (char)27)
                _stateManager.SetState(PosState.ExitState);
        }
        private bool CheckPassword(string cmd)
        {
            if (cmd == "3")
                return true;
            else
                _outputManager.NotifyAction?.Invoke($"Wrong password. Try again");
            return false;
        }



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
