using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class Crtemplate
{
    public int CrtemplateId { get; set; }

    public int? SupportId { get; set; }

    public int? CategoryId { get; set; }

    public int? CategoryTypId { get; set; }

    public string? TemplateName { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }

    public virtual ICollection<CrtemplateDtl> CrtemplateDtls { get; set; } = new List<CrtemplateDtl>();
}
