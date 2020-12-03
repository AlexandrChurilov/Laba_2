using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace Laba2
{
    /// <summary>
    /// Логика взаимодействия для Полная_информация.xaml
    /// </summary>
    public partial class Полная_информация : Window
    {
        public List<Threat> threats15 = new List<Threat>();
        public void Back(int a)
        {

            for (int i = a-16; i < a+1; i++)
            {
                if (i == 0)
                {
                    button2.IsEnabled = false;
                    

                }
                threats15.Add(Parser.threat[i]);
            }
        }

        public void Next(int a)
        {

            for (int i=a; i < a+16; i++)
            {
                if (i == 217)
                {
                    button.IsEnabled = false;
                    break;
                    
                }
                threats15.Add(Parser.threat[i]);
            }
        } 
        public Полная_информация()
        {

            InitializeComponent();
            Next(0);
            button.IsEnabled = true;
            button2.IsEnabled = false;
            
        }

        private void Data_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Data_Source_Loaded(object sender, RoutedEventArgs e)
        {


            Data_Source.ItemsSource = threats15;


        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
        public int i = 0;

        public void Clear()
        {
            Data_Source.ItemsSource = null;
            Data_Source.Items.Refresh();
            threats15.Clear();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            i +=16;
            Clear();
            Next(i);

            Data_Source.ItemsSource = threats15;
            if (i >= 16)
            {
                button2.IsEnabled = true;
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Clear();
            
            
            Back(i);
            i -= 16;
            Data_Source.ItemsSource = threats15;
            if (i < 217)
            {
                button.IsEnabled = true;
            }
        }
    }
}
