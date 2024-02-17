using LiveCharts;
using LiveCharts.Wpf;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Event Var
        public string SidebarPos = "Open";

        private MainViewModel _viewModel;
        public int CurUser;
        public int Days;
        private string CurMoney;
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
            this.DataContext = _viewModel;
            DbConnector dbConnector = new DbConnector();

            // Initialize your ChartValues and Labels
            //PieCart
            _viewModel.PieValuesCash = new ChartValues<double> { };
            _viewModel.PieValuesBank = new ChartValues<double> { };
            _viewModel.PieValuesDebit = new ChartValues<double> { };
            _viewModel.PieValuesCredit = new ChartValues<double> { };
            _viewModel.PieValuesSavings = new ChartValues<double> { };
            _viewModel.PieValuesCrypto = new ChartValues<double> { };
            //AreaChart
            _viewModel.ChartValues = new ChartValues<double> { };
            _viewModel.Labels = new List<string> { };
            //Test for the current user
            CurUser = DbConnector.UserId;

            //Days to display at the main chart by select of the user.
            Days = 7;

            using (MySqlConnection conn = dbConnector.ConnectToDbWithSshTunnel())
            {
                if (conn == null || conn.State != ConnectionState.Open)
                    return;

                string query = "SELECT Date, Sum FROM MoneyHolders WHERE UserID = @MoneyUserID ORDER BY Date DESC LIMIT " + Days.ToString();
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
                            _viewModel.Labels.Add(dateValue.ToString("dd.MM.yyyy"));
                            _viewModel.ChartValues.Add(reader.GetDouble(1));
                        }
                        _viewModel.Labels.Reverse();
                        List<double> temp = new List<double>(_viewModel.ChartValues.Cast<double>());
                        temp.Reverse();
                        _viewModel.ChartValues.Clear();
                        foreach (var item in temp)
                        {
                            _viewModel.ChartValues.Add(item);
                        }

                        CurMoney = temp.Last().ToString();
                        lblCurMoney.Content += CurMoney;



                    }
                }


                string query1 = "SELECT Cash, Bank, DebitCard, CreditCard, Savings, Crypto FROM MoneyHolders WHERE UserID = @MoneyUserID ORDER BY Date DESC LIMIT 1";
                using (MySqlCommand cmd = new MySqlCommand(query1, conn))
                {
                    cmd.Parameters.AddWithValue("@MoneyUserID", DbConnector.UserId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            //Filling the Pie chart's Lists with data.
                            _viewModel.PieValuesCash.Add(reader.GetDouble(0));
                            _viewModel.PieValuesBank.Add(reader.GetDouble(1));
                            _viewModel.PieValuesDebit.Add(reader.GetDouble(2));
                            _viewModel.PieValuesCredit.Add(reader.GetDouble(3));
                            _viewModel.PieValuesSavings.Add(reader.GetDouble(4));
                            _viewModel.PieValuesCrypto.Add(reader.GetDouble(5));
                        }



                    }
                }
            }

        }

        //Menu button events
        private void TxtMenu_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (SidebarPos == "Open")
            {
                Storyboard storyboard = this.FindResource("SidebarShrink") as Storyboard;
                if (storyboard != null)
                {
                    storyboard.Begin();
                }
                SidebarPos = "Close";
            }
            else
            {
                Storyboard storyboard = this.FindResource("SidebarOpen") as Storyboard;
                if (storyboard != null)
                {
                    storyboard.Begin();
                }
                SidebarPos = "Open";
            }

        }



        //Sidebar Buttons Cosmetic mouse ove effects
        private void TxtMenu_MouseEnter(object sender, MouseEventArgs e)
        {
            Storyboard storyboard = this.FindResource("MenuEnter") as Storyboard;
            if (storyboard != null)
            {
                storyboard.Begin();
            }
        }

        private void TxtMenu_MouseLeave(object sender, MouseEventArgs e)
        {
            Storyboard storyboard = this.FindResource("MenuLeave") as Storyboard;
            if (storyboard != null)
            {
                storyboard.Begin();
            }
        }

        private void TxtCategory_MouseEnter(object sender, MouseEventArgs e)
        {
            Storyboard storyboard = this.FindResource("CategoryEnter") as Storyboard;
            if (storyboard != null)
            {
                storyboard.Begin();
            }
        }

        private void TxtCategory_MouseLeave(object sender, MouseEventArgs e)
        {
            Storyboard storyboard = this.FindResource("CategoryLeave") as Storyboard;
            if (storyboard != null)
            {
                storyboard.Begin();
            }
        }

        private void TxtStats_MouseEnter(object sender, MouseEventArgs e)
        {
            Storyboard storyboard = this.FindResource("StatsEnter") as Storyboard;
            if (storyboard != null)
            {
                storyboard.Begin();
            }
        }

        private void TxtStats_MouseLeave(object sender, MouseEventArgs e)
        {
            Storyboard storyboard = this.FindResource("StatsLeave") as Storyboard;
            if (storyboard != null)
            {
                storyboard.Begin();
            }
        }

        private void TxtPlannedPay_MouseEnter(object sender, MouseEventArgs e)
        {
            Storyboard storyboard = this.FindResource("PayEnter") as Storyboard;
            if (storyboard != null)
            {
                storyboard.Begin();
            }
        }

        private void TxtPlannedPay_MouseLeave_1(object sender, MouseEventArgs e)
        {
            Storyboard storyboard = this.FindResource("PayLeave") as Storyboard;
            if (storyboard != null)
            {
                storyboard.Begin();
            }
        }

        private void TxtSettings_MouseEnter(object sender, MouseEventArgs e)
        {
            Storyboard storyboard = this.FindResource("SettingsEnter") as Storyboard;
            if (storyboard != null)
            {
                storyboard.Begin();
            }
        }

        private void TxtSettings_MouseLeave(object sender, MouseEventArgs e)
        {
            Storyboard storyboard = this.FindResource("SettingsLeave") as Storyboard;
            if (storyboard != null)
            {
                storyboard.Begin();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //// Assign values to the properties
            //_viewModel.AreaChartValues = new ChartValues<double> { 15, 15, 20, 47, 8, 78, 6 };
            //_viewModel.DaysOfWeel = new[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };

        }

        private void btnCash_MouseUp(object sender, MouseButtonEventArgs e)
        {
            CashChanger CashChanger = new CashChanger();
            CashChanger.ShowDialog();
        }

        private void btnCash_MouseEnter(object sender, MouseEventArgs e)
        {
            Storyboard storyboard = this.FindResource("btnCashEnter") as Storyboard;
            if (storyboard != null)
            {
                storyboard.Begin();
            }
        }

        private void btnCash_MouseLeave(object sender, MouseEventArgs e)
        {
            Storyboard storyboard = this.FindResource("btnCashLeave") as Storyboard;
            if (storyboard != null)
            {
                storyboard.Begin();
            }
        }

        private void btnSavings_MouseEnter(object sender, MouseEventArgs e)
        {
            Storyboard storyboard = this.FindResource("btnSavingsEnter") as Storyboard;
            if (storyboard != null)
            {
                storyboard.Begin();
            }
        }

        private void btnSavings_MouseLeave(object sender, MouseEventArgs e)
        {
            Storyboard storyboard = this.FindResource("btnSavingsLeave") as Storyboard;
            if (storyboard != null)
            {
                storyboard.Begin();
            }
        }

        private void btnDebit_MouseEnter(object sender, MouseEventArgs e)
        {
            Storyboard storyboard = this.FindResource("btnDebitEnter") as Storyboard;
            if (storyboard != null)
            {
                storyboard.Begin();
            }
        }

        private void btnDebit_MouseLeave(object sender, MouseEventArgs e)
        {
            Storyboard storyboard = this.FindResource("btnDebitLeave") as Storyboard;
            if (storyboard != null)
            {
                storyboard.Begin();
            }
        }

        private void btnCredit_MouseEnter(object sender, MouseEventArgs e)
        {
            Storyboard storyboard = this.FindResource("btnCreditEnter") as Storyboard;
            if (storyboard != null)
            {
                storyboard.Begin();
            }
        }

        private void btnCredit_MouseLeave(object sender, MouseEventArgs e)
        {
            Storyboard storyboard = this.FindResource("btnCreditLeave") as Storyboard;
            if (storyboard != null)
            {
                storyboard.Begin();
            }
        }

        private void btnBank_MouseEnter(object sender, MouseEventArgs e)
        {
            Storyboard storyboard = this.FindResource("btnBankEnter") as Storyboard;
            if (storyboard != null)
            {
                storyboard.Begin();
            }
        }

        private void btnBank_MouseLeave(object sender, MouseEventArgs e)
        {
            Storyboard storyboard = this.FindResource("btnBankLeave") as Storyboard;
            if (storyboard != null)
            {
                storyboard.Begin();
            }
        }

        private void btnCrypto_MouseEnter(object sender, MouseEventArgs e)
        {
            Storyboard storyboard = this.FindResource("btnCryptoEnter") as Storyboard;
            if (storyboard != null)
            {
                storyboard.Begin();
            }
        }

        private void btnCrypto_MouseLeave(object sender, MouseEventArgs e)
        {
            Storyboard storyboard = this.FindResource("btnCryptoLeave") as Storyboard;
            if (storyboard != null)
            {
                storyboard.Begin();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Assign values to the properties
            //_viewModel.ChartValues = new ChartValues<double> { 15, 15, 20, 47, 8, 78, 6 };
            //_viewModel.Labels = new[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };




        }

        private void btnSavings_MouseUp(object sender, MouseButtonEventArgs e)
        {
            SavingsChanger SavingsChanger = new SavingsChanger();
            SavingsChanger.ShowDialog();
        }

        private void btnDebit_MouseUp(object sender, MouseButtonEventArgs e)
        {
            DebitCardChanger DebitChanger = new DebitCardChanger();
            DebitChanger.ShowDialog();
        }

        private void btnCredit_MouseUp(object sender, MouseButtonEventArgs e)
        {
            CreditCardChanger CreditCardChanger = new CreditCardChanger();
            CreditCardChanger.ShowDialog();
        }

        private void btnBank_MouseUp(object sender, MouseButtonEventArgs e)
        {
            BankChanger BankChanger = new BankChanger();
            BankChanger.ShowDialog();
        }

        private void btnCrypto_MouseUp(object sender, MouseButtonEventArgs e)
        {
            CryptoChanger CryptoChanger = new CryptoChanger();
            CryptoChanger.ShowDialog();
        }

        private void TxtSettings_MouseUp(object sender, MouseButtonEventArgs e)
        {
            SettingsWin Setting = new SettingsWin();
            Setting.ShowDialog();
        }



        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            SignUpWin signUpWin = new SignUpWin();
            signUpWin.ShowDialog();
        }

        private void TxtPlannedPay_MouseUp(object sender, MouseButtonEventArgs e)
        {
            PlannedPaymentsWindow plannedPaymentsWindow = new PlannedPaymentsWindow();
            plannedPaymentsWindow.Show();
            this.Close();
        }
    }
}
