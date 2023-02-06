using Pos.BL.Interfaces;
using Pos.Entities;
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


        public RegistrationForm(ISerializer<RegistrationStateModel> serialzer)
        {
            _serializer = serialzer;
            _viewModel = new RegistrationViewModel();
            
            InitializeComponent();
            DataContext= _viewModel;

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
        }
    }
}

