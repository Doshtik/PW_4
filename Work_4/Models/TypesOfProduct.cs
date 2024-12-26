using System;
using System.Collections.Generic;

namespace Work_4.Models;

public partial class TypesOfProduct
{
    public int Id { get; set; }

    public string TypeOfProduct { get; set; } = null!;

    public decimal TypeCoefficent { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
