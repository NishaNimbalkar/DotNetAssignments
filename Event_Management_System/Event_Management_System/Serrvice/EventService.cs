using Event_Management_System.Exceptions;
using Event_Management_System.Models;
using Event_Management_System.Repository;

namespace Event_Management_System.Serrvice
{
    public class EventService : IEventService
    {
        readonly IEventRepository _eventRepository;
        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<int> AddEvent(Event event1)
        {
            return await _eventRepository.AddEvent(event1);
        }

        public async Task<int> DeleteEvent(int eventId)
        {
            return await _eventRepository.DeleteEvent(eventId);
        }

        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await _eventRepository.GetAllEvents();
        }

        public async Task<Event> GetEventById(int id)
        {
            var eventData= await _eventRepository.GetEventById(id);
            if (eventData == null)
            {
                throw new EventNotFoundException($"Event Not Present with id:{id}");
            }
            else
            {
                return eventData
                    ;
            }
        }

        public async Task<IEnumerable<TicketBooking>> GetTicketBookings()
        {
            return await _eventRepository.GetTicketBookings();
        }

        public async Task<int> UpdateEvent(Event event1)
        {
            return await _eventRepository.UpdateEvent(event1);                                      
        }
        public async Task<IEnumerable<Event>> SearchEvent(string name)
        {
            return await _eventRepository.SearchEvent(name);
        }
    }
}
