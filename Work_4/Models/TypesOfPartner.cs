﻿using System;
using System.Collections.Generic;

namespace Work_4.Models;

public partial class TypesOfPartner
{
    public int Id { get; set; }

    public string TypeOfPartner { get; set; } = null!;


    public virtual ICollection<Partner> Partners { get; set; } = new List<Partner>();
}
