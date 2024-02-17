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
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            DbConnector dbConnector = new DbConnector();
            dbConnector.AddUser(txtUserName.Text, txtUserLastName.Text, txtUserEmail.Text, txtPassword.Text);
            dbConnector.SetUserId(txtUserEmail.Text);
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show(); 
            this.Close(); // Close the login window
            //dbConnector.CreateTable();
            //dbConnector.CreateUser(usernameTextBox.Text, passwordBox.Text);
        }
    }
}
