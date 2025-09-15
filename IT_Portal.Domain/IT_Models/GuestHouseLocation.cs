namespace IT_Portal.Domain.IT_Models;

public partial class GuestHouseLocation
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<GuestHouseAdmin> GuestHouseAdmins { get; set; } = new List<GuestHouseAdmin>();
}
