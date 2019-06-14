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
   public class CategoryDetailsDAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ExpenseTrackerConnnectionString"].ConnectionString;

        public List<CategoryDetails> GetCategories()
        {
            var categories = new List<CategoryDetails>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                categories = connection.Query<CategoryDetails>("GetCategoryDetails", commandType: CommandType.StoredProcedure).ToList();
                connection.Close();
            }
            return categories;
        }
    }
}
