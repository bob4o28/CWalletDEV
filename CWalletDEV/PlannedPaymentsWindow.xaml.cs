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
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddPlannedPaymentWin addPlannedPaymentWin = new AddPlannedPaymentWin();
            addPlannedPaymentWin.ShowDialog();
        }
    }
}
