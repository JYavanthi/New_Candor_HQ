namespace IT_Portal.Domain.IT_Models;

public partial class MedclaimDependantDetail
{
    public int Id { get; set; }

    public string? MediclaimNo { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public string? EmployeeId { get; set; }

    public string? DependantName { get; set; }

    public int? DependantAge { get; set; }

    public string? Relationship { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }
}
