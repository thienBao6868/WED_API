using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Web_API.Data;
using Web_API.Models.Domain;
using Web_API.Models.DTO.RequestDTO;
using Web_API.Repositories.IRepository;

namespace Web_API.Repositories.SQLRepository
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly AppApiDbContext _appApiDbContext;

        public SQLRegionRepository(AppApiDbContext appApiDbContext)
        {
            _appApiDbContext = appApiDbContext;
        }



        public async Task<List<Region>> getAllAsync()
        {
            return await _appApiDbContext.Regions.ToListAsync();
        }


        public async Task<Region?> getByIdAsync(Guid id)
        {
            return await _appApiDbContext.Regions.FirstOrDefaultAsync(X => X.Id == id);
        }

        public async Task<Region> createAsync(Region region)
        {
            await _appApiDbContext.Regions.AddAsync(region);
            await _appApiDbContext.SaveChangesAsync();
            return region;

        }

        public async Task<Region?> updateAsync(Guid id, Region region)
        {
            var existingRegion = await _appApiDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null) return null;

            existingRegion.Name = region.Name;
            existingRegion.Code = region.Code;
            existingRegion.RegionImageUrl = region.RegionImageUrl;

            await _appApiDbContext.SaveChangesAsync();

            return existingRegion;
        }

        public async Task<Region?> deleteAsync(Guid id)
        {
            var existingRegion = await _appApiDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null) return null;

            _appApiDbContext.Regions.Remove(existingRegion);
            await _appApiDbContext.SaveChangesAsync();

            return existingRegion;


        }
    }
}
