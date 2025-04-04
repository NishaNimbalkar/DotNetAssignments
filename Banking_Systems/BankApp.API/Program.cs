using BankApp.Application;
using BankApp.Infrastrucure;
using BankApp.Identity;
using BankApp.Application.Models.Identity;
using BankApp.Application.Features.AccountFeature.Commands.AddAccount;
using Microsoft.Extensions.DependencyInjection;
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddApplicationServices();
        builder.Services.AddInterfaceServices(builder.Configuration);
        builder.Services.AddIdentityServices(builder.Configuration);
        builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors(x => x
                      .AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader());

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}