using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class Srsoftware
{
    public int Swid { get; set; }

    public int? Srid { get; set; }

    public int? SupportId { get; set; }

    public string? SoftwareType { get; set; }

    public int? SoftwareName { get; set; }

    public int? SoftwareVersionName { get; set; }

    public string? VendorName { get; set; }

    public string? InstType { get; set; }

    public string? LicenceType { get; set; }

    public string? Location { get; set; }

    public string? Department { get; set; }

    public int? NoOfUers { get; set; }

    public int? NoOfLicence { get; set; }

    public decimal? CostPerLicence { get; set; }

    public decimal? TotalCost { get; set; }

    public bool? Amcappilcable { get; set; }

    public decimal? CostForAmc { get; set; }

    public string? ScopeOfAmc { get; set; }

    public bool? IsInstReq { get; set; }

    public decimal? InstCharge { get; set; }

    public string? DtlsOfInst { get; set; }

    public DateTime? DtlsOfinstDt { get; set; }

    public string? TypeOfDev { get; set; }

    public string? DtlsOfDev { get; set; }

    public bool? IsInterfaceReq { get; set; }

    public string? InterfaceReq { get; set; }

    public string? InterfaceWith { get; set; }

    public bool? IsGxpApp { get; set; }

    public string? NonFunReq { get; set; }

    public string? DtlsOfReq { get; set; }

    public string? WhereHosted { get; set; }

    public string? TypeOfWeb { get; set; }

    public string? UsageBy { get; set; }

    public string? UserAccessFrom { get; set; }

    public string? CurrVersion { get; set; }

    public string? TareVersion { get; set; }

    public string? Brds { get; set; }

    public string? BusJustification { get; set; }

    public string? Justification { get; set; }

    public bool IsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }

    public int? NoofUseruse { get; set; }
}
