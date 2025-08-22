using System;
using System.Collections.Generic;

namespace HospitalManagementSystem.DBEntities;

public partial class AppointmentDetail
{
    public int AppointmentDetailsId { get; set; }

    public int AppointmentDateId { get; set; }

    public int PatientId { get; set; }

    public virtual AppointmentDate AppointmentDate { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;
}
