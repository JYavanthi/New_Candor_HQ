using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features.SystemLandscapeData;
using IT_Portal.Domain.IT_Models;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.Persistence.Repositories
{
    public class SystemLandscapeRepository : ISystemLandscape
    {
        private readonly MicroLabsDevContext _context;

        public SystemLandscapeRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<List<SysLandscape>> GetLandscapes(CommonCR getObj)
        {
            var data = await _context.SysLandscapes.Where(
                x => x.CategoryId == getObj.CategroyId
            && x.SupportId == getObj.SupportId
            && x.ClassificationId == getObj.ClassificationId)
                .ToListAsync();


            return data;
        }
    }
}
