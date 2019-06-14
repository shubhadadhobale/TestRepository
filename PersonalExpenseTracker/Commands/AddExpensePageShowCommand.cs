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
    public class AddExpensePageShowCommand : ICommand
    {
        int UserId; 
        string UserName;
        public AddExpensePageShowCommand(int userId, string userName)
        {
            this.UserId = userId;
            this.UserName = userName;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var window = (Window)parameter;
           var viewModel = new AddExpenseViewModel(UserId);
            viewModel.UserName =UserName;
            AddExpense addExpense = new AddExpense(viewModel);
            window.Close();
            addExpense.Show();
        }
    }
}
