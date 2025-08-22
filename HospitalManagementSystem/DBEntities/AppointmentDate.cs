using System;
using System.Collections.Generic;

namespace HospitalManagementSystem.DBEntities;

public partial class AppointmentDate
{
    public int AppointmentDateId { get; set; }

    public int DoctorId { get; set; }

    public string Day { get; set; } = null!;

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public virtual ICollection<AppointmentDetail> AppointmentDetails { get; set; } = new List<AppointmentDetail>();

    public virtual Doctor Doctor { get; set; } = null!;
}
