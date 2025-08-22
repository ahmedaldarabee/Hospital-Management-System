using System;
using System.Collections.Generic;

namespace DesignUI.Models;

public partial class Country
{
    public int CountryId { get; set; }

    public string? CountryName { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
