using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class EmpCategoryMaster
{
    public int Id { get; set; }

    public int Staffcat { get; set; }

    public string? Catstxt { get; set; }

    public string? Catltxt { get; set; }

    public string? CostCenter { get; set; }

    public string? Glno { get; set; }

    public string? Aoemail { get; set; }

    public string? Ofemail { get; set; }

    public string? Bemnth { get; set; }

    public int? Prcday { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
