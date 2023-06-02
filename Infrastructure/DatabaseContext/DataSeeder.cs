using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DatabaseContext
{
    public class DataSeeder
    {
        public readonly AppDbContext _dbContext;
        public DataSeeder(AppDbContext dbContext) {
            _dbContext = dbContext;

        }

        public void Run()
        {
            if(AlreadySeeded()) return;

            var defaultUser = new User
            {
                Id = 1,
                Username = "diegodrf",
                PasswordHash = "XXXXXXX"
            };

            _dbContext.Users.Add(defaultUser);

            _dbContext.Profiles.AddRange(
                new()
                {
                    Id = 1,
                    UserName = "Admin",
                    PasswordHash = "XXXXXXX",
                    UserId = defaultUser.Id
                },
                new()
                {
                    Id = 2,
                    UserName = "falcon@gmail.com",
                    PasswordHash = "XXXXXXX",
                    UserId = defaultUser.Id
                },
                new()
                {
                    Id = 3,
                    UserName = "dexter@cartoonnetwork.ca",
                    PasswordHash = "XXXXXXX",
                    UserId = defaultUser.Id
                });

            _dbContext.SaveChanges();
        }
        
        private bool AlreadySeeded()
        {
            _dbContext.Database.EnsureCreated();
            return _dbContext.Profiles.Any();
        }
    }
}
