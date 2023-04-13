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
    /// Interaction logic for AddCarDataWindow.xaml
    /// </summary>
    public partial class AddCarDataWindow : Window
    {
        public AddCarDataWindow()
        {
            InitializeComponent();
            TypeCarCombo.ItemsSource = Helper.GetContext().TypeCars.ToList();
            TypeCarCombo.DisplayMemberPath = "Name";
        }

        private void AddCar_Click(object sender, RoutedEventArgs e)
        {
            if (NameCar.Text == null || StateNumberCar.Text == null || NumberPassengersCar.Text == null)
            {
                Close();
            }

            var newCar = new Car();
            newCar.Name = NameCar.Text;
            newCar.StateNumber = StateNumberCar.Text;
            newCar.NumberPassengers = Convert.ToInt32(NumberPassengersCar.Text);
            newCar.IdTypeCar = (int)TypeCarCombo.SelectedValue;

            Helper.GetContext().Cars.Add(newCar);
            Helper.GetContext().SaveChanges();
            Close();
        }
    }
}
