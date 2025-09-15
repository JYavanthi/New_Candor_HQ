namespace IT_Portal.Domain.IT_Models;

public partial class ProdDesignationMaster
{
    public int Id { get; set; }

    public int? Dsgid { get; set; }

    public string? Name { get; set; }

    public int? AtemId { get; set; }

    public bool? Cooff { get; set; }

    public bool? Ot { get; set; }

    public int? Gradeid { get; set; }

    public int? Bandid { get; set; }

    public int? FkParentId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public string? Description { get; set; }
}
