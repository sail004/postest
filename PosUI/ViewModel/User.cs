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
        private User user=new() { };

        public User User
        {
            get => user; set
            {
                user = value;
                OnPropertyChanged("User");
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
