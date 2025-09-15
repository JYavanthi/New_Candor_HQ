using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Domain.IT_Models;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.Persistence.Repositories
{
    public class PlantidRepository : IPlantID
    {
        private readonly MicroLabsDevContext _context;

        public PlantidRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<List<PlantMaster>> GetPlantID()
        {
            try
            {
                var plants = await _context.PlantMasters
           .AsNoTracking()
           .ToListAsync();

                var sortedPlants = plants
                    .OrderBy(loc =>
                    {
                        string numericPart = loc.Code.Replace("ML", "");
                        int parsedCode;

                        if (int.TryParse(numericPart, out parsedCode))
                        {
                            return parsedCode;
                        }
                        else
                        {
                            return int.MaxValue;
                        }
                    })
                    .ToList();
                return sortedPlants;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
