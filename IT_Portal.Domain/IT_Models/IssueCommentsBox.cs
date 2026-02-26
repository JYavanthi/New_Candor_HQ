using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class IssueCommentsBox
{
    public int Id { get; set; }

    public int? IssueId { get; set; }

    public string? TextChat { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }
}
