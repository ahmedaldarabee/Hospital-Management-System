using System;
using System.Collections.Generic;

namespace HospitalManagementSystem.DBEntities;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public bool Gender { get; set; }

    public DateOnly JoinDate { get; set; }

    public decimal Salary { get; set; }

    public string Mobile { get; set; } = null!;

    public int? DepartmentId { get; set; }

    public int? SectionId { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Department? Department { get; set; }

    public virtual Section? Section { get; set; }
}
