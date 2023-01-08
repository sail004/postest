using Pos.BL.Interfaces;
using PosUI.ViewModel;
using System;
using System.Windows;

namespace PosUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MenuForm : Window
    {
        private readonly IInputManager _inputManager;
        private MenuViewModel _menuViewModel;

        public MenuForm(IInputManager inputManager)
        {
      
            InitializeComponent();
            _inputManager = inputManager;
            
        }

        internal void SetViewModel(Pos.Entities.TransferModel message)
        {
            _menuViewModel = new MenuViewModel() { User = new User() {Name=message.User.Name} };
            DataContext = _menuViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void Registration_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
