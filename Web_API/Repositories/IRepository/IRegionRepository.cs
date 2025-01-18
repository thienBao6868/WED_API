using Web_API.Data;
using Web_API.Models.Domain;

namespace Web_API.Repositories.IRepository
{
    public interface IRegionRepository
    {
        Task<List<Region>> getAllAsync();
        Task<Region?> getByIdAsync(Guid id);
        Task<Region> createAsync(Region region);
        Task<Region?> updateAsync(Guid id, Region region);
        Task<Region?> deleteAsync(Guid id);
    }
}
