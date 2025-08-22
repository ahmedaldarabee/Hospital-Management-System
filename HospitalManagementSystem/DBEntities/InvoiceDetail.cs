using System;
using System.Collections.Generic;

namespace HospitalManagementSystem.DBEntities;

public partial class InvoiceDetail
{
    public int InvoiceDetailsId { get; set; }

    public int InvoiceMasterId { get; set; }

    public int PatientId { get; set; }

    public int DoctorId { get; set; }

    public decimal Amount { get; set; }

    public decimal NetAmount { get; set; }

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual InvoiceMaster InvoiceMaster { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;
}
