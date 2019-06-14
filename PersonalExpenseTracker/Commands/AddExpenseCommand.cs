using PersonalExpenseTracker.DataAccessLayer;
using PersonalExpenseTracker.Models;
using PersonalExpenseTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PersonalExpenseTracker.Commands
{
    public class AddExpenseCommand : ICommand
    {
        AddExpenseViewModel AddExpenseViewModel;
        public AddExpenseCommand(AddExpenseViewModel addExpenseViewModel)
        {
            this.AddExpenseViewModel = addExpenseViewModel;
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public bool CanExecute(object parameter)
        {
            if (AddExpenseViewModel.Amount > 0 &&
                !string.IsNullOrEmpty(AddExpenseViewModel.Item) &&
                AddExpenseViewModel.CategoryId > 0 &&
                AddExpenseViewModel.UserId > 0)
                return true;
            else
                return false;

        }

        public void Execute(object parameter)
        {
            bool res=false;
            var window = (Window)parameter;
            ExpenseDetailsDAL expenseDetailsDAL = new ExpenseDetailsDAL();
            ExpenseDetails expense = new ExpenseDetails
            {
                UserId = AddExpenseViewModel.UserId,
                CategoryId = AddExpenseViewModel.CategoryId,
                Amount = AddExpenseViewModel.Amount,
                ExpenseDate = AddExpenseViewModel.ExpenseDate.GetValueOrDefault().ToString("yyyy-MM-dd"),
                Item = AddExpenseViewModel.Item,
                ExpenseTrackerId = AddExpenseViewModel.ExpenseTrackerId,
            };
            if(expense.ExpenseTrackerId>0)
            {
                res = expenseDetailsDAL.UpdateExpense(expense);
            }
            else
            {
                 res = expenseDetailsDAL.AddExpense(expense);
            }
            if (res)
            {
                var viewModel = new ExpenseTrackerManagerViewModel(AddExpenseViewModel.UserId);
                viewModel.UserName = AddExpenseViewModel.UserName;
                ExpenseTrackerManager expenseTrackerManager = new ExpenseTrackerManager(viewModel);
                window.Close();
                expenseTrackerManager.Show();
            }
        }
    }
}
