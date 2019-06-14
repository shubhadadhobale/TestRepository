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
    public class UserLoginCommand : ICommand 
    {
        UserLoginViewModel UserLoginViewModel;
        public UserLoginCommand(UserLoginViewModel userLoginViewModel)
        {
            UserLoginViewModel = userLoginViewModel;
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public bool CanExecute(object parameter)
        {
            if (!string.IsNullOrEmpty(UserLoginViewModel.UserName))
                return true;
            else
                return false;
        }

        public void Execute(object parameter)
        {
            var window = (Window)parameter;
            var user = new UserDetails();
            user.UserName = UserLoginViewModel.UserName;
            user.Password = UserLoginViewModel.Password;
            UserDetailsDAL userDAL = new UserDetailsDAL();
            user= userDAL.UserLogin(user);
            if (user!=null && user.UserId>0)
            {
                var viewModel= new ExpenseTrackerManagerViewModel(user.UserId);
                viewModel.UserName = user.Name;
                ExpenseTrackerManager expenseTrackerManager = new ExpenseTrackerManager(viewModel);
                window.Close();
                expenseTrackerManager.Show();
            }
        }
    }
}
