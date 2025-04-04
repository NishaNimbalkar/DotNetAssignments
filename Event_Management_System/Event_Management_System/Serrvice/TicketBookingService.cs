using System.Collections;
using Event_Management_System.Models;
using Event_Management_System.Repository;
using Microsoft.EntityFrameworkCore;

namespace Event_Management_System.Serrvice
{
    public class TicketBookingService : ITicketBookingService
    {
        readonly ITicketBookingRepository _ticketBookingRepository;

        public TicketBookingService(ITicketBookingRepository ticketBookingRepository)
        {
            _ticketBookingRepository = ticketBookingRepository;
        }

       

        //public async Task<IEnumerable> GetAllUser()
        //{
        //    return await _ticketBookingRepository.GetAllUser();
        //}

       
       

        public async Task<int> AddBooking(TicketBooking ticketBooking)
        {
            return await _ticketBookingRepository.AddBooking(ticketBooking);
        }

        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await _ticketBookingRepository.GetAllEvents();
        }

       
        public async Task<bool> CancelBookingAsync(int bookingId)
        {
            return await _ticketBookingRepository.CancelBookingAsync(bookingId);
        }

        public async Task<IEnumerable<TicketBooking>> GetAllBookings(string id)
        {
            return await _ticketBookingRepository.GetAllBookings(id);
        }
    }
}
