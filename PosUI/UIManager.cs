using Pos.BL.Interfaces;
using Pos.Entities;
using Pos.Entities.PosStates;
using PosUI.Interfaces;
using System.Threading.Tasks;
using System.Windows;

namespace PosUI
{
    internal class UIManager
    {
        private Window _currentForm;
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
            if (!string.IsNullOrEmpty(message.ErrorStatus))
            {
                (_currentForm as IDisplayError)?.DisplayError(message.ErrorStatus);
            }
            else
            {
                _currentForm?.Hide();

                if (message.PosStateEnum == PosStateEnum.InitState)
                {
                    _splashForm.Show();
                    _currentForm = _splashForm;
                }
                if (message.PosStateEnum == PosStateEnum.AuthState)
                {

                    _authForm.Show();
                    _currentForm = _authForm;
                }
                if (message.PosStateEnum == PosStateEnum.MenuState)
                {
                    _menuForm.Show();
                    _currentForm = _menuForm;

                }
            }
        }

        public async Task Run()
        {
             await _posEngine.Run();
        }
    }
}
