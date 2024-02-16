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
    /// Interaction logic for AddPlannedPaymentWin.xaml
    /// </summary>
    public partial class AddPlannedPaymentWin : Window
    {
        public AddPlannedPaymentWin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

                DbConnector dbConnector = new DbConnector();
                string name = Name.Text;
                decimal worth = decimal.Parse(Worth.Text);

                // Your DatePicker control is named 'DatePick'
                if (Date_Pick.SelectedDate.HasValue)
                {
                    DateTime dueDate = Date_Pick.SelectedDate.Value;
                    dbConnector.AddPlannedPayment(name, worth, dueDate);
                    this.Close();
                }
                else
                {
                    // Handle the case where no date is selected
                }
        }
    }
}
