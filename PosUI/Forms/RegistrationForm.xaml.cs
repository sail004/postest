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
        private readonly ISerializer<List<ReceiptSpecRecord>> _serializer;


        public RegistrationForm(ISerializer<List<ReceiptSpecRecord>> serialzer)
        {
            _serializer = serialzer;
            _viewModel = new RegistrationViewModel();
            
            InitializeComponent();
            DataContext= _viewModel;

        }

        public PosStateEnum PosStateEnum => PosStateEnum.RegistrationState;

        public void SetViewModel(TransferModel model)
        {
          _viewModel.ReceiptSpecRecords = _serializer.Deserialize(model.JsonData);
        }
    }
}

