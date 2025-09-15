namespace IT_Portal.Domain.IT_Models;

public partial class EmployeeDocument
{
    public int EmployeeDocumentId { get; set; }

    public int? EmployeeId { get; set; }

    public string? ObjectType { get; set; }

    public int? ObjectId { get; set; }

    public string DocumentType { get; set; } = null!;

    public string FileName { get; set; } = null!;

    public string FilePath { get; set; } = null!;

    public string? Note { get; set; }

    public int CreatedById { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual EmployeeMaster CreatedBy { get; set; } = null!;

    public virtual Employee? Employee { get; set; }
}
