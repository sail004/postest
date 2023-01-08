using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PosUI.ViewModel
{
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

