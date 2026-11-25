using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    public class ExpenseManager
    {
        private static ExpenseManager instanse;

        public ObservableCollection<Expense> Expenses { get; private set; }
        private ExpenseManager() 
        {
            Expenses = new ObservableCollection<Expense>();
        }
        public static ExpenseManager Instance
        {
            get
            {
                if (instanse == null)
                {
                    instanse = new ExpenseManager();
                }
                return instanse;
            }
        }
        public void AddExpense(Expense expense)
        {
            Expenses.Add(expense);
        }
        public List<Expense> GetFilterExpenses(string category)
        {
            if (string.IsNullOrEmpty(category) || category == "Все")
            {
                return Expenses.ToList();
            }
            return Expenses.Where(e => e.Category == category).ToList();
        }
        public decimal GetTotalExpenses(IEnumerable<Expense> expenses)
        {
            return expenses.Sum(e => e.Sum);
        }
    }
}
