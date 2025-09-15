namespace IT_Portal.Domain.IT_Models;

public partial class CabBooking
{
    public int Id { get; set; }

    public string? RequestNo { get; set; }

    public int FkEmployeeId { get; set; }

    public string? EmployeeNumber { get; set; }

    public int Fkpurpose { get; set; }

    public int? EmpoloyeeLocation { get; set; }

    public string? TypeofTrip { get; set; }

    public string? ServiceType { get; set; }

    public string? FromLocation { get; set; }

    public string? ToLocation { get; set; }

    public int? NumberOfPerson { get; set; }

    public DateTime? FromDateTime { get; set; }

    public DateTime? ToDateTime { get; set; }

    public string? Comments { get; set; }

    public bool IsApprovalReq { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? Status { get; set; }

    public string? CabDetails { get; set; }

    public string? DriverName { get; set; }

    public string? DriverContact { get; set; }

    public string? PendingWithRequest { get; set; }

    public string? CancelComments { get; set; }

    public string? EmpContactNo { get; set; }

    public virtual BookPurposeMaster FkpurposeNavigation { get; set; } = null!;
}
