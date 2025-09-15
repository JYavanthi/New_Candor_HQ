namespace IT_Portal.Domain.IT_Models;

public partial class MastersStructureInput
{
    public int Id { get; set; }

    public int FkFormId { get; set; }

    public string? Header { get; set; }

    public string? SubHeader { get; set; }

    public string? Title { get; set; }

    public string? BreadCrumb { get; set; }

    public string? Field1 { get; set; }

    public string? Field2 { get; set; }

    public string? Field3 { get; set; }

    public string? Field4 { get; set; }

    public string? Field5 { get; set; }

    public string? Field6 { get; set; }

    public string? Field7 { get; set; }

    public string? Field8 { get; set; }

    public string? Field9 { get; set; }

    public string? Field10 { get; set; }

    public string? Field11 { get; set; }

    public string? Field12 { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual FormMaster FkForm { get; set; } = null!;
}
