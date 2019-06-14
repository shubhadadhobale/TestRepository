using PersonalExpenseTracker.DataAccessLayer;
using PersonalExpenseTracker.Models;
using PersonalExpenseTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PersonalExpenseTracker.Commands
{
   public class UserRegistrationCommand:ICommand
    {
        UserRegistrationViewModel UserRegistrationViewModel;
        public UserRegistrationCommand(UserRegistrationViewModel userRegistrationViewModel)
        {
            UserRegistrationViewModel = userRegistrationViewModel;
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public bool CanExecute(object parameter)
        {
            if (!string.IsNullOrEmpty(UserRegistrationViewModel.UserName))
                return true;
            else
                return false;
        }

        public void Execute(object parameter)
        {
            var window = (Window)parameter;
            var user = new UserDetails();
            user.UserName = UserRegistrationViewModel.UserName;
            user.Password = UserRegistrationViewModel.Password;
            user.Name = UserRegistrationViewModel.Name;
            UserDetailsDAL userDAL = new UserDetailsDAL();
            var res = userDAL.UserRegistration(user);
            if (res)
            {
                UserLogin userLogin = new UserLogin();
                window.Close();
                userLogin.Show();
            }
        }
    }
}
