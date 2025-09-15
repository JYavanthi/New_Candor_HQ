namespace IT_Portal.Domain.IT_Models;

public partial class VwCrtemplate
{
    public int CrtemplateDtlsId { get; set; }

    public int CrtemplateId { get; set; }

    public int? SysLandscapeId { get; set; }

    public int? CategoryId { get; set; }

    public int? CategoryTypId { get; set; }

    public string? TaskName { get; set; }

    public string? TaskDesc { get; set; }

    public int? Priority { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }

    public string? TemplateName { get; set; }
}
