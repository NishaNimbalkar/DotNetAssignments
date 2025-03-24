using Event_Management_System.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Event_Management_System.Context
{
    public class EventDBContext : IdentityDbContext<User>
    {
        public EventDBContext(DbContextOptions<EventDBContext> options) : base(options) { }


        

        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TicketBooking> TicketBookings { get; set; }
    }
}
