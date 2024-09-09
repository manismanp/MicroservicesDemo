using MassTransit;
using Microsoft.EntityFrameworkCore;
using OrderService.Data;

namespace OrderService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services
            builder.Services.AddDbContext<OrderDbContext>(options => options.UseInMemoryDatabase("OrdersDb"));
            builder.Services.AddMassTransit(x =>
            {
                x.UsingInMemory((context, cfg) => cfg.ConfigureEndpoints(context));
            });

            builder.Services.AddHttpClient();
            builder.Services.AddMassTransitHostedService();
            builder.Services.AddControllers();

            var app = builder.Build();

            app.MapControllers();
            app.Run();

        }
    }
}
