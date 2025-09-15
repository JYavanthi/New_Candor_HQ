namespace IT_Portal.Domain.IT_Models;

public partial class SrusbaccessHistory
{
    public int Srusbhid { get; set; }

    public int? Srid { get; set; }

    public int Srusbaid { get; set; }

    public int? SupportId { get; set; }

    public string? Adid { get; set; }

    public string? AssetDetails { get; set; }

    public string? HostName { get; set; }

    public string? DeviceType { get; set; }

    public DateTime? DurationFrom { get; set; }

    public DateTime? DurationTo { get; set; }

    public string? AccessType { get; set; }

    public string? Ipaddress { get; set; }

    public string? EmpType { get; set; }

    public string? Justification { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
