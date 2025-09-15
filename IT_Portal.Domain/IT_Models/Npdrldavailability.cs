namespace IT_Portal.Domain.IT_Models;

public partial class Npdrldavailability
{
    public int Id { get; set; }

    public string Npdnumber { get; set; } = null!;

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? BrandName { get; set; }

    public string? Strength { get; set; }
}
