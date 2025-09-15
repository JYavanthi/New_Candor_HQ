namespace IT_Portal.Domain.IT_Models;

public partial class ProdLockoutMaster
{
    public int Id { get; set; }

    public string EmployeeId { get; set; } = null!;

    public int? Count { get; set; }

    public bool? LockoutFlag { get; set; }

    public DateTime? LockoutDate { get; set; }

    public bool? IsActive { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
