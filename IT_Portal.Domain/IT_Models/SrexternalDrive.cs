namespace IT_Portal.Domain.IT_Models;

public partial class SrexternalDrive
{
    public int Sredid { get; set; }

    public int? Srid { get; set; }

    public int? SupportId { get; set; }

    public string? ReqType { get; set; }

    public string? ForSelf { get; set; }

    public string? Name { get; set; }

    public string? Designation { get; set; }

    public string? EmpCategory { get; set; }

    public string? Role { get; set; }

    public string? Department { get; set; }

    public string? SubDepartment { get; set; }

    public int? PlantId { get; set; }

    public string? ReportingManager { get; set; }

    public string? Hod { get; set; }

    public string? AccessPath { get; set; }

    public string? AccessType { get; set; }

    public string? AccessRequired { get; set; }

    public string? OnwerEmail { get; set; }

    public string? OnwerPlant { get; set; }

    public string? EmpType { get; set; }

    public string? Justification { get; set; }

    public string? Attachment { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public int? ModifiedBy { get; set; }

    public DateOnly? ModifiedDt { get; set; }

    public int? CreatedBy { get; set; }

    public DateOnly? CreatedDt { get; set; }
}
