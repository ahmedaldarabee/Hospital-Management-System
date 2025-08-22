using System;
using System.Collections.Generic;

namespace HospitalManagementSystem.DBEntities;

public partial class InvoiceMaster
{
    public int InvoiceMasterId { get; set; }

    public string InvoiceNumber { get; set; } = null!;

    public DateTime TransactionDate { get; set; }

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();
}
