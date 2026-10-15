using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UberRideBookingSystem.Dtos.VehicleDtos
{
    public class CreateVehicleDto
    {
        [Required, MaxLength(50)]
        public string Model { get; set; }
        [Required, MaxLength(20)]
        public string PlateNumber { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public int DriverId { get; set; }
    }
}
