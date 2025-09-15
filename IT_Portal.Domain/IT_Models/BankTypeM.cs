namespace IT_Portal.Domain.IT_Models;

public partial class BankTypeM
{
    public int Id { get; set; }

    public string? BankCountry { get; set; }

    public string? BankKey { get; set; }

    public string? Name { get; set; }

    public string? Region { get; set; }

    public string? Street { get; set; }

    public string? City { get; set; }

    public string? SwiftBic { get; set; }

    public string? BankNumber { get; set; }

    public string? BranchName { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AppointmentPersonalDetail> AppointmentPersonalDetails { get; set; } = new List<AppointmentPersonalDetail>();
}
