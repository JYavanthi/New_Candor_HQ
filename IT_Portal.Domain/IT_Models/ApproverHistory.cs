using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class ApproverHistory
{
    public int ItapproverHistoryId { get; set; }

    public DateTime CrhistoryDt { get; set; }

    public int? ItapproverId { get; set; }

    public int PlantId { get; set; }

    public int SupportId { get; set; }

    public int? CategoryId { get; set; }

    public int? ClassificationId { get; set; }

    public string? Approverstage { get; set; }

    public string? Approver1 { get; set; }

    public string? Approver2 { get; set; }

    public string? Approver3 { get; set; }

    public int? Level { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
