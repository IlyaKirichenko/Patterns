using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    public class Expense
    {
        public decimal Sum { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        
        public Expense (decimal sum, string category, DateTime date, string description)
        {
            Sum = sum;
            Category = category;
            Date = date;
            Description = description;
        }
    }
}
