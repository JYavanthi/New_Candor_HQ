using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class UserVal
{
    public int Id { get; set; }

    public int? EmpNum { get; set; }

    public string? ValCode { get; set; }

    public bool? IsActive { get; set; }

    public string? SecurityCode { get; set; }
}
