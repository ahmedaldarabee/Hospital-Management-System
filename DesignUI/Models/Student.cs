using System;
using System.Collections.Generic;

namespace DesignUI.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public int? CountryId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public DateOnly? DataOfbirth { get; set; }

    public bool? Gender { get; set; }

    public int? DepartmentId { get; set; }

    public string? Mobile { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Country? Country { get; set; }

    public virtual ICollection<StudentTeacher> StudentTeachers { get; set; } = new List<StudentTeacher>();
}
