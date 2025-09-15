using IT_Portal.Domain.IT_Models;

namespace IT_Portal.Application.Features
{
    public class user
    {
        public bool isValid { get; set; }
        public string? validationMessage { get; set; }
        public string? Role { get; set; }
        public Employee? empData { get; set; }
        public SupportTeam? supportTeamData { get; set; }
        public List<SupportTeamAssgn>? supportTeamAssignList { get; set; }
    }
}
