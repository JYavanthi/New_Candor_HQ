namespace IT_Portal.Domain.IT_Models;

public partial class ErrorLog
{
    public int Id { get; set; }

    public string ErrorDetails { get; set; } = null!;

    public string ApplicationName { get; set; } = null!;

    public string PageName { get; set; } = null!;

    public string FunctionName { get; set; } = null!;

    public string LineNumber { get; set; } = null!;

    public string IpAddress { get; set; } = null!;

    public DateTime ErrorDate { get; set; }

    public int? FkEmail { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }
}
