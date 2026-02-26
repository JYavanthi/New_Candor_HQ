using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class GetSlalist
{
    public int Itslaid { get; set; }

    public int? Escalation1 { get; set; }

    public int? Escalation2 { get; set; }

    public int? PlantId { get; set; }

    public int SupportId { get; set; }

    public int? WaitTime { get; set; }

    public int? WaitTimeEscal1 { get; set; }

    public string? WaitTimeUnit { get; set; }

    public string? WaitTimeUnitEscal1 { get; set; }

    public string? WaitTimeUnitEscal2 { get; set; }

    public int? AssignedTo { get; set; }

    public int CategoryId { get; set; }

    public int? CategoryTypId { get; set; }

    public int ClassificationId { get; set; }

    public int? CreatedBy { get; set; }

    public DateOnly? CreatedDt { get; set; }

    public string? CategoryName { get; set; }

    public string? ClassificationName { get; set; }

    public string? CategoryType { get; set; }

    public string? CategoryTypeName { get; set; }
}
