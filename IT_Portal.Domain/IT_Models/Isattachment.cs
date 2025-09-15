namespace IT_Portal.Domain.IT_Models;

public partial class Isattachment
{
    public int AttachId { get; set; }

    public int? Isid { get; set; }

    public string? FileName { get; set; }

    public string? Stage { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
