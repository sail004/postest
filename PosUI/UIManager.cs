using Pos.BL.Interfaces;
using Pos.Entities;
using Pos.Entities.PosStates;
using PosUI.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PosUI
{
    internal class UIManager
    {
        private Window _currentForm;
        private readonly IPosEngine _posEngine;
        private readonly IOutputManager _outputManager;
        private readonly IInputManager _inputManager;
        private readonly IEnumerable<ISetViewModel> _forms;
        

        public UIManager(IPosEngine posEngine,IOutputManager outputManager, IInputManager inputManager, IEnumerable<ISetViewModel> forms)
        {
            _posEngine = posEngine;
            _outputManager = outputManager;
            _inputManager = inputManager;
            _forms = forms;
            outputManager.NotifyAction = message =>
                {
                    ProcessPosMessage(message);
                };

        }

        private void ProcessPosMessage(TransferModel message)
        {
            if (string.IsNullOrEmpty(message.ErrorStatus) && (_currentForm == null || ((ISetViewModel)_currentForm).PosStateEnum != message.PosStateEnum))
            {

                var targetForm = _forms.FirstOrDefault(form => form.PosStateEnum == message.PosStateEnum);

                if (message.PosStateEnum == PosStateEnum.OneTimeAuthState)
                {
                    ((Window)targetForm).ShowDialog();
                    _currentForm = ((Window)targetForm);
                }
                else
                    _currentForm?.Hide();


                if (targetForm != null)
                {
                    ((Window)targetForm).Show();
                    _currentForm = ((Window)targetForm);
                }


            }

            (_currentForm as ISetViewModel)?.SetViewModel(message);

        }

        public async Task Run()
        {
            await _posEngine.Run();
        }
    }
}
