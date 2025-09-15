namespace IT_Portal.Domain.IT_Models;

public partial class SrserverAccess
{
    public int? Srid { get; set; }

    public int SrserverId { get; set; }

    public int? SupportId { get; set; }

    public string? RequestType { get; set; }

    public string? Ipaddress { get; set; }

    public string? HostName { get; set; }

    public string? FileServerName { get; set; }

    public string? FolderPath { get; set; }

    public string? Justification { get; set; }

    public string? Attachment { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }
}
