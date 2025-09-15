namespace IT_Portal.Domain.IT_Models;

public partial class ChecklistTemplate
{
    public int ChecklisttemplateId { get; set; }

    public string? ChecklistIds { get; set; }

    public string? TemplateName { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
