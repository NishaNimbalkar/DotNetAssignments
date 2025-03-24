using AspNetCoreGeneratedDocument;
using Event_Management_System.Context;
using Event_Management_System.Exceptions;
using Event_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static Event_Management_System.Repository.EventRepository;

namespace Event_Management_System.Repository
{
    public class EventRepository : IEventRepository
    {
        readonly EventDBContext _eventDBContext;

        public EventRepository(EventDBContext eventDBContext)
        {
            _eventDBContext = eventDBContext;
        }

        public async Task<int> AddEvent(Event event1)
        {
             await _eventDBContext.Events.AddAsync(event1);
            return await  _eventDBContext.SaveChangesAsync();

        }

        public async Task<int> DeleteEvent(int eventId)
        {
            var getBook =await GetEventById(eventId);
             _eventDBContext.Remove(getBook);
            return await _eventDBContext.SaveChangesAsync();
        }


        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await _eventDBContext.Events.ToListAsync();
        }
       

        public async Task<Event> GetEventById(int id)
        {

            return await _eventDBContext.Events.FirstOrDefaultAsync(b => b.EventId == id);
            if (id == null)
            {

            }
        }

        public async Task<IEnumerable<TicketBooking>> GetTicketBookings()
        {
            return await _eventDBContext.TicketBookings.ToListAsync();
        }

        public async Task<int> UpdateEvent(Event event1)
        {
            var updateE = await GetEventById(event1.EventId);
            if (updateE == null)
            {
                throw new  EventNotFoundException(); 
            }

            
            updateE.EventId = event1.EventId;
            updateE.Name = event1.Name;
            updateE.Location = event1.Location;
            updateE.TicketPrice= event1.TicketPrice;

            _eventDBContext.Events.Update(updateE);
            return await _eventDBContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Event>> SearchEvent(string name)
        {

            return await _eventDBContext.Events.Where(b => b.Name == name)
                .ToListAsync();
        }

    }
}
