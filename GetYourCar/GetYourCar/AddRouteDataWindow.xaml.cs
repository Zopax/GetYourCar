using GetYourCar.Models;
using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for AddRouteDataWindow.xaml
    /// </summary>
    public partial class AddRouteDataWindow : Window
    {
        public AddRouteDataWindow()
        {
            InitializeComponent();

            ItinerariCombo.ItemsSource = Helper.GetContext().Itineraries.ToList();
            ItinerariCombo.DisplayMemberPath = "Name";

            CarCombo.ItemsSource = Helper.GetContext().Cars.ToList();
            CarCombo.DisplayMemberPath = "Name";

            DriverCombo.ItemsSource = Helper.GetContext().Drivers.ToList();
            DriverCombo.DisplayMemberPath = "LastName";

        }

        private void AddRoute_Click(object sender, RoutedEventArgs e)
        {
            var newRoute = new Route();
            newRoute.IdItinerary = (int)ItinerariCombo.SelectedValue;
            newRoute.IdCar = (int)CarCombo.SelectedValue;
            newRoute.IdDriver = (int)DriverCombo.SelectedValue;

            if (PassengerRouteNumber.Text == "")
            {
                newRoute.NumberPassengers = 0;
                Helper.GetContext().Routes.Add(newRoute);
                Helper.GetContext().SaveChanges();
                Close();
                return;
            }

            newRoute.NumberPassengers = Convert.ToInt32(PassengerRouteNumber.Text);
            Helper.GetContext().Routes.Add(newRoute);
            Helper.GetContext().SaveChanges();
            Close();
        }
    }
}
