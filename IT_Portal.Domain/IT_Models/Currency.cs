namespace IT_Portal.Domain.IT_Models;

public partial class Currency
{
    public int Id { get; set; }

    public string? Waers { get; set; }

    public string? Isocd { get; set; }

    public string? Ktext { get; set; }

    public DateTime? Gdatu { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<AppointmentPersonalDetail> AppointmentPersonalDetails { get; set; } = new List<AppointmentPersonalDetail>();
}
