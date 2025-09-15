namespace IT_Portal.Domain.IT_Models;

public partial class Npdp2pmanufacturer
{
    public int Id { get; set; }

    public string Npdnumber { get; set; } = null!;

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? VendorName { get; set; }

    public string? Location { get; set; }

    public int? TentativeCost { get; set; }
}
