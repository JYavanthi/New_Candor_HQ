using IT_Portal.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.Persistence.Repositories
{
    public class templateRRRRepo
    {
        private readonly MicroLabsDevContext _context;
        templateRRRRepo(MicroLabsDevContext context)
        {
            _context = context;
        }
        public void newMethod()
        {
            var data = _context.VwItassetsDetails.ToListAsync();
        }
    }
}
