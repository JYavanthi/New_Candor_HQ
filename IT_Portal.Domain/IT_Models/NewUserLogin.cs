namespace IT_Portal.Domain.IT_Models;

public partial class NewUserLogin
{
    public int Id { get; set; }

    public int? RoleId { get; set; }

    public int? SubRoleId { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? UserId { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public string? AcessLevel { get; set; }

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Designation { get; set; }

    public bool? IsApproved { get; set; }

    public bool? IsLockedout { get; set; }

    public DateTime? LastLoginDate { get; set; }

    public DateTime? LastPasswordChangedDate { get; set; }

    public int? FailedPasswordCount { get; set; }

    public string? RedirectUrl { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }
}
