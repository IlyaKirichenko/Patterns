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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Patterns.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddExpensePage.xaml
    /// </summary>
    public partial class AddExpensePage : Page
    {
        public AddExpensePage()
        {
            InitializeComponent();
            DatePicker.SelectedDate = DateTime.Today;
            CategoryCompoBox.SelectedIndex = 0;
        }

        private void SaveButton(object sender, RoutedEventArgs e)
        {
            if (!decimal.TryParse(SumTextBox.Text, out decimal sum) || sum <= 0)
            {
                MessageBox.Show("Введите корректную сумму больше нуля.");
                return;
            }
            if (CategoryCompoBox.SelectedItem == null || DatePicker.SelectedDate == null)
            {
                MessageBox.Show("Выберите категорию и дату.", "Ошибка ввода");
                return;
            }

            string category = ((ComboBoxItem)CategoryCompoBox.SelectedItem).Content.ToString();
            DateTime date = DatePicker.SelectedDate.Value;
            string description = DescriptionTextBox.Text;

            Expense newExpense = new Expense(sum, category, date, description);
            ExpenseManager.Instance.AddExpense(newExpense);

            MessageBox.Show("Расход добавлен!");
            NavigationService.GoBack(); 
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
