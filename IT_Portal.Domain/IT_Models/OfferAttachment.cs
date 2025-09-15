namespace IT_Portal.Domain.IT_Models;

public partial class OfferAttachment
{
    public int OfferAttachmentId { get; set; }

    public int OfferId { get; set; }

    public string FilePath { get; set; } = null!;

    public string FileName { get; set; } = null!;

    public virtual OfferDetail Offer { get; set; } = null!;
}
