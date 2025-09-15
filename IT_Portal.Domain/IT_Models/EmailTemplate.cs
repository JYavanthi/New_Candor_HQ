namespace IT_Portal.Domain.IT_Models;

public partial class EmailTemplate
{
    public int Id { get; set; }

    public int? ActionTypeId { get; set; }

    public string ActionType { get; set; } = null!;

    public string FromAddress { get; set; } = null!;

    public string Subject { get; set; } = null!;

    public string Salutation { get; set; } = null!;

    public string Body { get; set; } = null!;

    public string Regards { get; set; } = null!;

    public string? Footer { get; set; }

    public string SmtpServer { get; set; } = null!;

    public string SmtpPort { get; set; } = null!;

    public string SmtpUserName { get; set; } = null!;

    public string SmtpPassword { get; set; } = null!;

    public string? HeaderFrame { get; set; }

    public string? FooterFrame { get; set; }

    public string? Description { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool IsActive { get; set; }
}
