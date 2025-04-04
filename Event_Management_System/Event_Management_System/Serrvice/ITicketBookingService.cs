using System.Collections;
using Event_Management_System.Models;

namespace Event_Management_System.Serrvice
{
    public interface ITicketBookingService
    {
        Task<IEnumerable<TicketBooking>> GetAllBookings(string id);
       
      
        //Task<IEnumerable> GetAllUser();
        Task<IEnumerable<Event>> GetAllEvents();
        Task<int> AddBooking(TicketBooking ticketBooking);
        public Task<bool> CancelBookingAsync(int bookingId);
        //public Task<IEnumerable<Event>> SearchEvent(string name);


    }
}
