using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Domain.IT_Models;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.Persistence.Repositories
{
    public class SupportTeamAssigned : ISupportteamAssigned
    {
        private readonly MicroLabsDevContext _context;

        public SupportTeamAssigned(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<List<SupportTeamAssgn>> getsupportteam()
        {
            var data = await _context.SupportTeamAssgns.ToListAsync();
            return data;
        }
    }
}
