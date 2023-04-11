using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GetYourCar.Models;

public partial class Driver
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly Birthdate { get; set; }


    public virtual ICollection<Route> Routes { get; } = new List<Route>();

    public virtual ICollection<RightsCategory> IdRightsCategories { get; } = new List<RightsCategory>();
    public string RightsCategories
    {
        get 
        {
            var d = Helper.GetContext().Drivers.Include(t => t.IdRightsCategories).First(w => w.Id == this.Id);
            var r = d.IdRightsCategories.Select(r => r.Name);
            return string.Join(", ", r);
        }
    }
}
