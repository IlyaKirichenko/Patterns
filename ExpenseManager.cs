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
        private static ExpenseManager Instance
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
        

        
    }
}
