using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;
using LiveCharts;
using LiveCharts.Wpf;


namespace ConverterCurrencyWPF
{
    /// <summary>
    /// Логика взаимодействия для ChartWindow.xaml
    /// </summary>
    public partial class ChartWindow : Window
    {
        public ChartWindow(string charcode1, string charcode2)
        { 
            _charCode1 = charcode1;
            _charCode2 = charcode2;
            InitializeComponent();

        }
        private string _charCode1;
        private string _charCode2;

        public static double FillingCurrency(string charCode, string date)
        {
            string url = "http://www.cbr.ru/scripts/XML_daily.asp?date_req=" + date;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url); // http запрос к API
            HttpWebResponse response = (HttpWebResponse)request.GetResponse(); // полученный ответ
            Stream stream = response.GetResponseStream(); // поток данных из ответа API
            StreamReader reader = new StreamReader(stream); // считываем символы из stream
            string result = reader.ReadToEnd(); // считывает все символы из объекта reader и сохраняет их в строковой переменной result. Эта строка содержит XML-ответ от API.
            XDocument doc = XDocument.Parse(result); // создает объект XDocument с именем doc, разбирая строку result как XML.
            return Convert.ToDouble(doc.Root.Elements("Valute").FirstOrDefault(x => x.Element("CharCode").Value == charCode)?.Element("Value").Value);
        }

        private void ChartForMounth_Click(object sender, RoutedEventArgs e)
        {
            SeriesCollection series = new SeriesCollection();

            ChartValues<double> values = new ChartValues<double>();
            List<string> dates = new List<string>();

            DateTime todayDate = DateTime.Now.AddDays(-30);

            for (int i = 0; i < 31; i++)
            {
                dates.Add(todayDate.AddDays(i).ToShortDateString());

                if (_charCode2 == "RUB")
                {
                    values.Add(Math.Round(FillingCurrency(_charCode1, dates[i]), 4));
                }
                else if (_charCode1 == "RUB")
                {
                    values.Add(Math.Round(1 / FillingCurrency(_charCode2, dates[i]), 4));
                }
                else
                {
                    values.Add(Math.Round(Math.Round(1 * FillingCurrency(_charCode1, dates[i]), 4) / FillingCurrency(_charCode2, dates[i]), 4));
                }
            }
            Chart.AxisX.Clear();
            Chart.AxisX.Add(new Axis()
            {
                Title = "Dates",
                Labels = dates
            });
            LineSeries line = new LineSeries();
            line.Title = "Values";
            line.Values = values;

            series.Add(line);

            Chart.Series = series;
        }

        private void ChartForWeek_Click(object sender, RoutedEventArgs e)
        {
            SeriesCollection series = new SeriesCollection();

            ChartValues<double> values = new ChartValues<double>();
            List<string> dates = new List<string>();

            DateTime todayDate = DateTime.Now.AddDays(-7);

            for (int i = 0; i < 8; i++)
            {
                dates.Add(todayDate.AddDays(i).ToShortDateString());

                if (_charCode2 == "RUB")
                {
                    values.Add(Math.Round(FillingCurrency(_charCode1, dates[i]), 4));
                }
                else if (_charCode1 == "RUB")
                {
                    values.Add(Math.Round(1 / FillingCurrency(_charCode2, dates[i]), 4));
                }
                else
                {
                    values.Add(Math.Round(Math.Round(1 * FillingCurrency(_charCode1, dates[i]), 4) / FillingCurrency(_charCode2, dates[i]), 4));
                }
            }
            Chart.AxisX.Clear();
            Chart.AxisX.Add(new Axis()
            {
                Title = "Dates",
                Labels = dates
            });
            LineSeries line = new LineSeries();
            line.Title = "Values";
            line.Values = values;

            series.Add(line);

            Chart.Series = series;

        }
    }
}
