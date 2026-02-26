using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class SrcitrixAccessHistory
{
    public int Srcahid { get; set; }

    public int? Srid { get; set; }

    public int Srcid { get; set; }

    public int? SupportId { get; set; }

    public string? RequestType { get; set; }

    public string? Adid { get; set; }

    public string? ReplaceAdid { get; set; }

    public string? AssetDetails { get; set; }

    public string? Ipaddress { get; set; }

    public string? HostName { get; set; }

    public string? SoftwareRequired { get; set; }

    public string? EmpType { get; set; }

    public string? Justification { get; set; }

    public string? Oupath { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
