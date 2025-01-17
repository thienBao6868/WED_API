using Web_API.Data;
using Web_API.Models.Domain;

namespace Web_API.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>>getAllAsync();
    }
}
