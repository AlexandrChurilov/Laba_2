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

        public MainWindow()
        {
            InitializeComponent();

            if (!File.Exists(Environment.CurrentDirectory + @"\thrlist.xlsx")&& !File.Exists(Environment.CurrentDirectory + @"\threat.xml"))
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
                new Parser().ReadXmlBd();
                Data.ItemsSource = Parser.threat;
            }
            else
            {
                button1.IsEnabled = false;
                button4.IsEnabled = false;
                new Parser().ParserWork(Parser.threat);
                new Parser().WriteXmlBd();
                Data.ItemsSource = Parser.threat;
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            button2.IsEnabled = true;
            button3.IsEnabled = true;



            new Parser().ParserWork(Parser.threat);
            new Parser().WriteXmlBd();

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
            new Parser().ParserWork(Parser.threat);
            new Parser().WriteXmlBd();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                DownloadFile.Download();
                Obnova.obnova.Clear();
                new Parser().ParserWork(Obnova.obnova);

                for (int i = 0; i < Obnova.obnova.Count(); i++)
                {

                    if (!Obnova.obnova[i].ToString().Equals(Parser.threat[i].ToString()))
                    {

                        Obnova.changers.Add(Obnova.obnova[i]);
                        Obnova.old_information.Add(Parser.threat[i]);
                        Obnova.countObnova++;

                    }

                }
                
                MessageBox.Show($"Колличество изменений: {Obnova.countObnova}");
                if (Obnova.countObnova > 0)
                {
                    renovation();
                    Data.ItemsSource = Parser.threat;
                    MessageBox.Show("УСПЕШНО!!!");
                    string report = null;
                    for (int i = 0; i < Obnova.changers.Count(); i++)
                    {
                        report += $"\n{Obnova.changers[i].Thrat} \n БЫЛО: \n {Obnova.changers[i].ToString().Replace(Obnova.changers[i].Thrat, "") }\n СТАЛО: \n {Obnova.old_information[i].ToString().Replace(Obnova.changers[i].Thrat, "")} ";
                        MessageBox.Show($"ОТЧЕТ\n Колличество {Obnova.countObnova}\n {report}");
                        report = "";
                    }
                    Obnova.countObnova = 0;
                    Obnova.changers.Clear();
                    Obnova.old_information.Clear();
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
            Полная_информация taskWindow = new Полная_информация();
            taskWindow.Owner = this;
            taskWindow.Show();

        }
    }
}
