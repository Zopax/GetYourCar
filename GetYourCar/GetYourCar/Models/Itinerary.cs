using System;
using System.Collections.Generic;

namespace GetYourCar.Models;

public partial class Itinerary
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Route> Routes { get; } = new List<Route>();
}
