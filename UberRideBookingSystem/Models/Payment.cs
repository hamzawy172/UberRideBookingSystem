using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UberRideBookingSystem.Models
{
    public class Payment
    {
        public int Id { get; set; }
        [Range(20,5000)]
        public decimal Amount { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }
        [Required]
        public string Status { get; set; }

        [ForeignKey(nameof(Ride))]
        public int RideId { get; set; }
        public Ride Ride { get; set; }


    }
}
