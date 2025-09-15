using Microsoft.AspNetCore.Http;

namespace IT_Portal.Application.Features
{
    public class crFileRquest
    {
        public int AttachId { get; set; }

        public int? Itcrid { get; set; }

        public string? Stage { get; set; }

        public bool? IsActive { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDt { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDt { get; set; }

        public IFormFile file { get; set; }

    }

    public class issueFileRquest
    {
        public int AttachId { get; set; }

        public int? IssueId { get; set; }

        public string? Stage { get; set; }

        public bool? IsActive { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDt { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDt { get; set; }

        public IFormFile file { get; set; }

    }


    public class srFileRquest
    {
        public int AttachId { get; set; }

        public int? srId { get; set; }

        public string? Stage { get; set; }

        public bool? IsActive { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDt { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDt { get; set; }

        public IFormFile file { get; set; }

    }



    public class prFileRquest
    {
        public int AttachId { get; set; }

        public int? prId { get; set; }
        public int? taskId { get; set; }
        public int? prCheckListId { get; set; }
        public int? prIssueId { get; set; }

        public string? Stage { get; set; }

        public bool? IsActive { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDt { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDt { get; set; }

        public IFormFile file { get; set; }

        public string prTypeFlag { get; set; }

    }
}
