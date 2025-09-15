namespace IT_Portal.Domain.IT_Models;

public partial class Srvpnaccess
{
    public int? Srid { get; set; }

    public int Srvpnid { get; set; }

    public int? SupportId { get; set; }

    public string? RequestType { get; set; }

    public string? EmpPlant { get; set; }

    public string? AccessPermission { get; set; }

    public string? AccessList { get; set; }

    public string? AccessType { get; set; }

    public DateTime? AccessFromDt { get; set; }

    public DateTime? AccessToDt { get; set; }

    public string? EmpType { get; set; }

    public string? Justification { get; set; }

    public string? Attachment { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }

    public string? Location { get; set; }
}
