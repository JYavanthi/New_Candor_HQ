namespace IT_Portal.Domain.IT_Models;

public partial class ReferenceTyp
{
    public int ReferenceTypeId { get; set; }

    public string? ReferenceType { get; set; }

    public bool IsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
