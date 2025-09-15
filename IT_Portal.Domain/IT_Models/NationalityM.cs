namespace IT_Portal.Domain.IT_Models;

public partial class NationalityM
{
    public int Id { get; set; }

    public string NatId { get; set; } = null!;

    public string? Nationality { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AppointmentPersonalDetail> AppointmentPersonalDetails { get; set; } = new List<AppointmentPersonalDetail>();
}
