namespace IT_Portal.Domain.IT_Models;

public partial class TblGalleryDetail
{
    public int Id { get; set; }

    public int? Year { get; set; }

    public string? AlbumName { get; set; }

    public int? AlbumId { get; set; }

    public string? PhotoPath { get; set; }

    public string? Description { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
