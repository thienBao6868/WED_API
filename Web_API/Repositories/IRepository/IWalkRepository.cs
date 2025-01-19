using Web_API.Models.Domain;

namespace Web_API.Repositories.IRepository
{
    public interface IWalkRepository
    {   
        Task<Walk> createAsync(Walk walk);
        Task<List<Walk>> getAllAsync();
        Task<Walk?> getByIdAsync(Guid id);
    }
}
