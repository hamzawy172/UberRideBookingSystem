using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UberRideBookingSystem.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        [Required , MaxLength(50)]
        public string Model { get; set; }
        [Required , MaxLength(20)]
        public string PlateNumber { get; set; }
        [Required]
        public string Color { get; set; }

        [Required]
        [ForeignKey(nameof(UserDriver))]
        public int DriverId { get; set; }
        public User UserDriver { get; set; }



    }
}
