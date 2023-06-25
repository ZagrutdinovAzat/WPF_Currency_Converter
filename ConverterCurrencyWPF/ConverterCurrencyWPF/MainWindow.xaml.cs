using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;


namespace ConverterCurrencyWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string[] charCodes = { "RUB", "AUD", "AZN", "GBP", "AMD", "BYN", "BGN", "BRL", "HUF", "VND", "HKD", "GEL", "DKK", "AED", "USD", "EUR", "EGP", "INR", "IDR", "KZT", "CAD", "QAR", "KGS", "CNY", "MDL", "NZD", "NOK", "PLN", "RON", "XDR", "SGD", "TJS", "THB", "TRY", "TMT", "UZS", "UAH", "CZK", "SEK", "CHF", "RSD", "ZAR", "KRW", "JPY" };
            string[] names = { "Российский рубль", "Австралийский доллар", "Азербайджанский манат", "Фунт стерлингов Соединенного королевства", "Армянских драмов", "Белорусский рубль", "Болгарский лев", "Бразильский реал", "Венгерских форинтов", "Вьетнамских донгов", "Гонконгских долларов", "Грузинский лари", "Датская крона", "Дирхам ОАЭ", "Доллар США", "Евро", "Египетских фунтов", "Индийских рупий", "Индонезийских рупий", "Казахстанских тенге", "Канадский доллар", "Катарский риал", "Киргизских сомов", "Китайский юань", "Молдавских леев", "Новозеландский доллар", "Норвежских крон", "Польский злотый", "Румынский лей", "СДР (специальные права заимствования)", "Сингапурский доллар", "Таджикских сомони", "Таиландских батов", "Турецких лир", "Новый туркменский манат", "Узбекских сумов", "Украинских гривен", "Чешских крон", "Шведских крон", "Швейцарский франк", "Сербских динаров", "Южноафриканских рэндов", "Вон Республики Корея", "Японских иен" };


            List<TextBlock> blocks1 = new List<TextBlock>();
            List<TextBlock> blocks2 = new List<TextBlock>();

            FillComboBox(blocks1, charCodes, names, 1);
            FillComboBox(blocks2, charCodes, names, 2);

            //CharCodeComboBox1.Text



        }

        public void FillComboBox(List<TextBlock> blocks, string[] charCodes, string[] names, int n)
        {
            for (int i = 0; i < charCodes.Length; i++)
            {

                TextBlock block = new TextBlock();
                block.Name = charCodes[i];
                block.Text = charCodes[i];
                block.ToolTip = names[i];
                block.Width = 45;
                block.TextAlignment = TextAlignment.Center;
                blocks.Add(block);
            }

            ObservableCollection<TextBlock> codes1;
            var newcodes1 = new ObservableCollection<TextBlock>(blocks);
            if (n == 1)
                CharCodeComboBox1.ItemsSource = newcodes1;
            else
                CharCodeComboBox2.ItemsSource = newcodes1;
            codes1 = newcodes1;
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //label1.Content = CharCodeComboBox1.SelectedItem;
        }

        private bool Error()
        {
            string errorText = "";

            if (CharCodeComboBox2.Text == "" || CharCodeComboBox1.Text == "")
            {
                errorText = "Вы не выбрали значение/я";
            }
            else if (CharCodeComboBox1.Text == CharCodeComboBox2.Text)
            {
                errorText = "Вы выбрали два одинаковых значения";
            }
            else if (DateTime.Compare(DateTime.Now, Convert.ToDateTime(calendar.SelectedDate)) < 0)
            { 
                errorText = "Вы выбрали некорректную дату"; 
            }
            else if(inputTextBox.Text == "")
            {
                errorText = "Вы не ввели значение для конвертации";
            }

            if (errorText != "")
            {
                ShowErrorWindow(errorText);
                return true;
            }
            return false;
        }

        public static void ShowErrorWindow(string errorText)
        {
            ErrorWindow errorWindow = new ErrorWindow();
            errorWindow.errorTextBlock.Text = errorText;
            errorWindow.Width = errorWindow.errorTextBlock.Width + 30;
            errorWindow.ShowDialog();
        }


        private void Conversion(object sender, RoutedEventArgs e)
        {
            if (Error() == false)
            {
                try
                {
                    if (CharCodeComboBox2.Text == "RUB")
                    {
                        Currency currency = new Currency(CharCodeComboBox1.Text, Convert.ToString(calendar.SelectedDate));
                        outputLabel.Content = Math.Round(Convert.ToDouble(inputTextBox.Text) * currency.Value / currency.Nominal, 6);

                    }
                    else if (CharCodeComboBox1.Text == "RUB")
                    {
                        Currency currency = new Currency(CharCodeComboBox2.Text, Convert.ToString(calendar.SelectedDate));
                        outputLabel.Content = Math.Round(Convert.ToDouble(inputTextBox.Text) / currency.Value * currency.Nominal, 6);
                    }
                    else
                    {
                        Currency currency1 = new Currency(CharCodeComboBox1.Text, Convert.ToString(calendar.SelectedDate));
                        Currency currency2 = new Currency(CharCodeComboBox2.Text, Convert.ToString(calendar.SelectedDate));
                        double x = Math.Round(Convert.ToDouble(inputTextBox.Text) * currency1.Value / currency1.Nominal, 6);
                        x = Math.Round(x / currency2.Value * currency2.Nominal, 6);
                        outputLabel.Content = x;
                    } 
                }
                catch (System.Net.WebException) 
                {
                    ShowErrorWindow("Отсутствует подключение к интернету");
                }
            }
        }

        private void ChartButton_Click(object sender, RoutedEventArgs e)
        {
            if (Error() == false)
            {
                try
                {
                    ChartWindow chart = new ChartWindow(CharCodeComboBox1.Text, CharCodeComboBox2.Text);
                    chart.ShowDialog();
                }
                catch (System.Net.WebException)
                {
                    ShowErrorWindow("Отсутствует подключение к интернету");
                }
            }
        }

        private void RubButton1_Click(object sender, RoutedEventArgs e)
        {
            CharCodeComboBox1.Text = "RUB";
            RubButton1.Background = Brushes.LightCyan;
            UsdButton1.Background = Brushes.White;
            EurButton1.Background = Brushes.White;
        }

        private void UsdButton1_Click(object sender, RoutedEventArgs e)
        {
            CharCodeComboBox1.Text = "USD";
            RubButton1.Background = Brushes.White;
            UsdButton1.Background = Brushes.LightCyan;
            EurButton1.Background = Brushes.White;
        }

        private void EurButton1_Click(object sender, RoutedEventArgs e)
        {
            CharCodeComboBox1.Text = "EUR";
            RubButton1.Background = Brushes.White;
            UsdButton1.Background = Brushes.White;
            EurButton1.Background = Brushes.LightCyan;

        }

        private void RubButton2_Click(object sender, RoutedEventArgs e)
        {
            CharCodeComboBox2.Text = "RUB";
            RubButton2.Background = Brushes.LightCyan;
            UsdButton2.Background = Brushes.White;
            EurButton2.Background = Brushes.White;
        }

        private void UsdButton2_Click(object sender, RoutedEventArgs e)
        {
            CharCodeComboBox2.Text = "USD";
            RubButton2.Background = Brushes.White;
            UsdButton2.Background = Brushes.LightCyan;
            EurButton2.Background = Brushes.White;

        }

        private void EurButton2_Click(object sender, RoutedEventArgs e)
        {
            CharCodeComboBox2.Text = "EUR";
            RubButton2.Background = Brushes.White;
            UsdButton2.Background = Brushes.White;
            EurButton2.Background = Brushes.LightCyan;

        }
    }
}
