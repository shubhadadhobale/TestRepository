using PersonalExpenseTracker.Commands;
using PersonalExpenseTracker.DataAccessLayer;
using PersonalExpenseTracker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalExpenseTracker.ViewModels
{
   public class ExpenseTrackerManagerViewModel:INotifyPropertyChanged
    {
        public ExpenseTrackerManagerViewModel(int userId)
        {
            this.UserId = userId;
            this.LogoutCommand = new LogoutCommand();
            this.AddExpensePageShowCommand = new AddExpensePageShowCommand(UserId,UserName);
            ExpenseDetailsDAL expenseDetailsDAL = new ExpenseDetailsDAL();
            this.Expenses =new ObservableCollection<ExpenseDetails>( expenseDetailsDAL.GetExpenses(UserId));
            this.TempExpenses = Expenses;
            this.ExpenseFilterCommand = new ExpenseFilterCommand(this);
            this.EditExpenseCommand = new EditExpenseCommand(this);
            this.DeleteExpenseCommand = new DeleteExpenseCommand(this);
            this.ExpenseChartCommand = new ExpenseChartCommand(this);
        }


        private LogoutCommand logoutCommand;
        public LogoutCommand LogoutCommand
        {
            get { return logoutCommand; }
            set
            {
                logoutCommand = value;
                OnPropertyChanged("LogoutCommand");
            }
        }
        private ExpenseChartCommand expenseChartCommand;
        public ExpenseChartCommand ExpenseChartCommand
        {
            get { return expenseChartCommand; }
            set
            {
                expenseChartCommand = value;
                OnPropertyChanged("ExpenseChartCommand");
            }
        }
        
        private ExpenseFilterCommand expenseFilterCommand;
        public ExpenseFilterCommand ExpenseFilterCommand
        {
            get { return expenseFilterCommand; }
            set
            {
                expenseFilterCommand = value;
                OnPropertyChanged("ExpenseFilterCommand");
            }
        }
        private EditExpenseCommand editExpenseCommand;
        public EditExpenseCommand EditExpenseCommand
        {
            get { return editExpenseCommand; }
            set
            {
                editExpenseCommand = value;
                OnPropertyChanged("EditExpenseCommand");
            }
        }
        private DeleteExpenseCommand deleteExpenseCommand;
        public DeleteExpenseCommand DeleteExpenseCommand
        {
            get { return deleteExpenseCommand; }
            set
            {
                deleteExpenseCommand = value;
                OnPropertyChanged("DeleteExpenseCommand");
            }
        }

        
        private AddExpensePageShowCommand addExpensePageShowCommand;
        public AddExpensePageShowCommand AddExpensePageShowCommand
        {
            get { return addExpensePageShowCommand; }
            set
            {
                addExpensePageShowCommand = value;
                OnPropertyChanged("AddExpensePageShowCommand");
            }
        }
        
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<ExpenseDetails> TempExpenses
        {
            get;set;
        }
        private ObservableCollection<ExpenseDetails> expenses;
        public ObservableCollection<ExpenseDetails> Expenses
        {
            get { return expenses; }
            set
            {
                expenses = value;
                OnPropertyChanged("Expenses");
            }
        }
        private ExpenseDetails expenseDetails;
        public ExpenseDetails ExpenseDetails
        {
            get { return expenseDetails; }
            set
            {
                expenseDetails = value;
                OnPropertyChanged("ExpenseDetails");
            }
        }
        private int userId;
        public int UserId
        {
            get { return userId; }
            set
            {
                userId = value;
                OnPropertyChanged("UserId");
            }
        }

        private string userName;
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        private string searchExpense;
        public string SearchExpense
        {
            get { return searchExpense; }
            set
            {
                searchExpense = value;
                OnPropertyChanged("SearchExpense");
                if (string.IsNullOrEmpty(SearchExpense))
                    this.Expenses = TempExpenses;
            }
        }


    }
}
