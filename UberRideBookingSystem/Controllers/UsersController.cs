using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using UberRideBookingSystem.Dtos.UserDtos;
using UberRideBookingSystem.UnitOfWoeks;

namespace UberRideBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork u;
        private readonly IMapper mapper;

        public UsersController(IUnitOfWork u , IMapper mapper)
        {
            this.u = u;
            this.mapper = mapper;
        }

        [HttpGet("Drivers")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllDrivers()
        {
            var data = await u.User.GetDrivers();
            var map = mapper.Map<List<UserDto>>(data);

            return Ok(map);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("Search")]
        public async Task<IActionResult> SearchUserByName(string Name)
        {
            var data = await u.User.SearchUSersByName(Name);
            var map = mapper.Map<List<UserDto>>(data);

            return Ok(map);
        }

    }
}
