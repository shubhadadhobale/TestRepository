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
   public class ExpenseFilterCommand : ICommand
    {
        ExpenseTrackerManagerViewModel ViewModel;
        public ExpenseFilterCommand(ExpenseTrackerManagerViewModel viewModel)
        {
            this.ViewModel = viewModel;
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
            var viewModel = (ExpenseTrackerManagerViewModel)parameter;
            viewModel.Expenses = new System.Collections.ObjectModel.ObservableCollection<Models.ExpenseDetails>(viewModel.TempExpenses.Where(x => x.Item.ToLower().Contains(viewModel.SearchExpense.ToLower())));
        }
    }
}
