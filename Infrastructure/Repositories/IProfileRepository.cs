using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IProfileRepository
    {
        Task<IEnumerable<Profile>> GetAll();
        Task<IEnumerable<Profile>> GetAllByUser(User user);
        Task<Profile?> GetById(int id);
        Task<Profile> create(Profile profile);
    }
}
