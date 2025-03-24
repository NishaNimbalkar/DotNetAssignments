using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Event_Management_System.Models;
using Event_Management_System.Context;
using Event_Management_System.Repository;
using Event_Management_System.Serrvice;
using Event_Management_System.AspectOrientedProgramming;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews();
string conn = builder.Configuration.GetConnectionString("LocaldatabaseConnection");
builder.Services.AddDbContext<EventDBContext>(options => options.UseSqlServer(conn));

builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<ITicketBookingRepository, TicketBookingRepository>();
builder.Services.AddScoped<ITicketBookingService, TicketBookingService>();
builder.Services.AddScoped<ExceptionHandlerAttribute>();

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<EventDBContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

// Seed roles and admin user
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await SeedRolesAndAdmin(services);
}

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();  // Ensure authentication middleware is used
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


static async Task SeedRolesAndAdmin(IServiceProvider serviceProvider)
{
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

    string[] roleNames = { "User", "Admin", "Organizer" };

    foreach (var roleName in roleNames)
    {
        if (!await roleManager.RoleExistsAsync(roleName))
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }

   string adminEmail = "admin@example.com";
    string adminPassword = "Admin@123";

    if (await userManager.FindByEmailAsync(adminEmail) == null)
    {
        var adminUser = new User
        {
            UserName = adminEmail,
            Email = adminEmail,
            FirstName = "Admin",
            LastName = "User",
            EmailConfirmed = true
        };

        var createUserResult = await userManager.CreateAsync(adminUser, adminPassword);
        if (createUserResult.Succeeded)
        {
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }

        string organizerEmail = "organizer@gmail.com";
        string organizerPassword = "Organizer@]123";

        if(await userManager.FindByEmailAsync(organizerEmail) == null)
        {
            var organizerUser = new User
            {
                UserName = organizerEmail,
                Email = organizerEmail,
                FirstName = "Event",
                LastName = "Organizer",
                EmailConfirmed = true
            };
            var createOrganizerResult = await userManager.CreateAsync(organizerUser, organizerPassword);
            if (createOrganizerResult.Succeeded)
            {
                await userManager.AddToRoleAsync(organizerUser, "Organizer");
            }
        
    }
}
