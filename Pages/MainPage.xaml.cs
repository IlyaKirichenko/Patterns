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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void AddButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddExpensePage());
        }

        private void ExportButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ExportPage());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateData();
        }
        private void UpdateData()
        {
            if (ExpensesListView == null || FilterComboBox.SelectedItem == null)
                return;

            string category = ((ComboBoxItem)FilterComboBox.SelectedItem).Content.ToString();
            var filtered = ExpenseManager.Instance.GetFilterExpenses(category);

            ExpensesListView.ItemsSource = filtered;
            TotalSumTextBlock.Text = $"Итого: {ExpenseManager.Instance.GetTotalExpenses(filtered)} руб.";
        }

        private void Filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }
    }
}
