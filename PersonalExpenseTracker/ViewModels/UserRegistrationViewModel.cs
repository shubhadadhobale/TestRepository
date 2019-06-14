using PersonalExpenseTracker.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalExpenseTracker.ViewModels
{
    public class UserRegistrationViewModel : INotifyPropertyChanged
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
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private UserRegistrationCommand userRegistrationCommand;
        public UserRegistrationCommand UserRegistrationCommand
        {
            get { return userRegistrationCommand; }
            set
            {
                userRegistrationCommand = value;
                OnPropertyChanged("UserRegistrationCommand");
            }
        }

        private UserLoginPageShowCommand userLoginPageShowCommand;
        public UserLoginPageShowCommand UserLoginPageShowCommand
        {
            get { return userLoginPageShowCommand; }
            set
            {
                userLoginPageShowCommand = value;
                OnPropertyChanged("UserLoginPageShowCommand");
            }
        }

        public UserRegistrationViewModel()
        {
            UserRegistrationCommand = new UserRegistrationCommand(this);
            UserLoginPageShowCommand = new UserLoginPageShowCommand(this);
        }

    }
}
