using Web_API.Models.Domain;

namespace Web_API.Repositories.IRepository
{
    public interface IWalkRepository
    {   
        Task<Walk> createAsync(Walk walk);
        Task<List<Walk>> getAllAsync();
        Task<Walk?> getByIdAsync(Guid id);
        Task<Walk?> updateAsync(Guid id, Walk walk);

        Task<Walk?> deleteAsync(Guid id);
    }
}
