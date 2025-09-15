namespace IT_Portal.Domain.IT_Models;

public partial class TdTravelPaymentDetail
{
    public int Id { get; set; }

    public int ChequeNo { get; set; }

    public DateOnly ChequeDate { get; set; }

    public int ChequeAmount { get; set; }

    public DateOnly ChequeIssuedDate { get; set; }

    public string ChequeIssuedTo { get; set; } = null!;
}
