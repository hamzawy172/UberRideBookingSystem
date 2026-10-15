using System.Numerics;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using UberRideBookingSystem.CustemRepos.RideRepos;
using UberRideBookingSystem.Data;
using UberRideBookingSystem.Dtos.RideDtos;
using UberRideBookingSystem.Models;
using UberRideBookingSystem.UnitOfWoeks;

namespace UberRideBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RidesController : ControllerBase
    {
        private readonly IUnitOfWork u;
        private readonly IMapper mapper;
        public RidesController(IUnitOfWork u , IMapper mapper)
        {
            this.u = u;
            this.mapper = mapper;
        }
        [Authorize(Roles ="Rider")]
        [HttpPost]
        public async Task<IActionResult> CreateRide(CreateRideDto dto)
        {
            var rider = await u.User.GetById(dto.ReiderId);
            if (rider == null)
            {
                return BadRequest("Rider not found");
            }
            if (rider.Role != "Rider")
            {
                return BadRequest("User is not rider");
            }

            var data = mapper.Map<Ride>(dto);
            await u.Ride.Add(data);
            await u.Save();

            return Created();
        }
        [Authorize(Roles ="Admin")]
        [HttpGet("GEtAll")]
        public async Task<IActionResult> GetAll()
        {
            var data = await u.Ride.GetAll();

            var map = mapper.Map<List<RideDto>>(data);
            return Ok(map);

        }
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public async Task<IActionResult> GetPaged(int pnumber, int psize)
        {
            var data = await u.Ride.PagedRides(pnumber , psize);
            if (pnumber < 1 || psize < 1)
            {
                return BadRequest("page number and size must be grater than zero");
            }
            var map = mapper.Map<List<RideDto>>(data);
            return Ok(map);
        }
        [Authorize(Roles = "Admin,Rider,Driver")]
        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await u.Ride.GetById(id);
            if (data == null)
            {
                return NotFound("Ride not found");
            }
            var map = mapper.Map<RideDto>(data);
            return Ok(map);
        }
        [Authorize(Roles ="Driver")]
        [HttpPatch("{id}/accept")]
        public async Task<IActionResult> PatchAccept(int id , [FromQuery] int driverid)
        {
            var ride = await u.Ride.GetById(id);
            if (ride == null)
            {
                return NotFound("Ride not found");
            }
            var driver = await u.User.GetById(driverid);
            if (driver == null || driver.Role != "Driver")
            {
                return BadRequest("Invalid Driver");
            }
            if (ride.Status == "Accepted")
            {
                return BadRequest("Ride is already accepted");
            }
            ride.Status = "Accepted";
            u.Ride.Update(ride);
            await u.Save();

            var map = mapper.Map<RideDto>(ride);
            return Ok(map);

        }
        [Authorize(Roles ="Driver")]
        [HttpPatch("{id}/Complete")]
        public async Task<IActionResult> PatchComplete(int id, [FromQuery] int driverid)
        {
            var ride = await u.Ride.GetById(id);
            if (ride == null)
            {
                return BadRequest("Ride not found");
            }
            var driver = await u.User.GetById(driverid);
            if (driver == null || driver.Role != "Driver")
            {
                return BadRequest("Driver invalid");
            }
            if (ride.Status != "Accepted")
            {
                return BadRequest("ride must be accepted to be complete");
            }

            ride.Status = "Complete";
            u.Ride.Update(ride);
            await u.Save();

            var map = mapper.Map<RideDto>(ride);
            return Ok(map);
        }
        [Authorize(Roles ="Rider")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRide(int id)
        {
            var data = await u.Ride.GetById(id);
            if (data == null)
            {
                return NotFound("Ride not found");
            }
            u.Ride.Delete(id);
            await u.Save();

            return NoContent();
        }
        [Authorize(Roles ="Admin")]
        [HttpGet("Search")]
        public async Task<IActionResult> Search(string Pickup)
        {
            var data = await u.Ride.Search(Pickup);
            if (data == null)
            {
                return BadRequest("PickUp not found");
            }

            var map = mapper.Map<List<RideDto>>(data);
            return Ok(map);
        }
    }
}
