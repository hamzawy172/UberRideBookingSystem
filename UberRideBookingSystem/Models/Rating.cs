using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UberRideBookingSystem.Models
{
    public class Rating
    {
        public int Id { get; set; }
        [Range(1,5)]
        public int Score { get; set; }
        [MaxLength(250)]
        public string Comment { get; set; }

        [ForeignKey(nameof(ride))]
        public int RideId { get; set; }
        public Ride ride { get; set; }



    }
}
