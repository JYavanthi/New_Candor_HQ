namespace IT_Portal.Domain.IT_Models;

public partial class Allertbox
{
    public int AllertId { get; set; }

    public DateTime EffectiveFromDate { get; set; }

    public DateTime? EffectiveToDate { get; set; }

    public string Title { get; set; } = null!;

    public string? ShortDescription { get; set; }

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public string? ImageFilePath { get; set; }

    public string? ImageFileName { get; set; }

    public int CreatedById { get; set; }

    public DateTime CreatedDate { get; set; }

    public int ModifiedById { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<AllertApplicable> AllertApplicables { get; set; } = new List<AllertApplicable>();

    public virtual EmployeeMaster CreatedBy { get; set; } = null!;

    public virtual EmployeeMaster ModifiedBy { get; set; } = null!;
}
