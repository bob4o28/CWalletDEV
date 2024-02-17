using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for PlannedPaymentsWindow.xaml
    /// </summary>
    public partial class PlannedPaymentsWindow : Window
    {
        public PlannedPaymentsWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddPlannedPaymentWin addPlannedPaymentWin = new AddPlannedPaymentWin();
            addPlannedPaymentWin.ShowDialog();
        }

        private void LoadData()
        {
            DataTable dt = GetDataTable(); // Your method to get data from the database
            dataGrid.ItemsSource = dt.DefaultView;
        }

        private DataTable GetDataTable()
        {
            DbConnector dbConnector1 = new DbConnector();
            DataTable dt = new DataTable();
            using (MySqlConnection conn = dbConnector1.ConnectToDbWithSshTunnel())
            {
                string query = "Select IdPlannedPayemnts, NameOfPP, WorthOfPP, DueDatte FROM cwallet.PlannedPayments WHERE IdUsers = @PPUser";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PPUser", DbConnector.UserId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            return dt;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

                // Refresh logic here
                // For example, if you want to fully refresh the window, you can create a new one and close the current one
                PlannedPaymentsWindow plannedPaymentsWindow = new PlannedPaymentsWindow();
                Application.Current.MainWindow = plannedPaymentsWindow;
                plannedPaymentsWindow.Show();
                this.Close();

        }
    }
}
