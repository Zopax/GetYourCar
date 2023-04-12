using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GetYourCar.Models;

public partial class Car
{
    public int Id { get; set; }

    public int IdTypeCar { get; set; }

    public string? Name { get; set; } = null!;

    public string? StateNumber { get; set; } = null!;

    public int NumberPassengers { get; set; }

    public virtual TypeCar IdTypeCarNavigation { get; set; } = null!;

    public virtual ICollection<Route> Routes { get; } = new List<Route>();

    public string TypeCar
    {
        get
        {
            return IdTypeCarNavigation.Name;
        }
    }
}
