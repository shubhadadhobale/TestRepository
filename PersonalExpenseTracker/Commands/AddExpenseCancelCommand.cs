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
   public class AddExpenseCancelCommand : ICommand
    {
        AddExpenseViewModel AddExpenseViewModel;
        public AddExpenseCancelCommand(AddExpenseViewModel addExpenseViewModel)
        {
            AddExpenseViewModel = addExpenseViewModel;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var window = (Window)parameter;
            var viewModel = new ExpenseTrackerManagerViewModel(AddExpenseViewModel.UserId);
            viewModel.UserName = AddExpenseViewModel.UserName;
            ExpenseTrackerManager expenseTracker = new ExpenseTrackerManager(viewModel);
            expenseTracker.Show();
            window.Close();
        }
    }
}
