using System.Collections;
using Event_Management_System.Models;

namespace Event_Management_System.Repository
{
    public interface ITicketBookingRepository
    {
        public Task<IEnumerable<TicketBooking>> GetAllTicket(string id);
        Task<IEnumerable<Event>> GetAllEvents();
        //Task<IEnumerable> GetAllUser();
        Task<int> AddBooking(TicketBooking ticketBooking);
        public Task<bool> CancelBookingAsync(int bookingId);
        //public  Task<IEnumerable<Event>> SearchEvent(string name);



    }
}
