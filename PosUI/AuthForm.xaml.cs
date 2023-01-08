using Pos.BL.Interfaces;
using PosUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Pos.Entities.Commands;
using PosUI.Interfaces;
using Pos.Entities;
using Pos.Entities.PosStates;

namespace PosUI
{
    /// <summary>
    /// Interaction logic for AuthForm.xaml
    /// </summary>
    public partial class AuthForm : Window, ISetViewModel
    {
        private readonly IInputManager _inputManager;

        private AuthViewModel _authViewModel;

        public PosStateEnum PosStateEnum => PosStateEnum.AuthState;

        public AuthForm(IInputManager inputManager)
        {
            _inputManager = inputManager;
            InitializeComponent();
            _authViewModel = new AuthViewModel();
            DataContext = _authViewModel;

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        { 
            DoAuth();
        }


        private void DoAuth()
        {
            if (!string.IsNullOrEmpty(_authViewModel.User.Password))
                _inputManager.ProcessCommand(new DataEnterCommand() { Body = _authViewModel.User.Password });
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
    }
}
