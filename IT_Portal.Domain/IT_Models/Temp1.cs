namespace IT_Portal.Domain.IT_Models;

public partial class Temp1
{
    public int Id { get; set; }

    public int? FkPlantId { get; set; }

    public int? FkEmpId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }
}
