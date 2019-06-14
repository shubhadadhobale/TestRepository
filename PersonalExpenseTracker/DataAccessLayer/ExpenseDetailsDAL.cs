using Dapper;
using PersonalExpenseTracker.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalExpenseTracker.DataAccessLayer
{
   public class ExpenseDetailsDAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ExpenseTrackerConnnectionString"].ConnectionString;

        public bool AddExpense(ExpenseDetails expenseDetails)
        {
            int res;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var param = new DynamicParameters();
                param.Add("@Item", expenseDetails.Item);
                param.Add("@CategoryId", expenseDetails.CategoryId);
                param.Add("@UserId", expenseDetails.UserId);
                param.Add("@Amount", expenseDetails.Amount);
                param.Add("@ExpenseDate", expenseDetails.ExpenseDate);
               res=  connection.Execute("AddExpense", param, commandType: CommandType.StoredProcedure);
                connection.Close();
            }
            if (res > 0)
                return true;
            else
                return false;
        }

        public bool UpdateExpense(ExpenseDetails expenseDetails)
        {
            int res;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var param = new DynamicParameters();
                param.Add("@Item", expenseDetails.Item);
                param.Add("@CategoryId", expenseDetails.CategoryId);
                param.Add("@UserId", expenseDetails.UserId);
                param.Add("@Amount", expenseDetails.Amount);
                param.Add("@ExpenseDate", expenseDetails.ExpenseDate);
                param.Add("@ExpenseTrackerId", expenseDetails.ExpenseTrackerId);
                res = connection.Execute("UpdateExpenseDetails", param, commandType: CommandType.StoredProcedure);
                connection.Close();
            }
            return (res > 0);
        }

        public bool DeleteExpense(int expenseTrackerId)
        {
            int res;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var param = new DynamicParameters();
                param.Add("@ExpenseTrackerId", expenseTrackerId);
                res = connection.Execute("DeleteExpense", param, commandType: CommandType.StoredProcedure);
                connection.Close();
            }
            return (res > 0);
        }

        public List<ExpenseDetails> GetExpenses(int userId)
        {
            var expenses = new List<ExpenseDetails>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var param = new DynamicParameters();
                param.Add("@UserId", userId);
                expenses = connection.Query<ExpenseDetails>("GetExpenseDetails", param,commandType: CommandType.StoredProcedure).ToList();
                connection.Close();
            }
            return expenses;
        }

        public ExpenseDetails GetExpenseDetails(int expenseTrackerId)
        {
            var expense = new ExpenseDetails();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var param = new DynamicParameters();
                param.Add("@ExpenseTrackerId", expenseTrackerId);
                expense = connection.Query<ExpenseDetails>("GetExpenseTrackerInfo", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                connection.Close();
            }
                return expense;
        }
    }
}
