namespace IT_Portal.Domain.IT_Models;

public partial class SubDosageType
{
    public int Id { get; set; }

    public int DosageTypeId { get; set; }

    public string Name { get; set; } = null!;

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
