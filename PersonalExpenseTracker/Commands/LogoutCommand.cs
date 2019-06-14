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
    public class LogoutCommand : ICommand
    {
        public LogoutCommand()
        {

        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var window = (Window)parameter;
            UserLogin userLogin = new UserLogin();
            window.Close();
            userLogin.Show();
        }
    }
}
