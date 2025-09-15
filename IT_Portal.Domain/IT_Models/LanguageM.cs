namespace IT_Portal.Domain.IT_Models;

public partial class LanguageM
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Language { get; set; } = null!;

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AppointmentLanguageDetail> AppointmentLanguageDetails { get; set; } = new List<AppointmentLanguageDetail>();
}
