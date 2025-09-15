namespace IT_Portal.Domain.IT_Models;

public partial class UserIdmaster
{
    public int Id { get; set; }

    public int Sid { get; set; }

    public int LocationId { get; set; }

    public string EmployeeId { get; set; } = null!;

    public string? Status { get; set; }

    public bool? IsActive { get; set; }

    public string? RequestNumber { get; set; }

    public string? UserId { get; set; }

    public string? SoftwareType { get; set; }

    public string? SoftwareRole { get; set; }

    public string? UserGroups { get; set; }

    public string? UserSubgroups { get; set; }

    public string? RepositoryDomains { get; set; }

    public string? MasterAssignment { get; set; }

    public string? Salutation { get; set; }

    public string? Category { get; set; }

    public string? EquipmentName { get; set; }

    public string? EquipmentId { get; set; }

    public string? AreaOrLocation { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public string? AssignedPlants { get; set; }

    public string? RequestedBy { get; set; }

    public DateTime? RequestedOn { get; set; }
}
