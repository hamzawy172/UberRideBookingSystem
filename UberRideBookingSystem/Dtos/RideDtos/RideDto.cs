using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UberRideBookingSystem.Models;

namespace UberRideBookingSystem.Dtos.RideDtos
{
    public class RideDto
    {
        public int Id { get; set; }
        [Required, MaxLength(150)]
        public string PickUpLocation { get; set; }
        [Required, MaxLength(150)]
        public string DropOffLocation { get; set; }
        [Required, Range(20, 5000)]
        public decimal Fare { get; set; }
        public string Status { get; set; }
        [Required]
        public int ReiderId { get; set; }
        [Required]
        public int DriverId { get; set; }

    }
}
