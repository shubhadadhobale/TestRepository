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
    public class ExpenseTrackerDetailsCommand : ICommand
    {
        ExpenseChartViewModel ExpenseChartViewModel;
        public ExpenseTrackerDetailsCommand(ExpenseChartViewModel expenseChartViewModel)
        {
            this.ExpenseChartViewModel = expenseChartViewModel;
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var window = (Window)parameter;
            var viewModel = new ExpenseTrackerManagerViewModel(ExpenseChartViewModel.UserId);
            viewModel.UserName = ExpenseChartViewModel.UserName;
            ExpenseTrackerManager expenseTrackerManager = new ExpenseTrackerManager(viewModel);
            window.Close();
            expenseTrackerManager.Show();
        }
    }
}
