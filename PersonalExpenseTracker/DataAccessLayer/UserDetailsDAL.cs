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
    public class UserDetailsDAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ExpenseTrackerConnnectionString"].ConnectionString;

        public UserDetails UserLogin(UserDetails user)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var param = new DynamicParameters();
                param.Add("@UserName", user.UserName);
                param.Add("@Password", user.Password);
                user = connection.Query<UserDetails>("UserLogin", param,commandType: CommandType.StoredProcedure).SingleOrDefault();
                connection.Close();
            }
            return user;
        }

        public bool UserRegistration(UserDetails user)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@UserName", user.UserName);
                    param.Add("@Password", user.Password);
                    param.Add("@Name", user.Name);
                    connection.Query("AddUser", param, commandType: CommandType.StoredProcedure);
                    connection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
          
        }
    }
}
