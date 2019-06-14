using PersonalExpenseTracker.DataAccessLayer;
using PersonalExpenseTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PersonalExpenseTracker
{
    /// <summary>
    /// Interaction logic for ExpenseChart.xaml
    /// </summary>
    public partial class ExpenseChart : Window
    {
        public ExpenseChart(int userId, string userName)
        {
            InitializeComponent();
            this.DataContext = new ExpenseChartViewModel(userId,userName);
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



