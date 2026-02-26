using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class VwCrtaskEmail
{
    public int Itcrid { get; set; }

    public string Crcode { get; set; } = null!;

    public int SupportId { get; set; }

    public string Crowner { get; set; } = null!;

    public string? Croemail { get; set; }

    public string? Crodesignation { get; set; }

    public string? Crorole { get; set; }

    public int? Croempid { get; set; }

    public string Crinitiator { get; set; } = null!;

    public string? Criemail { get; set; }

    public string? Cridesignation { get; set; }

    public string? Crirole { get; set; }

    public int? Criempid { get; set; }

    public string Crrequestor { get; set; } = null!;

    public string? Crremail { get; set; }

    public string? Crrdesignation { get; set; }

    public string? Crrrole { get; set; }

    public int? Crrempid { get; set; }

    public string? ChangeDesc { get; set; }

    public int ItcategoryId { get; set; }

    public string? CategoryName { get; set; }

    public int ItclassificationId { get; set; }

    public int? Plantcode { get; set; }

    public string? ClassificationName { get; set; }

    public string? Crdate { get; set; }

    public string? Stage { get; set; }

    public string? Status { get; set; }

    public int? ApprovedBy { get; set; }

    public int TaskId { get; set; }

    public string? TaskDesc { get; set; }

    public int? AssignedTo { get; set; }

    public string AssignedToName { get; set; } = null!;

    public string? AssgnEmail { get; set; }

    public string? AssgnDesignation { get; set; }

    public string? AssgnRole { get; set; }

    public int? AssgnEmpid { get; set; }

    public int? ForwardedTo { get; set; }

    public string ForwardToName { get; set; } = null!;

    public string? ForwardToEmail { get; set; }

    public string? ForwardToDesignation { get; set; }

    public string? ForwardToRole { get; set; }

    public int? ForwardToEmpid { get; set; }

    public string? Estatus { get; set; }

    public string? PickedDt { get; set; }

    public string? PickedStatus { get; set; }

    public string? AssignedDt { get; set; }
}
