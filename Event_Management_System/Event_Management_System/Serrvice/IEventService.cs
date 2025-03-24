
using Event_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Event_Management_System.Serrvice
{
    public interface IEventService
    {
        Task<int> AddEvent(Event event1);
        Task<int> DeleteEvent(int eventId);
        Task<IEnumerable<Event>> GetAllEvents();
        Task<Event> GetEventById(int id);
        Task<IEnumerable<TicketBooking>> GetTicketBookings();
        Task<IEnumerable<Event>> SearchEvent(string name);
        Task<int> UpdateEvent(Event event1);
    }
}
