using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalExpenseTracker.Models
{
    public class ExpenseDetails
    {
        public int ExpenseTrackerId { get; set; }
        public string Item { get; set; }
        public string ExpenseDate { get; set; }
        public double Amount { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
    }
}
