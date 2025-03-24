using Event_Management_System.Context;
using Event_Management_System.Models;
using Event_Management_System.Models.Constants;
using Event_Management_System.ModelView;
using Event_Management_System.Serrvice;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Event_Management_System.Controllers
{
    
    [Authorize]
    public class TicketBookingController : Controller
    {
        readonly ITicketBookingService _ticketBookingService;
        readonly UserManager<User> _userManager;

        public User UserId { get; private set; }

        public TicketBookingController(ITicketBookingService ticketBookingService, UserManager<User> userManager)
        {
            _ticketBookingService = ticketBookingService;
            _userManager = userManager;
        }
        [Authorize]

        [HttpGet]
        public async Task<IActionResult> GetAllTicket(string id)
        {
            var user = await _userManager.GetUserAsync(User); 
            if (user == null)
            {
                return RedirectToAction("Login", "Account"); 
            }

            var userTickets = await _ticketBookingService.GetAllTicket(user.Id); 
            return View(userTickets);
        }

        public async Task<IActionResult> AddBooking()
        {
            var userId = await _userManager.GetUserAsync(User);
            ViewData["User"] = userId;

            ViewData["EventId"] = new SelectList(await _ticketBookingService.GetAllEvents(), "EventId", "EventId");
           

            return View();
        }

        [HttpPost]
        public async Task<IActionResult>AddBooking(TicketBooking ticketBooking)
        {
            var userId =await _userManager.GetUserAsync(User);

            ticketBooking.User = userId;
            await _ticketBookingService.AddBooking(ticketBooking);
            return RedirectToAction("GetAllTicket");
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CancelBooking(int bookingId)
        {
            var user = await _userManager.GetUserAsync(User); 
            if (user == null)
            {
                return RedirectToAction("Login", "Account"); 
            }

            var success = await _ticketBookingService.CancelBookingAsync(bookingId);

            if (!success)
            {
                TempData["Error"] = "Booking could not be cancelled.";
            }
            else
            {
                TempData["Success"] = "Booking cancelled successfully.";
            }

            return RedirectToAction("GetAllTicket"); 
        }



        public IActionResult Index()
        {
            return View();
        }
    }
}
