namespace IT_Portal.Domain.IT_Models;

public partial class VwChecklistTemplate
{
    public int ChecklisttemplateId { get; set; }

    public string? ChecklistIds { get; set; }

    public string? TemplateName { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public string? CreatedByName { get; set; }

    public int? ModifiedBy { get; set; }
}
