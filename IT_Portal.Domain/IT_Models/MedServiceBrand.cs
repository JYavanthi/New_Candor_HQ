namespace IT_Portal.Domain.IT_Models;

public partial class MedServiceBrand
{
    public int Id { get; set; }

    public string? BrandCode { get; set; }

    public string? BrandDesc { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
