namespace IT_Portal.Domain.IT_Models;

public partial class Npdmarketing
{
    public int Id { get; set; }

    public string Npdnumber { get; set; } = null!;

    public string ResponsibleEmployeeId { get; set; } = null!;

    public string Status { get; set; } = null!;

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? GenericName { get; set; }

    public int? ProposedDivision { get; set; }

    public string? TherapeuticArea { get; set; }

    public string? Indication { get; set; }

    public string? RegulatoryStatus { get; set; }

    public string? ProposedBrandName { get; set; }

    public string? BrandNameRegistrationStatus { get; set; }

    public string? BrandNameApplicationNumber { get; set; }

    public string? DosageStrength { get; set; }

    public string? ReleaseTechnology { get; set; }

    public string? DosageForm { get; set; }

    public string? DosageDetails { get; set; }

    public string? ProposedPackaging { get; set; }

    public string? SalePackUnitPackSize { get; set; }

    public string? SalePackUnitsPerCarton { get; set; }

    public string? SalePackUnitsPerShipper { get; set; }

    public string? Uspproduct { get; set; }

    public string? Usppakaging { get; set; }

    public string? UspotherDevelopmentRequired { get; set; }

    public string? ProposedMlpriceSku { get; set; }

    public string? ProposedMlpricePackSize { get; set; }

    public string? ProposedMlpriceMrpperUnit { get; set; }

    public string? ProposedMlpriceComesUnderNppa { get; set; }

    public string? OtherReleaseTechnology { get; set; }

    public string? OtherDosageForm { get; set; }

    public string? OtherProposedPackaging { get; set; }

    public string? Attachments { get; set; }
}
