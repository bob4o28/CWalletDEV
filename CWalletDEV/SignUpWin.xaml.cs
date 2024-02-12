using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace CWalletDEV
{
    /// <summary>
    /// Interaction logic for SignUpWin.xaml
    /// </summary>
    public partial class SignUpWin : Window
    {
        public SignUpWin()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LogInWin logInWin = new LogInWin();
            logInWin.Show();
            this.DialogResult = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult=true;
            DbConnector dbConnector = new DbConnector();
            dbConnector.AddUser(usernameTextBox.Text, passwordBox.Text);
            //dbConnector.CreateTable();
            //dbConnector.CreateUser(usernameTextBox.Text, passwordBox.Text);
        }
    }
}
