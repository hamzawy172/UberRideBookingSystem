using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UberRideBookingSystem.Models
{
    public class Ride
    {
        public int Id { get; set; }
        [Required , MaxLength(150)]
        public string PickUpLocation { get; set; }
        [Required , MaxLength(150)]
        public string DropOffLocation { get; set; }
        [Required , Range(20,5000)]
        public decimal Fare { get; set; }
        [Required]
        public string Status { get; set; }

        [Required]
        [ForeignKey(nameof(UserRider))]
        public int ReiderId { get; set; }
        public User UserRider { get; set; }

        [Required]
        [ForeignKey(nameof(UserDriver))]
        public int DriverId { get; set; }
        public User UserDriver { get; set; }


        public Payment Payment { get; set; }
        public Rating Rating { get; set; }
    }
}
