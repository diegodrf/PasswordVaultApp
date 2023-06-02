using Entities;
using Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly AppDbContext _dbContext;
        public ProfileRepository(AppDbContext dbContext) { 
            _dbContext = dbContext;
        }
        public async Task<Profile> create(Profile profile)
        {
            await _dbContext.AddAsync(profile);
            await _dbContext.SaveChangesAsync();
            return profile;
        }

        public async Task<IEnumerable<Profile>> GetAll()
        {
            return await _dbContext.Profiles
                .AsNoTracking()
                .ToListAsync();
        }

        public Task<IEnumerable<Profile>> GetAllByUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<Profile?> GetById(int id)
        {
            return await _dbContext.Profiles
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
