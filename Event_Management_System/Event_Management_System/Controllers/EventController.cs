using Event_Management_System.AspectOrientedProgramming;
using Event_Management_System.Models;
using Event_Management_System.Serrvice;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Event_Management_System.Controllers
{
    [ServiceFilter(typeof(ExceptionHandlerAttribute))]

    //[Authorize(Roles ="Organizer,User")]
    public class EventController : Controller
    {
        public IEventService _eventService;
         public EventController(IEventService eventService)
        {
            _eventService= eventService;
        }
        public async Task<IActionResult> GetTicketBookings()
        {
            return View(await _eventService.GetTicketBookings());

        }
        
        public async Task<IActionResult> AddEvent()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEvent(Event event1)
        {
            int result = await _eventService.AddEvent(event1);

            if (!ModelState.IsValid)
            {
                if (result > 0)
                {
                    TempData["Msg"] = "Event Added Successfully";
                    return RedirectToAction("GetAllEvents");

                }
                else
                {
                    TempData["msg1"] = "Event Addition Failed";
                    return View(event1);

                }
            }
            else
            {
                return View(event1);
            }

            //await _eventService.AddEvent(event1);
            //return RedirectToAction("GetAllEvents");
        }
        public async Task<IActionResult> GetAllEvents()
        {
            //await _eventService.GetAllEvents();
            return View(await _eventService.GetAllEvents());
        }
        public async Task<IActionResult>GetEventById(int Id)
        {
            try
            {
                var result = await _eventService.GetEventById(Id);
                return View(result);
            
             }
            catch (Exception ex)
            {
                return Content(ex.Message);
    }
}
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var deleteE = await _eventService.GetEventById(id);
            return View(deleteE);


        }
        [HttpPost]
        public async Task<IActionResult> DeleteEvent(Event event1)
        {
             await _eventService.DeleteEvent(event1.EventId);
            return RedirectToAction("GetAllEvents");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateEvent(int id)
        {
            var result = await _eventService.GetEventById(id);
            return View(result);

            

        }
        [HttpPost]
        public async Task<IActionResult> UpdateEvent(Event events)
        {
           var result= await _eventService.UpdateEvent(events);
            if (!ModelState.IsValid)
            {
                if (result > 0)
                {
                    TempData["Msg"] = "Event Updated Successfully";
                    return RedirectToAction("GetAllEvents");

                }
                else
                {
                    TempData["msg1"] = "Event Updation Failed";
                    return View(events);

                }
            }
            else
            {
                return View(events);
            }


        }

        public async Task<IActionResult>SearchEvent(string name)
        {
            var search = await _eventService.SearchEvent(name);
            return View(search);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
