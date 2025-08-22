using System;
using System.Collections.Generic;

namespace HospitalManagementSystem.DBEntities;

public partial class Doctor
{
    public int DoctorId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public bool Gender { get; set; }

    public DateOnly JoinDate { get; set; }

    public decimal Salary { get; set; }

    public string Mobile { get; set; } = null!;

    public int ShiftTypeId { get; set; }

    public int SpecializationId { get; set; }

    public int YearsOfExperience { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<AppointmentDate> AppointmentDates { get; set; } = new List<AppointmentDate>();

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();

    public virtual ICollection<PatientHistory> PatientHistories { get; set; } = new List<PatientHistory>();

    public virtual ShiftType ShiftType { get; set; } = null!;

    public virtual Specialization Specialization { get; set; } = null!;
}
