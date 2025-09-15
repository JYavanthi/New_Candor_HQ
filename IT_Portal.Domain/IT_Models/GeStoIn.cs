namespace IT_Portal.Domain.IT_Models;

public partial class GeStoIn
{
    public int Id { get; set; }

    public int FkgateNoId { get; set; }

    public string? GoNumber { get; set; }

    public string? FromLocation { get; set; }

    public string? DestPlantId { get; set; }

    public string? SendingPerson { get; set; }

    public string? SendingDepartment { get; set; }

    public TimeOnly? ExptOutTime { get; set; }

    public string? DcNo { get; set; }

    public DateOnly? DcDate { get; set; }

    public string? Fy { get; set; }

    public TimeOnly? InwardTime { get; set; }

    public string? ExerciseNo { get; set; }

    public DateOnly? ExerciseDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? InDate { get; set; }

    public string? VehicleNo { get; set; }

    public virtual LocationGateMaster FkgateNo { get; set; } = null!;

    public virtual ICollection<GeStoMaterialIn> GeStoMaterialIns { get; set; } = new List<GeStoMaterialIn>();
}
