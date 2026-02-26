using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class DepartmentMaster
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Status { get; set; } = null!;

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public string? ModifiedDt { get; set; }
}
