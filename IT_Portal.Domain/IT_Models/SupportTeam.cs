using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class SupportTeam
{
    public int SupportTeamId { get; set; }

    public string? Email { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? ImgUrl { get; set; }

    public string? Designation { get; set; }

    public string? Role { get; set; }

    public int? EmpId { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? Dol { get; set; }

    public DateOnly? Dob { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual ICollection<Approver> ApproverApprover1Navigations { get; set; } = new List<Approver>();

    public virtual ICollection<Approver> ApproverApprover2Navigations { get; set; } = new List<Approver>();

    public virtual ICollection<Approver> ApproverApprover3Navigations { get; set; } = new List<Approver>();
}
