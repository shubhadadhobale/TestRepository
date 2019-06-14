using PersonalExpenseTracker.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalExpenseTracker.ViewModels
{
    public class UserLoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value;
                OnPropertyChanged("UserName");
            }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value;
                OnPropertyChanged("Password");
            }
        }

        private UserLoginCommand userLoginCommand;
        public UserLoginCommand UserLoginCommand
        {
            get { return userLoginCommand; }
            set
            {
                userLoginCommand = value;
                OnPropertyChanged("UserLoginCommand");
            }
        }

        private UserRegistrationPageShowCommand userRegistrationPageShowCommand;
        public UserRegistrationPageShowCommand UserRegistrationPageShowCommand
        {
            get { return userRegistrationPageShowCommand; }
            set
            {
                userRegistrationPageShowCommand = value;
                OnPropertyChanged("UserRegistrationPageShowCommand");
            }
        }

        public UserLoginViewModel()
        {
            UserLoginCommand = new UserLoginCommand(this);
            UserRegistrationPageShowCommand = new UserRegistrationPageShowCommand();
        }

    }
}
