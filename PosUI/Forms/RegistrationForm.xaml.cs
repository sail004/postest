using Pos.BL.Interfaces;
using Pos.Entities;
using Pos.Entities.Commands;
using Pos.Entities.PosStates;
using Pos.Entities.Receipt;
using PosUI.Interfaces;
using PosUI.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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


namespace PosUI.Forms
{
   
    public partial class RegistrationForm : Window, ISetViewModel
    {
        private RegistrationViewModel _viewModel;
        private readonly ISerializer<RegistrationStateModel> _serializer;
        private IInputManager _inputManager;


        public RegistrationForm(ISerializer<RegistrationStateModel> serialzer, IInputManager inputManager)
        {
            _serializer = serialzer;
            _viewModel = new RegistrationViewModel();

            InitializeComponent();
            DataContext = _viewModel;
            _inputManager = inputManager;
        }

        public PosStateEnum PosStateEnum => PosStateEnum.RegistrationState;

        public void SetViewModel(TransferModel model)
        {
            var stateModel= _serializer.Deserialize(model.JsonData);
            _viewModel.ReceiptSpecRecords = stateModel.Receipt.ReceiptSpecRecords;
            _viewModel.ReceiptNumber = stateModel.Receipt.ReceiptNumber;
            _viewModel.Total = stateModel.Receipt.Total;
            _viewModel.ShiftNumber = stateModel.Receipt.ShiftNumber;
            _viewModel.Cashier = stateModel.Receipt.Cashier;
            _viewModel.PaymentType = stateModel.Receipt.PaymentType;
            _viewModel.AmountWithoutDiscount = stateModel.Receipt.AmountWithoutDiscount;
            _viewModel.Discount = stateModel.Receipt.Discount;
            _viewModel.Status = stateModel.Status;
            _viewModel.InputValue = stateModel.InputValue;
            ReceipSpecGrid.SelectedIndex = stateModel.CurrentPosition;
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            _inputManager.ProcessInput(ConvertToConsoleKeyInfo(e.Key));
        }
        public static ConsoleKeyInfo ConvertToConsoleKeyInfo(Key key)
        {
            if (key == Key.Enter)
            {
                return new ConsoleKeyInfo(Convert.ToChar(Key.Enter), ConsoleKey.Enter, false, false, false);
            }
            if (key == Key.Up)
            {
                return new ConsoleKeyInfo(Convert.ToChar(Key.Up), ConsoleKey.UpArrow, false, false, false);
            }
            if (key == Key.Down)
            {
                return new ConsoleKeyInfo(Convert.ToChar(Key.Down), ConsoleKey.DownArrow, false, false, false);
            }
            if (key == Key.Escape)
            {
                return new ConsoleKeyInfo(Convert.ToChar(Key.Escape), ConsoleKey.Escape, false, false, false);
            }
            if (key == Key.Back)
            {
                return new ConsoleKeyInfo(Convert.ToChar(Key.Back), ConsoleKey.Backspace, false, false, false);
            }

            ConsoleKey consoleKey;
            if (Enum.TryParse(key.ToString(), out consoleKey))
            {
                return new ConsoleKeyInfo((char)KeyInterop.VirtualKeyFromKey(key), consoleKey, false, false, false);
            }
           return new ConsoleKeyInfo();
        }
    }
}

