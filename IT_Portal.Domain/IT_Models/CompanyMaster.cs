namespace IT_Portal.Domain.IT_Models;

public partial class CompanyMaster
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? LegalName { get; set; }

    public string DomainName { get; set; } = null!;

    public string? Type { get; set; }

    public string? Email { get; set; }

    public string? PrimaryContactNo { get; set; }

    public string? Address { get; set; }

    public string? CountryCode { get; set; }

    public string? CountryName { get; set; }

    public string? StateCode { get; set; }

    public string? StateName { get; set; }

    public string? City { get; set; }

    public string? PostalCode { get; set; }

    public string? ContactNumber { get; set; }

    public string? WebSite { get; set; }

    public string? CurrentLoggedIn { get; set; }

    public string? DbServerName { get; set; }

    public string? DbName { get; set; }

    public string? DbPort { get; set; }

    public string? DbUserName { get; set; }

    public string? DbPassword { get; set; }

    public DateTime? ApprovedDate { get; set; }

    public int? ApprovedBy { get; set; }

    public string? Gstn { get; set; }

    public string? Pan { get; set; }

    public string? ImgUrl { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<UserMaster> UserMasters { get; set; } = new List<UserMaster>();
}
