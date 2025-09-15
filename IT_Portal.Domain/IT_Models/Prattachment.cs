namespace IT_Portal.Domain.IT_Models;

public partial class Prattachment
{
    public int AttachId { get; set; }

    public int? Prid { get; set; }

    public int? PrissueId { get; set; }

    public int? PrtaskId { get; set; }

    public int? PrmlId { get; set; }

    public int? PrcheckListId { get; set; }

    public string? FileName { get; set; }

    public string? Stage { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
