using System;
using System.Collections.Generic;

namespace HospitalManagementSystem.DBEntities;

public partial class Error
{
    public int Id { get; set; }

    public string? ErrorMessage { get; set; }

    public string? InnerException { get; set; }

    public string? StackTrace { get; set; }

    public DateTime? TransactionDate { get; set; }
}
