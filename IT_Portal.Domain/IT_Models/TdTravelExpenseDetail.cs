namespace IT_Portal.Domain.IT_Models;

public partial class TdTravelExpenseDetail
{
    public int Id { get; set; }

    public DateTime EventDate { get; set; }

    public string Division { get; set; } = null!;

    public string? Name { get; set; }

    public string? HotelName { get; set; }

    public string? Department { get; set; }

    public string TypeOfGuest { get; set; } = null!;

    public int? EmployeeId { get; set; }

    public string? Gender { get; set; }

    public string TypeOfEvent { get; set; } = null!;

    public string VendorName { get; set; } = null!;

    public string VendorCity { get; set; } = null!;

    public string InvoiceNo { get; set; } = null!;

    public DateTime InvoiceDate { get; set; }

    public double? Amount { get; set; }

    public int NoOfPax { get; set; }

    public string? CheckInFavourOf { get; set; }

    public string? Remarks { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public int AccountStatus { get; set; }

    public int? ChequeId { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public int? AccSubmittedReferenceNo { get; set; }

    public string? Supportings { get; set; }
}
