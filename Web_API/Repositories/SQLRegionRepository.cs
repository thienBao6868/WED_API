using Microsoft.EntityFrameworkCore;
using Web_API.Data;
using Web_API.Models.Domain;

namespace Web_API.Repositories
{
    public class SQLRegionRepository: IRegionRepository
    {   
        private readonly AppApiDbContext _appApiDbContext;

        public SQLRegionRepository(AppApiDbContext appApiDbContext)
        {
            this._appApiDbContext = appApiDbContext;
        }
        public async Task<List<Region>> getAllAsync()
        {
            return await _appApiDbContext.Regions.ToListAsync();  
        }

        
    }
}
