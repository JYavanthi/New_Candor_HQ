using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class Srurlaccess
{
    public int? Srid { get; set; }

    public int? SupportId { get; set; }

    public int Srurlid { get; set; }

    public string? RequestType { get; set; }

    public string? HostName { get; set; }

    public string? Ipaddress { get; set; }

    public string? Urlrequired { get; set; }

    public string? EmpType { get; set; }

    public string? Justification { get; set; }

    public string? Attachment { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateOnly? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateOnly? ModifiedDt { get; set; }
}
