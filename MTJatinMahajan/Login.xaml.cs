using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MTJatinMahajan
{

    public partial class Login : Window
    {
        static int count = 0;
        Dictionary<String, UserLogin> dict = new Dictionary<string, UserLogin>()
        {
            {"Jatin",new UserLogin(++count,"Jatin","12345") },
            {"Sam",new UserLogin(++count,"Sam","12345") }
        };
        public Login()
        {
            InitializeComponent();
            this.Background = Brushes.Azure;
        
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            //if(txtBox.Text.Trim() == name && passBox.Password.Trim() == password)
            //{

            //    MainWindow mainWindow = new MainWindow();
            //    mainWindow.Background = Brushes.Azure;
            //    mainWindow.Title = "Welcome";
            //    mainWindow.Show();
            //    this.Close();
            //}
            //else
            //{
            //    MessageBox.Show("Login failed", "Fail Login", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
            var user = from obj in dict.Values
                       where (txtBox.Text.Trim() == obj.username) && (obj.password == passBox.Password.Trim())
                       select obj.username;
            if(user != null)
            {
                MainWindow mainWindow = new MainWindow();
                    mainWindow.Background = Brushes.Azure;
                    mainWindow.Title = "Welcome";
                    mainWindow.Show();
                    this.Close();
            }
            else
            {
                MessageBox.Show("Login failed", "Fail Login", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
