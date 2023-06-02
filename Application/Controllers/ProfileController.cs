using Entities;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileController(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IEnumerable<Profile>> GetAll()
        {
            return await _profileRepository.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Profile>> GetById(int id)
        {
            var profile = await _profileRepository.GetById(id);
            if (profile is null) { 
                return NotFound();
            }
            return profile;
        }

        [HttpPost]
        public async Task<Profile> Create(Profile profile)
        {
            return await _profileRepository.create(profile);
        }
    }
}
