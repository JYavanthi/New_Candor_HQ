namespace IT_Portal.Domain.IT_Models;

public partial class DmfGrade
{
    public int DmfGradeId { get; set; }

    public string? DmfGradeDesc { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }

    public bool? IsActive { get; set; }
}
