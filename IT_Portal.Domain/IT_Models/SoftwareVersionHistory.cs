using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class SoftwareVersionHistory
{
    public int SoftVersionHistoryId { get; set; }

    public int SoftVersionId { get; set; }

    public int SoftwareLibraryId { get; set; }

    public string SoftVersionName { get; set; } = null!;

    public bool? IsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
