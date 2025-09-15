namespace IT_Portal.Domain.IT_Models;

public partial class PasswordPolicyMaster
{
    public int Id { get; set; }

    public int? ExpiryDays { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
