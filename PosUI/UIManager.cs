using Pos.BL.Interfaces;
using Pos.Entities;
using Pos.Entities.PosStates;

namespace PosUI
{
    internal class UIManager
    {
        private readonly IPosEngine _posEngine;
        private readonly MenuForm _menuForm;
        private readonly IOutputManager _outputManager;
        private readonly IInputManager _inputManager;
        private readonly AuthForm _authForm;
        private readonly SplashForm _splashForm;

        public UIManager(IPosEngine posEngine, MenuForm menuForm, IOutputManager outputManager, IInputManager inputManager, AuthForm authForm,SplashForm splashForm)
        {
            _posEngine = posEngine;
            _menuForm = menuForm;
            _outputManager = outputManager;
            _inputManager = inputManager;
            _authForm = authForm;
            _splashForm = splashForm;
            outputManager.NotifyAction = message =>
                {
                    ProcessPosMessage(message);
                };

        }

        private void ProcessPosMessage(TransferModel message)
        {
            if (message.PosStateEnum == PosStateEnum.InitState)
                _splashForm.Show();
            if (message.PosStateEnum == PosStateEnum.AuthState)
            {
                _splashForm.Hide();
                _authForm.Show();
            }
        }

        public void Run()
        {
            _posEngine.Run();
        }
    }
}
