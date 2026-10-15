using System.Numerics;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UberRideBookingSystem.Dtos.VehicleDtos;
using UberRideBookingSystem.Models;
using UberRideBookingSystem.UnitOfWoeks;

namespace UberRideBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IUnitOfWork u;
        private readonly IMapper mapper;

        public VehiclesController(IUnitOfWork u , IMapper mapper)
        {
            this.u = u;
            this.mapper = mapper;
        }
        [Authorize(Roles ="Driver")]
        [HttpPost]
        public async Task< IActionResult> AddVehicle(CreateVehicleDto dto)
        {
            var driver = await u.User.GetById(dto.DriverId);
            if (driver == null)
            {
                return BadRequest("Driver not found");
            }
            if (driver.Role != "Driver")
            {
                return BadRequest("UserId not Driver");
            }

            var hasveh = await u.Vehicle.HasVehicle(dto.DriverId);
            if (hasveh)
            {
                return Conflict("Driver Already HAs vehicle");
            }

            var data = mapper.Map<Vehicle>(dto);
            await u.Vehicle.Add(data);
            await u.Save();
            return Created();
        }
        [Authorize(Roles = "Driver")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, UpdateVehicleDto dto)
        {
            var veh = await u.Vehicle.GetById(id);
            if (veh == null)
            {
                return NotFound("Vehicle Not Found");
            }

            mapper.Map(dto, veh);
            u.Vehicle.Update(veh);
            await u.Save();

            return Ok(dto);
        }
        [Authorize(Roles = "Driver")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var data = await u.Vehicle.GetById(id);
            if (data == null)
            {
                return NotFound("vehicle not found");
            }

            u.Vehicle.Delete(id);
            await u.Save();

            return NoContent();
        }
        [Authorize(Roles = "Driver")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await u.Vehicle.GetAll();
            return Ok(data);
        }
    }
}
