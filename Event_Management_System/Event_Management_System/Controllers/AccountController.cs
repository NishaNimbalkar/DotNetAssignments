
using Event_Management_System.Models;
using Event_Management_System.Models.Constants;
using Event_Management_System.ModelView;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Event_Management_System.Controllers
{
    public class AccountController : Controller
    {
        readonly UserManager<User> _userManager;
        readonly SignInManager<User> _signInManger;
        public AccountController(UserManager<User> manager, SignInManager<User> signInManager)
        {
            _userManager = manager;
            _signInManger = signInManager;

        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Register user)
        {

            if (!ModelState.IsValid)
            {
                return View(user);
            }
            var createdUser = new User { UserName = user.Email, Email = user.Email, FirstName= user.FirstName, LastName=user.LastName, EmailConfirmed=true };
            var result = await _userManager.CreateAsync(createdUser, user.Password);
            if (result.Succeeded)
            {
                
                return RedirectToAction("Login");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(user);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        
        public async Task<IActionResult> Login(LoginView loginModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginModel);
            }

            var user = await _userManager.FindByEmailAsync(loginModel.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(loginModel);
            }

            var result = await _signInManger.PasswordSignInAsync(user.UserName, loginModel.Password, loginModel.RememberMe, false);

            if (result.Succeeded)
            {
                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Contains("Admin"))
                {
                    return RedirectToAction("Index", "Home");  // Redirect Admin to Home Page
                }
                else if (roles.Contains("Organizer"))
                {
                    return RedirectToAction("GetAllEvents", "Event");
                }
                else
                {
                    return RedirectToAction("GetAllEvents", "Event");
                }
            }

            ModelState.AddModelError("", "Invalid email or password.");
            return View(loginModel);
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManger.SignOutAsync();
            //HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }


       

        

    }
}
