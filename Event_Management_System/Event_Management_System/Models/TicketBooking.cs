using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Event_Management_System.Models.Constants;

namespace Event_Management_System.Models
{
    public class TicketBooking
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int TicketId { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public int EventId { get; set; }
        public virtual Event Event { get; set; }
        public int Quantity { get; set; }
        [Required]
        public DateTime BookingDate { get; set; } = DateTime.Now;
        //public string Status { get; set; }
        //public int TotalPriceOFTicket { get; set; }
    }

}
