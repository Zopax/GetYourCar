using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace GetYourCar.Models;

public partial class Route
{
    public int Id { get; set; }

    public int IdDriver { get; set; }

    public int IdCar { get; set; }

    public int IdItinerary { get; set; }

    public int NumberPassengers { get; set; }

    public virtual Car IdCarNavigation { get; set; } = null!;

    public virtual Driver IdDriverNavigation { get; set; } = null!;

    public virtual Itinerary IdItineraryNavigation { get; set; } = null!;

    public string Car { get => IdCarNavigation.Name; }
    public string Driver 
    { 
        get
        {
            var firstName = IdDriverNavigation.FirstName;
            var lastName = IdDriverNavigation.LastName;
            return firstName + " " + lastName;
        }
     
    }

    public string Itinerary { get => IdItineraryNavigation.Name; }
}
