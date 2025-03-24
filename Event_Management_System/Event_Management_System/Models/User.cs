using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Event_Management_System.Constants;
using Event_Management_System.Models.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Event_Management_System.Models
{
    public class User : IdentityUser
    {

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        //public Role Role { get; set; }
        public ICollection<TicketBooking> TicketBookings { get; set; }

    }
}
