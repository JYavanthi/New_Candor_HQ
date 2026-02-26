using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class VwGetSrapprover
{
    public string EmployeeNo { get; set; } = null!;

    public int ReportingManagerId { get; set; }

    public int ApprovingManagerId { get; set; }

    public int? RpmEmpId { get; set; }

    public int? HodEmpId { get; set; }

    public string ReportingManagerName { get; set; } = null!;

    public string Hodname { get; set; } = null!;
}
