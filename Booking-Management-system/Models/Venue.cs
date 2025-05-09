using System.ComponentModel.DataAnnotations;

namespace Booking_Management_system.Models
{
    public class Venue
    {
        [Key]
        [Display(Name = "Venue Id")]
        public int VENUE_ID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Venue Name")]
        public string VENUE_NAME { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Location")]
        public string LOCATION { get; set; }

        [Required]
        [Display(Name = "Capacity")]
        public int CAPACITY { get; set; }

        [StringLength(500)]
        [Display(Name = "Image URL")]
        public string? IMAGE_URL { get; set; }

        // Navigation Property - A Venue can have multiple Events
        public virtual ICollection<Event> Events { get; set; } = new List<Event>();
    }
}

