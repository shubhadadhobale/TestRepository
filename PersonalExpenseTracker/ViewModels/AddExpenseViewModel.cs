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
    public class AddExpenseViewModel:INotifyPropertyChanged
    {
        public AddExpenseViewModel(int userId)
        {
            CategoryDetailsDAL categoryDetailsDAL = new CategoryDetailsDAL();
            this.UserId = userId;
            AddExpenseCommand = new AddExpenseCommand(this);
            AddExpenseCancelCommand = new AddExpenseCancelCommand(this);
            LogoutCommand = new LogoutCommand();
            Categories = new ObservableCollection<CategoryDetails>(categoryDetailsDAL.GetCategories());
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private string item;
        public string Item
        {
            get { return item; }
            set
            {
                item = value;
                OnPropertyChanged("Item");
            }
        }
        private int expenseTrackerId;
        public int ExpenseTrackerId
        {
            get { return expenseTrackerId; }
            set
            {
                expenseTrackerId = value;
                OnPropertyChanged("ExpenseTrackerId");
            }
        }
        private double amount;
        public double Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                OnPropertyChanged("Amount");
            }
        }

        private DateTime? expenseDate;
        public DateTime? ExpenseDate
        {
            get { return expenseDate; }
            set
            {
                expenseDate = value;
                OnPropertyChanged("ExpenseDate");
            }
        }

        private int categoryId;

        public int CategoryId
        {
            get { return categoryId; }
            set
            {
                categoryId = value;
                OnPropertyChanged("CategoryId");
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


        private AddExpenseCommand addExpenseCommand;

        public AddExpenseCommand AddExpenseCommand
        {
            get { return addExpenseCommand; }
            set
            {
                addExpenseCommand = value;
                OnPropertyChanged("AddExpenseCommand");
            }
        }


        private AddExpenseCancelCommand addExpenseCancelCommand;

        public AddExpenseCancelCommand AddExpenseCancelCommand
        {
            get { return addExpenseCancelCommand; }
            set
            {
                addExpenseCancelCommand = value;
                OnPropertyChanged("AddExpenseCancelCommand");
            }
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
        private ObservableCollection<CategoryDetails> categories;
        public ObservableCollection<CategoryDetails> Categories
        {
            get { return categories; }
            set
            {
                categories = value;
                OnPropertyChanged("Categories");
            }
        }
    }
}
