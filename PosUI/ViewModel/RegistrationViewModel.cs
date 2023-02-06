using Pos.Entities.Receipt;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PosUI.ViewModel
{

    internal class RegistrationViewModel : INotifyPropertyChanged
    {
        private List<ReceiptSpecRecord> _receiptSpecRecords;
        private int _receiptNumber;
        private int _shiftNumber;
        private string _сashier;
        private decimal _paymentType;
        private decimal _amountWithoutDiscount;
        private decimal _discount;
        private string _operationType;
        private string _inputValue;
        private string _status;
        private decimal _total;

        public List<ReceiptSpecRecord> ReceiptSpecRecords
        {
            get => _receiptSpecRecords;
            internal set
            {
                _receiptSpecRecords = value;
                OnPropertyChanged("ReceiptSpecRecords");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public int ReceiptNumber
        {
            get => _receiptNumber; set
            {
                _receiptNumber = value;
                OnPropertyChanged("ReceiptNumber");
            }
        }
        public int ShiftNumber
        {
            get => _shiftNumber; set
            {
                _shiftNumber = value;
                OnPropertyChanged(nameof(ShiftNumber));
            }
        }
        public string Cashier
        {
            get => _сashier; set
            {
                _сashier = value;
                OnPropertyChanged(nameof(Cashier));
            }
        }
        public decimal PaymentType
        {
            get => _paymentType; set
            {
                _paymentType = value;
                OnPropertyChanged(nameof(PaymentType));
            }
        }
        public decimal AmountWithoutDiscount
        {
            get => _amountWithoutDiscount; set
            {
                _amountWithoutDiscount = value;
                OnPropertyChanged(nameof(AmountWithoutDiscount));
            }
        }
        public decimal Discount
        {
            get => _discount; set
            {
                _discount = value;
                OnPropertyChanged(nameof(Discount));
            }
        }
        public string OperationType
        {
            get => _operationType; set
            {
                _operationType = value;
                OnPropertyChanged(nameof(OperationType));
            }
        }
        public string InputValue
        {
            get => _inputValue; set
            {
                _inputValue = value;
                OnPropertyChanged(nameof(InputValue));
            }
        }
        public string Status
        {
            get => _status; set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        public decimal Total { get => _total; internal set 
            {
                _total = value; 
                OnPropertyChanged(nameof(Total));
            } 
        }
    }
}
