using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class VwCrfollowup
{
    public int CrfollowupId { get; set; }

    public int Itcrid { get; set; }

    public DateTime? FollowupDt { get; set; }

    public int? FollowupToPerson { get; set; }

    public string FollowupComments { get; set; } = null!;

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
