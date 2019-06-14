using PersonalExpenseTracker.DataAccessLayer;
using PersonalExpenseTracker.Models;
using PersonalExpenseTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PersonalExpenseTracker.Commands
{
    public class DeleteExpenseCommand : ICommand
    {
        ExpenseTrackerManagerViewModel ExpenseTrackerManagerViewModel;
        public DeleteExpenseCommand(ExpenseTrackerManagerViewModel expenseTrackerManagerViewModel)
        {
            this.ExpenseTrackerManagerViewModel = expenseTrackerManagerViewModel;
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
            MessageBoxResult result = MessageBox.Show("Do you want to Delete this Expense?", "Confirmation", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                ExpenseDetailsDAL expenseDetailsDAL = new ExpenseDetailsDAL();
                var res = expenseDetailsDAL.DeleteExpense(ExpenseTrackerManagerViewModel.ExpenseDetails.ExpenseTrackerId);
                if (res)
                {
                    MessageBox.Show("Expense Deleted Successfully!");
                    ExpenseTrackerManagerViewModel.Expenses= new ObservableCollection<ExpenseDetails>(expenseDetailsDAL.GetExpenses(ExpenseTrackerManagerViewModel.UserId));
                }
            }
            else
            {

            }
        }
    }
}
