using LiveCharts;
using LiveCharts.Wpf;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SeriesCollection DataPoints { get; set; }
        public List<string> Labels { get; set; }

        public Func<double, string> Formatter { get; set; }

        //Event Var
        public string SidebarPos = "Open";



        public MainWindow()
        {
            InitializeComponent();
            //AREA CHART

            //data changer
            List<double> values = new List<double> { 10, 25, 15, 30, 20, 35, 25 };
            Labels = new List<string> { "Monday", "Tuesday", "Wednsday", "Thursday", "Friday", "Saturday", "Sunday" };

            // Binder
            DataPoints = new SeriesCollection
            {
                new LineSeries { Title = "Data Series", Values = new ChartValues<double>(values) }
            };

            Formatter = value => value.ToString(); // Format Y-axis labels

            DataContext = this;


        }
        //Menu button events
        private void TxtMenu_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if(SidebarPos=="Open")
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

        
    }
}
