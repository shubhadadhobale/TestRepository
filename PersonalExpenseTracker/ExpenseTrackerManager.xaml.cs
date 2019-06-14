using PersonalExpenseTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for ExpenseTrackerManager.xaml
    /// </summary>
    public partial class ExpenseTrackerManager : Window
    {
        public ExpenseTrackerManager(ExpenseTrackerManagerViewModel viewModel)
        {
            this.DataContext = viewModel;
            InitializeComponent();
        }
    }
}
