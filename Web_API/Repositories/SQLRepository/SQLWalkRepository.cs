﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Walk>> getAllAsync()
        {
            return await _appApiDbContext.Walks.Include("Region").Include("Difficulty").ToListAsync();
        }

        public async Task<Walk?> getByIdAsync(Guid id)
        {
            return await _appApiDbContext.Walks.Include("Region").Include("Difficulty").FirstOrDefaultAsync(x => x.Id == id);
            
        }
    }
}
