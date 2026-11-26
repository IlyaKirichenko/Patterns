using Microsoft.Win32;
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
    /// Логика взаимодействия для ExportPage.xaml
    /// </summary>
    public partial class ExportPage : Page
    {
        public ExportPage()
        {
            InitializeComponent();
            FormatComboBox.SelectedIndex = 0;
        }

        private void ExportButton(object sender, RoutedEventArgs e)
        {
            var expenses = ExpenseManager.Instance.Expenses.ToList();

            if (expenses.Count == 0)
            {
                MessageBox.Show("Нет данных для экспорта");
                return;
            }
            string format = ((ComboBoxItem)FormatComboBox.SelectedItem).Content.ToString();

            ExporterCreator creator;
            SaveFileDialog dialog = new SaveFileDialog();

            if (format == "CSV")
            {
                creator = new CsvCreator();
                dialog.Filter = "CSV (*.csv)|*.csv";
                dialog.FileName = "expenses.csv";
            }
            else
            {
                creator = new JsonCreator();
                dialog.Filter = "JSON (*.json)|*.json";
                dialog.FileName = "expenses.json";
            }

            if (dialog.ShowDialog() == true)
            {
                try
                {
                    IExporter exporter = creator.CreateExporter();
                    exporter.Export(expenses, dialog.FileName);
                    MessageBox.Show("Отчёт сохранён");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении: {ex.Message}");
                }
            }
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
