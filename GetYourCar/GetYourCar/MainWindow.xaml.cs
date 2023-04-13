using Azure;
using GetYourCar.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GetYourCar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            DriversDGrid.ItemsSource = Helper.GetContext().Drivers.ToList();
            CarsDGrid.ItemsSource = Helper.GetContext().Cars.Include(i => i.IdTypeCarNavigation).ToList();
            RoutesDGrid.ItemsSource = Helper.GetContext().Routes
                    .Include(w => w.IdCarNavigation).Include(w => w.IdDriverNavigation)
                    .Include(w => w.IdItineraryNavigation).ToList();
        }

        private void AddRoute_Click(object sender, RoutedEventArgs e)
        {
            Window addRoute = new AddRouteDataWindow();
            addRoute.Show();
        }

        private void AddCar_Click(object sender, RoutedEventArgs e)
        {
            Window addCar = new AddCarDataWindow();
            addCar.Show();
        }

        private void AddDriver_Click(object sender, RoutedEventArgs e)
        {
            Window addDriver = new AddDriverDataWindow();
            addDriver.Show();
        }

        private void UpdateRoute_Click(object sender, RoutedEventArgs e)
        {
            RoutesDGrid.ItemsSource = Helper.GetContext().Routes.ToList();
        }

        private void UpdateCar_Click(object sender, RoutedEventArgs e)
        {
            CarsDGrid.ItemsSource = Helper.GetContext().Cars.ToList();
        }

        private void UpdateDriver_Click(object sender, RoutedEventArgs e)
        {
            DriversDGrid.ItemsSource = Helper.GetContext().Drivers.ToList();
        }
    }
}
