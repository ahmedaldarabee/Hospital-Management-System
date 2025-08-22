using System;
using System.Collections.Generic;

namespace HospitalManagementSystem.DBEntities;

public partial class ShiftType
{
    public int ShiftTypeId { get; set; }

    public string ShiftName { get; set; } = null!;

    public string Day { get; set; } = null!;

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}
