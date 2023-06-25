using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ConverterCurrencyWPF
{
    internal class Currency
    {
        private string _charCode = "";
        private int _nominal = 1;
        private string _name = "";
        private double _value = 0;

        public Currency() { }

        public Currency(string charCode, string date) 
        { 
            CharCode = charCode;
            FillingCurrency(_charCode, date);

        }

        public string CharCode
        {
            get { return _charCode; }
            private set { _charCode = value; }
        }
        public int Nominal { get; private set; }
        public string Name {
            get { return _name; }
            private set { _name = value; }
        }
        public double Value { get; private set; }


        public void FillingCurrency(string charCode, string date)
        {
                string url = "http://www.cbr.ru/scripts/XML_daily.asp?date_req=" + date;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url); // http запрос к API
                HttpWebResponse response = (HttpWebResponse)request.GetResponse(); // полученный ответ
                Stream stream = response.GetResponseStream(); // поток данных из ответа API
                StreamReader reader = new StreamReader(stream); // считываем символы из stream
                string result = reader.ReadToEnd(); // считывает все символы из объекта reader и сохраняет их в строковой переменной result. Эта строка содержит XML-ответ от API.
                XDocument doc = XDocument.Parse(result); // создает объект XDocument с именем doc, разбирая строку result как XML.
                Value = Convert.ToDouble(doc.Root.Elements("Valute").FirstOrDefault(x => x.Element("CharCode").Value == CharCode)?.Element("Value").Value);
                Nominal = Convert.ToInt32(doc.Root.Elements("Valute").FirstOrDefault(x => x.Element("CharCode").Value == CharCode)?.Element("Nominal").Value);
        }
    }
    
}
