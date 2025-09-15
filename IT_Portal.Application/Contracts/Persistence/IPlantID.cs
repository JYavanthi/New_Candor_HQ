using IT_Portal.Domain.IT_Models;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface IPlantID
    {
        Task<List<PlantMaster>> GetPlantID();
    }
}
