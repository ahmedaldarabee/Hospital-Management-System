using System;
using System.Collections.Generic;

namespace HospitalManagementSystem.DBEntities;

public partial class Section
{
    public int SectionId { get; set; }

    public int DepartmentId { get; set; }

    public string SectionName { get; set; } = null!;

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
