using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Persistence.DatabaseContext;
using IT_Portal.Persistence.IT_Models;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.Persistence.Repositories
{
    public class BarchartRepository : IBarchartvalue
    {
        private readonly MicroLabsDevContext _context;

        public BarchartRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<List<VwBarchart>> GetBarchartvalue()
        {
            var data = await _context.VwBarcharts.ToListAsync();

            return data;
        }
    }
}
