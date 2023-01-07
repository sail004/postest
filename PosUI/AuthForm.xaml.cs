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

namespace PosUI
{
    /// <summary>
    /// Interaction logic for AuthForm.xaml
    /// </summary>
    public partial class AuthForm : Window
    {
        private readonly IInputManager _inputManager;

        private AuthViewModel _authViewModel; 
        public AuthForm(IInputManager inputManager)
        {
            _inputManager = inputManager;
            InitializeComponent();
            _authViewModel=new AuthViewModel();
            DataContext = _authViewModel;

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //todo: сделать обработку Enter если нажат то DoAuth();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Проверить есть ли у DataContext.User.Password символы
            DoAuth();
        }

        private void DoAuth()
        {
          _inputManager.ProcessCommand(new DataEnterCommand(){Body = _authViewModel.User.Password});
        }
    }
}
