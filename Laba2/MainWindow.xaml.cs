using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace Laba2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        private IParser _parser;

        public void Intialize(IParser parser)
        {
            _parser = parser;

        }


        FileReaderWriter warf = new FileReaderWriter();

        public Parser parser = new Parser();

        public MainWindow()
        {
            InitializeComponent();

            Intialize(new Parser());


            if (!File.Exists(Environment.CurrentDirectory + @"\thrlist.xlsx") && !File.Exists(Environment.CurrentDirectory + @"\threat.xml"))
            {
                button1.IsEnabled = true;
                button4.IsEnabled = false;
                button2.IsEnabled = false;
                button3.IsEnabled = false;
                MessageBox.Show("Файл не найден, произведите первичную загрузку ");
            }
            else if (File.Exists(Environment.CurrentDirectory + @"\threat.xml"))
            {
                button1.IsEnabled = false;
                button4.IsEnabled = false;
                warf.ReadXmlBd();
                Data.ItemsSource = Parser.threat;
            }
            else
            {
                button1.IsEnabled = false;
                button4.IsEnabled = false;
                _parser.ParserWork(Parser.threat);
                warf.WriteXmlBd();
                Data.ItemsSource = Parser.threat;
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            button2.IsEnabled = true;
            button3.IsEnabled = true;


            _parser.ParserWork(Parser.threat);
            warf.WriteXmlBd();

            Data.ItemsSource = Parser.threat;
            button4.IsEnabled = false;

        }

        private void Data_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Data_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            DownloadFile.Download();
            button4.IsEnabled = true;
            button1.IsEnabled = false;

        }
        public void renovation()
        {
            Parser.threat.Clear();
            Data.ItemsSource = null;
            Data.Items.Refresh();
            _parser.ParserWork(Parser.threat);
            warf.WriteXmlBd();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                DownloadFile.Download();
                parser.obnova.Clear();
                _parser.ParserWork(parser.obnova);

                for (int i = 0; i < parser.obnova.Count(); i++)
                {

                    if (!parser.obnova[i].ToString().Equals(Parser.threat[i].ToString()))
                    {

                        parser.changers.Add(parser.obnova[i]);
                        parser.old_information.Add(Parser.threat[i]);


                    }

                }

                MessageBox.Show($"Колличество изменений: {parser.changers.Count()}");
                if (parser.changers.Count() > 0)
                {
                    renovation();
                    Data.ItemsSource = Parser.threat;
                    MessageBox.Show("УСПЕШНО!!!");
                    string report = null;
                    for (int i = 0; i < parser.changers.Count(); i++)
                    {
                        report += $"\n{parser.changers[i].Thrat} \n БЫЛО: \n {parser.changers[i].ToString().Replace(parser.changers[i].Thrat, "") }\n СТАЛО: \n {parser.old_information[i].ToString().Replace(parser.changers[i].Thrat, "")} ";
                        MessageBox.Show($"ОТЧЕТ\n Колличество {parser.changers.Count()}\n {report}");
                        report = "";
                    }

                    parser.changers.Clear();
                    parser.old_information.Clear();
                }
                else
                {
                    MessageBox.Show("Изменений не обнаружено. У вас и так самая новая версия!!!");
                }



            }
            catch (Exception t)
            {
                MessageBox.Show("Ошибка " + t);
            }

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Full_Information taskWindow = new Full_Information();
            taskWindow.Owner = this;
            taskWindow.Show();

        }
    }
}
