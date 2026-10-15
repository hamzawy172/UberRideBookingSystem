using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using UberRideBookingSystem.Data;
using UberRideBookingSystem.Dtos.UserDtos;
using UberRideBookingSystem.GenericRepos;
using UberRideBookingSystem.Models;

namespace UberRideBookingSystem.CustemRepos.UserRepos
{
    public class AuthRepo : GenericRepo<User>, IAuthRepo
    {
        private readonly MyContext c;
        private readonly IConfiguration configuration;
        public AuthRepo(MyContext c , IConfiguration configuration) : base(c)
        {
            this.c = c;
            this.configuration = configuration;
        }

        public async Task<string> Login(LoginDto dto)
        {
            var data = await c.users.Where(a => a.Email == dto.Email).FirstOrDefaultAsync();
            if (data == null)
            {
                throw new Exception();
            }
            if (data.Password == dto.Password)
            {
                return GenerateToken(data);
            }
            return null;

        }

        public async Task<bool> register(User user)
        {
            var exiemail = await c.users.AnyAsync(a => a.Email == user.Email);
            
            if (exiemail)
            {
                return false;
            }

            await c.users.AddAsync(user);
            await c.SaveChangesAsync();
            return true;    
        }

        private string GenerateToken(User user)
        {
            var claimss = new List<Claim>
            {
                new Claim ("Name" , user.FullName),
                new Claim ("Email" , user.Email),

            };
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["jwt:Key"]));
            var SigningCredentialss = new SigningCredentials(key , SecurityAlgorithms.HmacSha256);
                
            var data = new JwtSecurityToken(
                issuer: configuration["jwt:Issuer"],
                audience: configuration["jwt:Audince"],
                expires: DateTime.Now.AddHours(6),
                claims : claimss,
                signingCredentials : SigningCredentialss

            );

            var token = new JwtSecurityTokenHandler().WriteToken(data);
            return token;
        }
    }
}
