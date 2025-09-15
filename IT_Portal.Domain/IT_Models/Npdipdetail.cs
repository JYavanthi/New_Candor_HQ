namespace IT_Portal.Domain.IT_Models;

public partial class Npdipdetail
{
    public int Id { get; set; }

    public string Npdnumber { get; set; } = null!;

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public int? CountryWhereApproved { get; set; }

    public string? PatentStatus { get; set; }

    public string? GenericPatentNumber { get; set; }

    public DateTime? GenericPatentExpiryDate { get; set; }

    public string? SpecificPatentNumber { get; set; }

    public DateTime? SpecificPatentExpiryDate { get; set; }

    public string? FormulationPatentNumber { get; set; }

    public DateTime? FormulationPatentExpiryDate { get; set; }

    public DateTime? EntryDate { get; set; }
}
