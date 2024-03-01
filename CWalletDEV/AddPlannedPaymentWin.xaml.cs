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
            decimal worth = 0;
            try
            {
                worth = decimal.Parse(Worth.Text);
            }
            catch {
                NoInputLabel.Content = "Please give a worth to your planned payment!";
            }
                // Your DatePicker control is named 'DatePick'
                if (Date_Pick.SelectedDate.HasValue && name != null && worth != null)
                {
                    DateTime dueDate = Date_Pick.SelectedDate.Value;
                    dbConnector.AddPlannedPayment(name, worth, dueDate); 
                    this.Close();
            }
                else
                {
                    NoInputLabel.Content = "The worth or the date are not set!";
                }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e) { this.Close(); }

        private void DeletePlannedPayment(object sender, RoutedEventArgs e)
        {
            DbConnector dbConnector = new DbConnector();
            string name = Name.Text;
            decimal worth = 0;
            try
            {
                worth = decimal.Parse(Worth.Text);
            }
            catch
            {
                NoInputLabel.Content = "Please give a worth to your planned payment!";
                return; // Stop execution if worth is not provided
            }

            if (Date_Pick.SelectedDate.HasValue && !string.IsNullOrEmpty(name))
            {
                DateTime dueDate = Date_Pick.SelectedDate.Value;

                // Set the UserId property from the public variable
                int userId = DbConnector.UserId;

                // Check if the row exists before attempting to delete
                try
                {
                    dbConnector.RemoveRowFromDb(name, worth, dueDate, userId);
                    this.Close(); // Close the window after deletion
                }
                catch
                {
                    NoInputLabel.Content = "The planned payment does not exist!";
                }
            }
            else
            {
                NoInputLabel.Content = "The worth or the date are not set!";
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }
    }
}
