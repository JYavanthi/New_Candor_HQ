namespace IT_Portal.Domain.IT_Models;

public partial class Pbmaster1
{
    public int Id { get; set; }

    public string Pbnumber { get; set; } = null!;

    public string? Npdnumber { get; set; }

    public string Status { get; set; } = null!;

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? ProductName { get; set; }

    public string? Speciality { get; set; }

    public string? Indication { get; set; }

    public string? Dosage { get; set; }

    public DateTime? PatentExpiryDate { get; set; }

    public string? RegulatoryStatus { get; set; }

    public string? ProposedDivisions { get; set; }
}
