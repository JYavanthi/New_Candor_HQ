namespace IT_Portal.Domain.IT_Models;

public partial class PrintTemplate
{
    public int PrintTemplateId { get; set; }

    public string TemplateType { get; set; } = null!;

    public string TemplateName { get; set; } = null!;

    public string? TemplateContent { get; set; }

    public virtual ICollection<AppointmentOfficialDetail> AppointmentOfficialDetails { get; set; } = new List<AppointmentOfficialDetail>();

    public virtual ICollection<EmployeeResignationDetail> EmployeeResignationDetails { get; set; } = new List<EmployeeResignationDetail>();

    public virtual ICollection<PrintTemplatePpcMapping> PrintTemplatePpcMappings { get; set; } = new List<PrintTemplatePpcMapping>();
}
