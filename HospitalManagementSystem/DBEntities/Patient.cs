using System;
using System.Collections.Generic;

namespace HospitalManagementSystem.DBEntities;

public partial class Patient
{
    public int PatientId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public bool Gender { get; set; }

    public string Mobile { get; set; } = null!;

    public string BloodType { get; set; } = null!;

    public bool IsInsurance { get; set; }

    public int InsurancePercent { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<AppointmentDetail> AppointmentDetails { get; set; } = new List<AppointmentDetail>();

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();

    public virtual ICollection<PatientHistory> PatientHistories { get; set; } = new List<PatientHistory>();
}
