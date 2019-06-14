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
   public class ExpenseChartViewModel : INotifyPropertyChanged
    {
        public ExpenseChartViewModel(int userId,string userName)
        {
            this.UserId = userId;
            this.UserName = userName;
            this.LogoutCommand = new LogoutCommand();
            this.AddExpensePageShowCommand = new AddExpensePageShowCommand(UserId,UserName);
            this.ExpenseTrackerDetailsCommand = new ExpenseTrackerDetailsCommand(this);
            this.Bars =new RecordCollection(MappingOfBarValues(UserId));
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
        private ExpenseTrackerDetailsCommand expenseTrackerDetailsCommand;
        public ExpenseTrackerDetailsCommand ExpenseTrackerDetailsCommand
        {
            get { return expenseTrackerDetailsCommand; }
            set
            {
                expenseTrackerDetailsCommand = value;
                OnPropertyChanged("ExpenseTrackerDetailsCommand");
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

        private RecordCollection bars;
        public RecordCollection Bars
        {
            get { return bars; }
            set
            {
                bars = value;
                OnPropertyChanged("Bars");
            }
        }

        public List<Bar> MappingOfBarValues(int userId)
        {
            CategoryDetailsDAL categoryDetailsDAL = new CategoryDetailsDAL();
            var categoryList = categoryDetailsDAL.GetCategories();
            ExpenseDetailsDAL expenseDetailsDAL = new ExpenseDetailsDAL();
            var expenses = expenseDetailsDAL.GetExpenses(userId);
            List<Bar> _bar = new List<Bar>();
            foreach (var category in categoryList)
            {
                var value = expenses.Where(x => x.CategoryId == category.CategoryId).Select(x => x.Amount).Sum();
                _bar.Add(new Bar() { BarName = category.CategoryName, Value = value });
            }
            return _bar;
        }

    }
}
