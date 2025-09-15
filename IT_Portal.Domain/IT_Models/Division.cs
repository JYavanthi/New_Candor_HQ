namespace IT_Portal.Domain.IT_Models;

public partial class Division
{
    public int DivCode { get; set; }

    public string? DivDesc { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }

    public bool? IsActive { get; set; }

    public string? Hod { get; set; }
}
