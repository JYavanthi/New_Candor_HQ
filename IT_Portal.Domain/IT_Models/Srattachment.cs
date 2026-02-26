using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class Srattachment
{
    public int AttachId { get; set; }

    public int? Srid { get; set; }

    public string? FileName { get; set; }

    public string? Stage { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
