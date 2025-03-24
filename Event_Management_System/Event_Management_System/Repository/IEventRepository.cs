using System.Collections;
using Event_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Event_Management_System.Repository
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllEvents();
        Task<IEnumerable<TicketBooking>> GetTicketBookings();
        Task<int> AddEvent(Event event1);
        Task<Event> GetEventById(int id);
        Task<int> DeleteEvent(int eventId);
        Task<int> UpdateEvent(Event event1);

        Task<IEnumerable<Event>> SearchEvent(string name);

    }
}
