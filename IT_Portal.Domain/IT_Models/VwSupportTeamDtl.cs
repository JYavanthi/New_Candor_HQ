using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class VwSupportTeamDtl
{
    public int SupportTeamId { get; set; }

    public string? Email { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public DateTime? Dol { get; set; }

    public DateOnly? Dob { get; set; }

    public int? EmpId { get; set; }

    public bool? IsApprover { get; set; }

    public bool? Ischangeanalyst { get; set; }

    public bool? Isadmin { get; set; }

    public bool? IsSuperAdmin { get; set; }

    public bool? Issupportengineer { get; set; }

    public int? CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public int? ClassificationId { get; set; }

    public string? ClassificationName { get; set; }

    public int? CategoryTypeId { get; set; }

    public string? CategoryType { get; set; }

    public int SupportId { get; set; }

    public string? SupportName { get; set; }

    public int? PlantId { get; set; }

    public string? Code { get; set; }

    public string? Designation { get; set; }

    public string? Role { get; set; }

    public string? ImgUrl { get; set; }

    public bool? IsActive { get; set; }

    public int SupportTeamAssgnId { get; set; }
}
