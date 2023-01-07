using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PosUI.ViewModel
{
    internal class User 
    {
        public string Password { get; set; }

    }
    internal class AuthViewModel : INotifyPropertyChanged
    {
        private User _user = new() { };
        private string _errorMessage;

        public User User
        {
            get => _user; set
            {
                _user = value;
                OnPropertyChanged("User");
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage; internal set
            {
                _errorMessage = value;
                OnPropertyChanged("ErrorMessage");
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
