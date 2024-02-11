using LiveCharts;
using LiveCharts.Wpf;
using MySql.Data.MySqlClient;
using Renci.SshNet;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace CWalletDEV
{
    // <summary>
    /// Interaction logic for BankChanger.xaml
    /// </summary>
    public partial class BankChanger : Window
    {
        private MainViewModel _viewModel;
        public class DbConnector
        {
            public MySqlConnection ConnectToDbWithSshTunnel()
            {
                // SSH connection info
                string sshHost = "83.229.87.97";
                string sshUsername = "root";
                string sshPassword = "kamaCwallet!2023";
                int sshPort = 22;

                // Database connection info
                string dbServer = "127.0.0.1";
                string dbUsername = "dev";
                string dbPassword = "Cwallet.dev.24";
                string dbName = "cwallet";
                int dbPort = 3306;

                using (var client = new SshClient(sshHost, sshPort, sshUsername, sshPassword))
                {
                    client.Connect();

                    if (client.IsConnected)
                    {
                        var port = new ForwardedPortLocal("127.0.0.1", (uint)dbPort, dbServer, (uint)dbPort);
                        client.AddForwardedPort(port);
                        port.Start();

                        string connStr = $"Server=127.0.0.1;Port={port.BoundPort};Database={dbName};Uid={dbUsername};Pwd={dbPassword};";
                        MySqlConnection conn = new MySqlConnection(connStr);
                        conn.Open();

                        return conn;
                    }
                    else
                    {
                        // Handle SSH connection failure
                        return null;
                    }
                }
            }
        }
        public BankChanger()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
            this.DataContext = _viewModel;
            _viewModel.ChartValues = new ChartValues<double> { 15, 15, 20, 47, 8, 78, 6 };
            _viewModel.Labels = new[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
            _viewModel.PieValuesCash = new ChartValues<double> { 5.0 };
        }

        private void ellipseAdd_MouseEnter(object sender, MouseEventArgs e)
        {
            Storyboard storyboard = this.FindResource("AddEnter") as Storyboard;
            if (storyboard != null)
            {
                storyboard.Begin();
            }
        }

        private void ellipseAdd_MouseLeave(object sender, MouseEventArgs e)
        {
            Storyboard storyboard = this.FindResource("AddLeave") as Storyboard;
            if (storyboard != null)
            {
                storyboard.Begin();
            }
        }


        public string AddPos = "First";
        private void ellipseAdd_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (AddPos == "First")
            {
                Storyboard storyboard = this.FindResource("AddFirstPress") as Storyboard;
                if (storyboard != null)
                {
                    storyboard.Begin();
                }
                AddPos = "Second";
            }
            else
            {
                Storyboard storyboard = this.FindResource("AddSecondPress") as Storyboard;
                if (storyboard != null)
                {
                    storyboard.Begin();
                }
                AddPos = "First";
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
