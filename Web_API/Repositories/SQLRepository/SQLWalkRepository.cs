using Web_API.Data;
using Web_API.Models.Domain;
using Web_API.Repositories.IRepository;

namespace Web_API.Repositories.SQLRepository
{
    public class SQLWalkRepository : IWalkRepository
    {   
        private readonly AppApiDbContext _appApiDbContext;

        public SQLWalkRepository(AppApiDbContext appApiDbContext)
        {
            this._appApiDbContext = appApiDbContext;
        }


        public async Task<Walk> createAsync(Walk walk)
        {
            await _appApiDbContext.Walks.AddAsync(walk);
            await _appApiDbContext.SaveChangesAsync();
            return walk;

        }
    }
}
