using System;
using System.Collections.Generic;

namespace GetYourCar.Models;

public partial class TypeCar
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; } = new List<Car>();
}
