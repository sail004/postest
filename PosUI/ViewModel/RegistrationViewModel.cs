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


    }
}
