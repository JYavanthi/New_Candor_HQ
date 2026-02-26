using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class VwServiceMaster
{
    public int Id { get; set; }

    public string? AppSatus { get; set; }

    public string? AppValue { get; set; }

    public string? ApprovalReamarks { get; set; }

    public string? ApprovalStatus { get; set; }

    public DateTime? ApproveDate { get; set; }

    public int? ApprovedBy { get; set; }

    public DateTime? ApprovedOn { get; set; }

    public string? Attachment { get; set; }

    public string? DetailedDesc { get; set; }

    public string? Justification { get; set; }

    public string? LastApprover { get; set; }

    public string? MachineName { get; set; }

    public string? PendingApprover { get; set; }

    public string? PlantCode { get; set; }

    public string? PurchaseGroup { get; set; }

    public string? Purpose { get; set; }

    public string? RejectedFlag { get; set; }

    public DateTime? RequestDate { get; set; }

    public string? RequestNo { get; set; }

    public string? RequestedBy { get; set; }

    public int? ResolutionBy { get; set; }

    public DateTime? ResolutionOn { get; set; }

    public string? ResolutionReamarks { get; set; }

    public string? ResolutionStatus { get; set; }

    public string? SacCode { get; set; }

    public string? SapCodeExists { get; set; }

    public string? SapCodeNo { get; set; }

    public int? SapCreatedBy { get; set; }

    public DateTime? SapCreationDate { get; set; }

    public string? ServiceCatagory { get; set; }

    public string? ServiceDescription { get; set; }

    public string? ServiceGroup { get; set; }

    public int? SrModuleId { get; set; }

    public string? SrNumber { get; set; }

    public string? StorageLocation { get; set; }

    public string? Uom { get; set; }

    public string? ValuationClass { get; set; }

    public string? WhereUsed { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public string? ModifiedDt { get; set; }
}
