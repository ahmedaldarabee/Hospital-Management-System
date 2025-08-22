using System;
using System.Collections.Generic;

namespace DesignUI.Models;

public partial class StudentTeacher
{
    public int StudentTeacherId { get; set; }

    public int? StudentId { get; set; }

    public int? TecherId { get; set; }

    public virtual Student? Student { get; set; }
}
