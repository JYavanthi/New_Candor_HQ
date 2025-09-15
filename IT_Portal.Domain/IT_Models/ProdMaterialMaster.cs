namespace IT_Portal.Domain.IT_Models;

public partial class ProdMaterialMaster
{
    public int Id { get; set; }

    public string? PlantCode { get; set; }

    public string? SapCodeNo { get; set; }

    public int? MaterialTypeId { get; set; }

    public string? MaterialType { get; set; }

    public string? MaterialGroupId { get; set; }

    public string? MaterialGroup { get; set; }

    public string? MaterialShortName { get; set; }

    public string? MaterialLongName { get; set; }

    public string? SapCodeExists { get; set; }

    public string? Uom { get; set; }

    public string? StorageLocation { get; set; }

    public string? PgGroup { get; set; }

    public string? HsnCode { get; set; }

    public string? DomesticOrExports { get; set; }

    public string? Market { get; set; }
}
