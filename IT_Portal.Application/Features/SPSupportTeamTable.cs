namespace IT_Portal.Application.Features
{
    public class SPSupportTeamTable
    {
        public string Flag { get; set; }

        public int SupportTeamId { get; set; }

        public int SupportTeamAssgnID { get; set; }

        public string? Email { get; set; }

        public string? FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string? LastName { get; set; }

        public string? ImgUrl { get; set; }

        public string? Designation { get; set; }

        public string? Role { get; set; }

        public int? EmpId { get; set; }

        public bool? IsActive { get; set; }


        //public int GroupId { get; set; }

        public DateTime? Dol { get; set; }

        public DateTime? Dob { get; set; }

        public bool? IsAdmin { get; set; }

        public bool? isSuperAdmin { get; set; }

        public bool? IsApprover { get; set; }

        public bool? IsChangeAnalyst { get; set; }

        public bool? IsSupportEngineer { get; set; }

        public int? PlantId { get; set; }

        public int SupportId { get; set; }

        public int? CategoryId { get; set; }
        public int? CategoryTypID { get; set; }

        public int? ClassificationId { get; set; }

        public string? ApproverstageCR { get; set; }

        public string? ApproverstageR { get; set; }

        public string? ApproverstageC { get; set; }

        public int? Level { get; set; }

        public string? Approverstage2CR { get; set; }

        public string? Approverstage2R { get; set; }

        public string? Approverstage2C { get; set; }

        public int? Level2 { get; set; }

        public string? Approverstage3CR { get; set; }

        public string? Approverstage3R { get; set; }

        public string? Approverstage3C { get; set; }

        public int? Level3 { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }
        public List<int> supportIds { get; set; }
    }


    public class supportTeamCopy
    {
        public int empId { get; set; }
        public int existingEmpId { get; set; }
        public int createdBy { get; set; }
    }
}
