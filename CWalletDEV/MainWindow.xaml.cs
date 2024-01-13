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
using ScottPlot.DataStructures;

namespace CWalletDEV
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

        private void TxtPlannedPay_MouseLeave(object sender, MouseEventArgs e)
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
