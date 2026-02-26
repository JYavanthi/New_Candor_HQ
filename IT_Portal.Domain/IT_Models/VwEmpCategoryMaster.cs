using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class VwEmpCategoryMaster
{
    public int Id { get; set; }

    public int StaffCategory { get; set; }

    public string? CategoryShortText { get; set; }

    public string? CategoryLongText { get; set; }

    public string? CostCenter { get; set; }

    public string? Glno { get; set; }

    public string? Aoemail { get; set; }

    public string? OfficeEmail { get; set; }

    public string? BillingMonth { get; set; }

    public int? ProcessDay { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
