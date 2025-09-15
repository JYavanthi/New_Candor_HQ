namespace IT_Portal.Domain.IT_Models;

public partial class GuestHouseMaster
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int? NoOfRoom { get; set; }

    public int? NoOfBed { get; set; }

    public int FkLocation { get; set; }

    public string? Address { get; set; }

    public int? AdminId { get; set; }

    public int? Location { get; set; }

    public bool? ManagerApproval { get; set; }

    public bool? AdminApproval { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual PlantMaster FkLocationNavigation { get; set; } = null!;

    public virtual ICollection<GuestHouseFacility> GuestHouseFacilities { get; set; } = new List<GuestHouseFacility>();

    public virtual ICollection<GuestHousePicture> GuestHousePictures { get; set; } = new List<GuestHousePicture>();
}
