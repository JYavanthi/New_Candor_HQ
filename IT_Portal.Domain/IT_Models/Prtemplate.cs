using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class Prtemplate
{
    public int PrtemplateId { get; set; }

    public string? TemplateName { get; set; }

    public bool? IsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
