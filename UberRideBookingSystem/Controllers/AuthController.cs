using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UberRideBookingSystem.Dtos.UserDtos;
using UberRideBookingSystem.Models;
using UberRideBookingSystem.UnitOfWoeks;

namespace UberRideBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork u;
        public AuthController(IUnitOfWork u)
        {
            this.u = u;
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var login = await u.Auth.Login(dto);

            if (login == null)
            {
                return Unauthorized("Unauthorized");
            }
            return Ok(login);
        }
        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var data = new User
            {
                Email = dto.Email,
                FullName = dto.FullName,
                Password = dto.Password,
                Phone = dto.Phone,
                Role = dto.Role,
            };

            var reg = await u.Auth.register(data);
            if (!reg)
            {
                return BadRequest();
            }
            return Ok("Registerd");
        }
    }
}
