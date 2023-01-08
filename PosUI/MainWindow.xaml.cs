using Pos.BL.Interfaces;
using Pos.Entities;
using Pos.Entities.Commands;
using Pos.Entities.PosStates;
using PosUI.Interfaces;
using PosUI.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace PosUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MenuForm : Window, ISetViewModel
    {
        private readonly IInputManager _inputManager;
        private readonly ISerializer<MenuModel> _serializer;
        private MenuViewModel _menuViewModel;

        public PosStateEnum PosStateEnum => PosStateEnum.MenuState;

        public MenuForm(IInputManager inputManager,  ISerializer<MenuModel> serializer)
        {
      
            InitializeComponent();
            _inputManager = inputManager;
            _serializer = serializer;
            _menuViewModel = new MenuViewModel();
            DataContext = _menuViewModel;
        }

        
        public void SetViewModel(TransferModel message)
        {

            _menuViewModel.User = new User() { Name = message.User.Name };
            var menuModel = _serializer.Deserialize(message.JsonData);

            
            if (menuModel.CurrentIndex == 0)
            {
                SetActiveButton(RegistrationButton);
                return;
            }

            if (menuModel.CurrentIndex == 1)
            {
                SetActiveButton(ReportsButton);
                return;
            }

            if(menuModel.CurrentIndex == 2)
                SetActiveButton(ExitButton);
            
            

        }

        private void SetActiveButton(Button reportsButton)
        {
            reportsButton.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void Registration_Button_Click(object sender, RoutedEventArgs e)
        {
            _inputManager.ProcessCommand(new ExitCommand());
        }

        private void Window_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Down)
            {
                _inputManager.ProcessCommand(new MoveDownCommand());
            }
            if (e.Key == System.Windows.Input.Key.Up)
            {
                _inputManager.ProcessCommand(new MoveUpCommand());
            }
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                _inputManager.ProcessCommand(new DataEnterCommand());
            }
        }
    }
}
