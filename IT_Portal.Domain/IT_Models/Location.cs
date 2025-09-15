namespace IT_Portal.Domain.IT_Models;

public partial class Location
{
    public int Locid { get; set; }

    public string? LocationCode { get; set; }

    public string? Locname { get; set; }

    public string? Land1 { get; set; }

    public int? PinCode { get; set; }

    public string? LocationAddress { get; set; }

    public int? LateCount { get; set; }

    public int? PermissionCount { get; set; }

    public int? ApplyAfterLeave { get; set; }

    public int? ApplyAfterOd { get; set; }

    public int? PermissionHrs { get; set; }

    public int? CompOffDays { get; set; }

    public bool? CompOffHod { get; set; }

    public int? PermissionCountYearly { get; set; }

    public int? ForgotSwipe { get; set; }

    public int? MarkAtt { get; set; }

    public int? ApplyAfterPermission { get; set; }

    public int? ApplyAfterForgetSwipe { get; set; }

    public string? Ftotal { get; set; }

    public string? Flate { get; set; }

    public int? Plcount { get; set; }

    public int? PTotalMinutes { get; set; }

    public int? PMinimumMin { get; set; }

    public int? PMaxMin { get; set; }

    public string? PStartTime { get; set; }

    public string? PermissionType { get; set; }

    public int? ApplyBeforePlleave { get; set; }

    public int? CumulativeReport { get; set; }

    public bool? ItemCodeRequestFlag { get; set; }

    public int? AdvancePl { get; set; }

    public int? CombinationLeave { get; set; }

    public int? OndutyRequest { get; set; }

    public string? LocHead { get; set; }

    public string? LocGroup { get; set; }

    public string? LocGrpId { get; set; }
}
