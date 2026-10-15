
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UberRideBookingSystem.CustemRepos.RideRepos;
using UberRideBookingSystem.CustemRepos.UserRepos;
using UberRideBookingSystem.CustemRepos.VehicleRepos;
using UberRideBookingSystem.Data;
using UberRideBookingSystem.GenericRepos;
using UberRideBookingSystem.UnitOfWoeks;

namespace UberRideBookingSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddDbContext<MyContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("Conn")));

            builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
            builder.Services.AddScoped<IAuthRepo,AuthRepo>();
            builder.Services.AddScoped<IUserRepo,UserRepo>();
            builder.Services.AddScoped<IVehicleRepo,VehicleRepo>();
            builder.Services.AddScoped<IRideRepo,RideRepo>();
            builder.Services.AddAutoMapper(typeof(Program));






            // Add services to the container.







            var key = Encoding.UTF8.GetBytes(
                builder.Configuration["Jwt:Key"]!
            );

            builder.Services.AddAuthentication(op =>
            {
                op.DefaultAuthenticateScheme =
                    JwtBearerDefaults.AuthenticationScheme;

                op.DefaultChallengeScheme =
                    JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(op =>
            {
                op.RequireHttpsMetadata = false;

                op.SaveToken = true;

                op.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,

                    IssuerSigningKey = new SymmetricSecurityKey(key),

                    ValidateIssuer = true,

                    ValidateAudience = true,

                    ValidateLifetime = true,

                    ValidIssuer = builder.Configuration["Jwt:Issuer"],

                    ValidAudience = builder.Configuration["Jwt:Audince"],

                    ClockSkew = TimeSpan.Zero
                };
            });

            builder.Services.AddAuthorization();













            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
