using System;
using System.Collections.Generic;

namespace GetYourCar.Models;

public partial class RightsCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Driver> IdDrivers { get; } = new List<Driver>();
}
