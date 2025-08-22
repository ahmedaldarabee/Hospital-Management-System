using System;
using System.Collections.Generic;

namespace HospitalManagementSystem.DBEntities;

public partial class PatientHistory
{
    public int PatientHistoryId { get; set; }

    public int PatientId { get; set; }

    public DateOnly EntryDate { get; set; }

    public DateOnly OutDate { get; set; }

    public int DoctorId { get; set; }

    public string Status { get; set; } = null!;

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;
}
