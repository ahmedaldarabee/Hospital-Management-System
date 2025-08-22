using System;
using System.Collections.Generic;

namespace HospitalManagementSystem.DBEntities;

public partial class Department
{
    public int DepartmentId { get; set; }

    public byte[] DepartmentName { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();
}
