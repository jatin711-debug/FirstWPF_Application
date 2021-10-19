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

namespace MTJatinMahajan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void hockeyButton_Click(object sender, RoutedEventArgs e)
        {
            Hockey hockey = new Hockey();
            hockey.Background = Brushes.Azure;
            hockey.Title = "Hockey Players";
            hockey.Show();
            this.Close();
        }

        private void basketButton_Click(object sender, RoutedEventArgs e)
        {
            BasketBall basket = new BasketBall();
            basket.Background = Brushes.Azure;
            basket.Title = "BasketBall Players";
            basket.Show();
            this.Close();
        }

        private void baseButton_Click(object sender, RoutedEventArgs e)
        {
            BaseBall baseBall = new BaseBall();
            baseBall.Background = Brushes.Azure;
            baseBall.Title = "BasketBall Players";
            baseBall.Show();
            this.Close();
        }
    }
}
