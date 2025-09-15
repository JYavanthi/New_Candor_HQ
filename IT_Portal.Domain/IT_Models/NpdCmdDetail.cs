namespace IT_Portal.Domain.IT_Models;

public partial class NpdCmdDetail
{
    public int Id { get; set; }

    public string? RequestNo { get; set; }

    public string? SubmitedBy { get; set; }

    public DateTime? SubmitedDate { get; set; }

    public string? Location { get; set; }

    public string? Division { get; set; }

    public string? RemarksCmd { get; set; }

    public string? ApprvrStatus { get; set; }

    public string? PdfreadStatus { get; set; }
}
