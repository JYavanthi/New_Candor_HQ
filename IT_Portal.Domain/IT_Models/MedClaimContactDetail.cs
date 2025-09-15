namespace IT_Portal.Domain.IT_Models;

public partial class MedClaimContactDetail
{
    public int Id { get; set; }

    public string? Level { get; set; }

    public string? Name { get; set; }

    public string? Designation { get; set; }

    public string? MobileNo { get; set; }

    public string? Email { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
