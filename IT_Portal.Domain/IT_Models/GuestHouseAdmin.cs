namespace IT_Portal.Domain.IT_Models;

public partial class GuestHouseAdmin
{
    public int Id { get; set; }

    public string EmployeeId { get; set; } = null!;

    public int GuestHouseLocationId { get; set; }

    public virtual GuestHouseLocation GuestHouseLocation { get; set; } = null!;
}
