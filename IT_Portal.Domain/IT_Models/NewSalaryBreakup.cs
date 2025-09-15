namespace IT_Portal.Domain.IT_Models;

public partial class NewSalaryBreakup
{
    public int Id { get; set; }

    public int FkAssessmentId { get; set; }

    public string? FkEmployeeId { get; set; }

    public int? FkEmpId { get; set; }

    public int? FkCalenderId { get; set; }

    public DateOnly? EffectiveDate { get; set; }

    public string? CurrentDesignation { get; set; }

    public string? RevisedDesignation { get; set; }

    public string? Remarks { get; set; }

    public string? Category { get; set; }

    public string? FixedAnnualCtc { get; set; }

    public string? MonthlyGross { get; set; }

    public string? Basic { get; set; }

    public string? Hra { get; set; }

    public string? BooksPeriodicals { get; set; }

    public string? SoftwareAllowance { get; set; }

    public string? Bonus { get; set; }

    public string? Meal { get; set; }

    public string? CarFuel { get; set; }

    public string? DriveReim { get; set; }

    public string? Telephone { get; set; }

    public string? Lta { get; set; }

    public string? PfEmployer { get; set; }

    public string? EsiEmployer { get; set; }

    public string? PfEmployee { get; set; }

    public string? GrossMedicalClaim { get; set; }

    public string? VariablePay { get; set; }

    public string? Dept { get; set; }

    public string? BaseLocation { get; set; }

    public int? OfferLetterFormat { get; set; }

    public string? Gender { get; set; }

    public string? Temp3 { get; set; }

    public string? Temp4 { get; set; }

    public string? Temp5 { get; set; }

    public string? Temp6 { get; set; }

    public string? Temp7 { get; set; }

    public string? Temp8 { get; set; }

    public string? Temp9 { get; set; }

    public string? Temp10 { get; set; }

    public string? Temp11 { get; set; }

    public string? Temp12 { get; set; }

    public string? Temp13 { get; set; }

    public string? Temp14 { get; set; }

    public string? Temp15 { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual AssesmentMaster FkAssessment { get; set; } = null!;
}
