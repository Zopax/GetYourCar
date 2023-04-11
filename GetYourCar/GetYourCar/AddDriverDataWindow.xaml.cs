using GetYourCar.Models;
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

namespace GetYourCar
{
    /// <summary>
    /// Interaction logic for AddDriverDataWindow.xaml
    /// </summary>
    public partial class AddDriverDataWindow : Window
    {
        public AddDriverDataWindow()
        {
            InitializeComponent();
        }

        private void Adddriver_Click(object sender, RoutedEventArgs e)
        {
            if (fNameDriver.Text == null || lNameDriver.Text == null || fNameDriver.Text == null || birthDriver.Text == null)
            {
                Close();
            }

            var newDriver = new Driver();
            newDriver.FirstName = fNameDriver.Text;
            newDriver.LastName = lNameDriver.Text;
            newDriver.Birthdate = DateOnly.Parse(birthDriver.Text);
            Helper.GetContext().Drivers.Add(newDriver);
            Helper.GetContext().SaveChanges();
            Close();
        }
    }
}
