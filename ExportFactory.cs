using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Patterns
{
    public interface IExporter
    {
        void Export(List<Expense> expenses, string path);
    }

    public class CsvExporter : IExporter
    {
        public void Export(List<Expense> expenses, string path)
        {
            var lines = new List<string> { "Дата;Категория;Сумма;Описание" };
            foreach (var e in expenses)
            {
                lines.Add($"{e.Date:dd.MM.yyyy};{e.Category};{e.Sum};{e.Description}");
            }
            File.WriteAllLines(path, lines, Encoding.UTF8);
        }
    }

    public class JsonExporter : IExporter
    {
        public void Export(List<Expense> expenses, string path)
        {
            var option = new JsonSerializerOptions { WriteIndented = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping };
            string json = JsonSerializer.Serialize(expenses, option);
            File.WriteAllText(path, json);
        }
    }

    public abstract class ExporterCreator
    {
        public abstract IExporter CreateExporter();
    }

    public class CsvCreator : ExporterCreator
    {
        public override IExporter CreateExporter() => new CsvExporter();
    }

    public class JsonCreator : ExporterCreator
    {
        public override IExporter CreateExporter() => new JsonExporter();
    }
}
