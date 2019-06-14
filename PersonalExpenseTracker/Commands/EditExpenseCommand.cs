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
    public class EditExpenseCommand : ICommand
    {
        ExpenseTrackerManagerViewModel ExpenseTrackerManagerViewModel;
        public EditExpenseCommand(ExpenseTrackerManagerViewModel viewModel)
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
            var viewModel = new AddExpenseViewModel(ExpenseTrackerManagerViewModel.UserId);
            viewModel.UserName = ExpenseTrackerManagerViewModel.UserName;
            viewModel.Amount = ExpenseTrackerManagerViewModel.ExpenseDetails.Amount;
            viewModel.ExpenseDate = DateTime.Parse(ExpenseTrackerManagerViewModel.ExpenseDetails.ExpenseDate);
            viewModel.Item = ExpenseTrackerManagerViewModel.ExpenseDetails.Item;
            viewModel.UserId = ExpenseTrackerManagerViewModel.ExpenseDetails.UserId;
            viewModel.CategoryId = ExpenseTrackerManagerViewModel.ExpenseDetails.CategoryId;
            viewModel.ExpenseTrackerId = ExpenseTrackerManagerViewModel.ExpenseDetails.ExpenseTrackerId;
            AddExpense addExpense = new AddExpense(viewModel);
            window.Close();
            addExpense.Show();

        }
    }
}
