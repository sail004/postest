using Pos.BL.Interfaces;
using Pos.Entities;
using Pos.Entities.Commands;
using Pos.Entities.PosStates;
using PosUI.Interfaces;
using PosUI.ViewModel;
using System;
using System.Windows;
using System.Windows.Input;

namespace PosUI
{
    /// <summary>
    /// Interaction logic for OneTimeAuthForm.xaml
    /// </summary>
    public partial class OneTimeAuthForm : Window, ISetViewModel
    {
        private readonly IInputManager _inputManager;

        private AuthViewModel _authViewModel;
        public OneTimeAuthForm(IInputManager inputManager)
        {
            InitializeComponent();
            _inputManager = inputManager;
            _authViewModel = new AuthViewModel();
            DataContext = _authViewModel;
        }

        public PosStateEnum PosStateEnum => PosStateEnum.OneTimeAuthState;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DoAuth();
        }


        private void DoAuth()
        {
            if (!string.IsNullOrEmpty(_authViewModel.User.Password))
            {
                _inputManager.ProcessCommand(new DataEnterCommand() { Body = _authViewModel.User.Password });
                DialogResult = true;
            }
        }

        public void SetViewModel(TransferModel message)
        {
            _authViewModel.ErrorMessage = message.ErrorStatus;

        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                DoAuth();
            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            PasswordTextBox.Focus();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}

