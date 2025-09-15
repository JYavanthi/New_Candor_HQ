namespace IT_Portal.Domain.IT_Models;

public partial class ChecklistItem
{
    public int ChecklistItemId { get; set; }

    public string ChecklistType { get; set; } = null!;

    public int ObjectId { get; set; }

    public string ObjectType { get; set; } = null!;

    public string Title { get; set; } = null!;

    public int DepartmentId { get; set; }

    public int SpocemployeeId { get; set; }

    public string Status { get; set; } = null!;

    public int? CompletedById { get; set; }

    public DateTime? CompletedDate { get; set; }

    public string? Remarks { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedById { get; set; }

    public DateTime ModifiedDate { get; set; }

    public int ModifiedById { get; set; }

    public virtual EmployeeMaster? CompletedBy { get; set; }

    public virtual EmployeeMaster CreatedBy { get; set; } = null!;

    public virtual DepartmentMaster Department { get; set; } = null!;

    public virtual EmployeeMaster ModifiedBy { get; set; } = null!;

    public virtual EmployeeMaster Spocemployee { get; set; } = null!;
}
