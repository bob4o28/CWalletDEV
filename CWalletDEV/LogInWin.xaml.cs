using System;
using System.Collections.Generic;
using System.Data.Common;
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
    /// Interaction logic for LogInWin.xaml
    /// </summary>
    public partial class LogInWin : Window
    {
        public LogInWin()
        {
            InitializeComponent();
        }

        private void btnNoAcc_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            SignUpWin signUpWin = new SignUpWin();
            signUpWin.Show();
            
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            DbConnector dbConnector = new DbConnector();
            string userName = txtUserName.Text;
            string password = txtPassword.Text;

            if (dbConnector.CheckLogin(userName, password))
            {
                // Credentials are correct, allow the user to access the application
                MessageBox.Show("Login successful. Welcome to the app!");
                // Navigate to the main application window
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close(); // Close the login window
            }
            else
            {
                WrongCredentialsLabel = "Wrong username and password";
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }
        
    }
}
