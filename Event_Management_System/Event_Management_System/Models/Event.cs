using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Event_Management_System.Models
{
    public class Event
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int EventId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public int AvailableSeats { get; set; }
        public int TicketPrice { get; set; }
        public ICollection<TicketBooking> TicketBookings { get; set; }

        public Event() { }
    }

}
