using MassTransit;
using Microsoft.EntityFrameworkCore;
using UserService.Data;

namespace UserService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services
            builder.Services.AddDbContext<UserDbContext>(options => options.UseInMemoryDatabase("UsersDb"));
            builder.Services.AddMassTransit(x =>
            {
                x.UsingInMemory((context, cfg) => cfg.ConfigureEndpoints(context));
            });
            builder.Services.AddMassTransitHostedService();
            builder.Services.AddControllers();

            var app = builder.Build();

            app.MapControllers();
            app.Run();

        }
    }
}
