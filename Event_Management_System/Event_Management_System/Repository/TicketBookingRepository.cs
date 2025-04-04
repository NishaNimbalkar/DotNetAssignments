
using System.Collections;
using Event_Management_System.Context;
using Event_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;

namespace Event_Management_System.Repository
{
    public class TicketBookingRepository : ITicketBookingRepository
    {
        readonly EventDBContext _eventDBContext;
        public TicketBookingRepository(EventDBContext eventDBContext)
        {
            _eventDBContext = eventDBContext;
        }


        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await _eventDBContext.Events.ToListAsync();
        }
        public async Task<IEnumerable<TicketBooking>> GetAllBookings(string id)
        {
            //return await _eventDBContext.TicketBookings.Include(u => u.User).Include(e => e.Event).FirstOrDefaultAsync(b => b.UserId == userId);
            var tickets = await _eventDBContext.TicketBookings
                         .Include(t => t.Event)
                         .Where(t => t.UserId == id)
                         .ToListAsync();
            return tickets;
            
        }

        public async Task<int> AddBooking(TicketBooking ticketBooking)
        {
            var eventEntity = await _eventDBContext.Events
        .FirstOrDefaultAsync(e => e.EventId == ticketBooking.EventId);

            if (eventEntity == null || eventEntity.AvailableSeats < ticketBooking.Quantity)
                return 0; 

            
            eventEntity.AvailableSeats -= ticketBooking.Quantity;
           //ticketBooking.TotalPriceOFTicket = eventEntity.TicketPrice *= ticketBooking.Quantity;
            await _eventDBContext.TicketBookings.AddAsync(ticketBooking);
            return await _eventDBContext.SaveChangesAsync();
        }

        public async Task<bool> CancelBookingAsync(int bookingId)
        {
            var booking = await _eventDBContext.TicketBookings
                .Include(b => b.Event) 
                .FirstOrDefaultAsync(b => b.TicketId == bookingId);

            if (booking == null)
                return false; 

            booking.Event.AvailableSeats += booking.Quantity;

            _eventDBContext.TicketBookings.Remove(booking);
            await _eventDBContext.SaveChangesAsync();

            return true;
        }

        
    }
}
