namespace IT_Portal.Domain.IT_Models;

public partial class VwPrtemplate
{
    public int PrtemplateId { get; set; }

    public string? TemplateName { get; set; }

    public bool? IsActive { get; set; }

    public int CreatedBy { get; set; }

    public string CreatedName { get; set; } = null!;

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
