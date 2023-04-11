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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadDataDriver();
            LoadDataCar();
            LoadDataRoute();
        }

        void LoadDataDriver()
        {
            DriversDGrid.ItemsSource = Helper.GetContext().Drivers.ToList();
        }

        void LoadDataCar()
        {
            CarsDGrid.ItemsSource = Helper.GetContext().Cars.Include(i => i.IdTypeCarNavigation).ToList();
        }

        void LoadDataRoute()
        {
            RoutesDGrid.ItemsSource = Helper.GetContext().Routes
                .Include(w => w.IdCarNavigation).Include(w => w.IdDriverNavigation)
                .Include(w => w.IdItineraryNavigation).ToList();
        }
    }
}
