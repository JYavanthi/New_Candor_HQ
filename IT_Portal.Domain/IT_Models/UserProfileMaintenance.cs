namespace IT_Portal.Domain.IT_Models;

public partial class UserProfileMaintenance
{
    public int Id { get; set; }

    public int? FkProfileId { get; set; }

    public int? FkUserId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }
}
