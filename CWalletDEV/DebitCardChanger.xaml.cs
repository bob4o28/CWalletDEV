using LiveCharts;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CWalletDEV
{
    /// <summary>
    /// Interaction logic for DebitCardChanger.xaml
    /// </summary>
    public partial class DebitCardChanger : Window
    {
        private MainViewModel _viewModel;
        DbConnector dbConnector = new DbConnector();
        MainWindow mainWindow = new MainWindow();
        public DebitCardChanger()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
            this.DataContext = _viewModel;
            //Getting latest data
            //AreaChart
            _viewModel.AreaChartDebit = new ChartValues<double> { };
            _viewModel.LabelsDebit = new List<string> { };
            using (MySqlConnection conn = dbConnector.ConnectToDbWithSshTunnel())
            {
                if (conn == null || conn.State != ConnectionState.Open)
                    return;

                string query = "SELECT Date, DebitCard FROM MoneyHolders WHERE UserID = @MoneyUserID ORDER BY Date DESC LIMIT " + mainWindow.Days.ToString();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MoneyUserID", DbConnector.UserId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            //Filling the Area chart's Lists with data.
                            //The indexes are for the placement of the Filed into the Selected table preview, for example 1 is for second.
                            DateTime dateValue = reader.GetDateTime(0);
                            _viewModel.LabelsDebit.Add(dateValue.ToString("dd.MM.yyyy"));
                            _viewModel.AreaChartDebit.Add(reader.GetDouble(1));
                        }
                        _viewModel.LabelsDebit.Reverse();
                        List<double> temp = new List<double>(_viewModel.AreaChartDebit.Cast<double>());
                        temp.Reverse();
                        _viewModel.AreaChartDebit.Clear();
                        foreach (var item in temp)
                        {
                            _viewModel.AreaChartDebit.Add(item);
                        }

                    }
                }


            }
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
            if (DebitDatePick.SelectedDate.HasValue)
            {
                DateTime selectedDate = DebitDatePick.SelectedDate.Value;
                dbConnector.BasicRecordAdd(txtDebit.Text, selectedDate, "CreditCard");
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select date for the record you want to set.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                DebitDatePick.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7FD20B0B"));
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
