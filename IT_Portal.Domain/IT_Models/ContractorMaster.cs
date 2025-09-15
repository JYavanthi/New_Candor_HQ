namespace IT_Portal.Domain.IT_Models;

public partial class ContractorMaster
{
    public int Id { get; set; }

    public string? ConId { get; set; }

    public string? ConName { get; set; }

    public int? Plant { get; set; }

    public int? Paygroup { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public DateTime? ValidityTill { get; set; }

    public bool? Active { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual PaygroupMaster? PaygroupNavigation { get; set; }

    public virtual PlantMaster? PlantNavigation { get; set; }
}
