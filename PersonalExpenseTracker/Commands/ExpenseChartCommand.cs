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
   public class ExpenseChartCommand : ICommand
    {
        ExpenseTrackerManagerViewModel ExpenseTrackerManagerViewModel;
        public ExpenseChartCommand(ExpenseTrackerManagerViewModel viewModel)
        {
            ExpenseTrackerManagerViewModel = viewModel;
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
            ExpenseChart expenseChart = new ExpenseChart(ExpenseTrackerManagerViewModel.UserId,ExpenseTrackerManagerViewModel.UserName);
            window.Close();
            expenseChart.Show();

        }
    }
}