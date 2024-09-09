using InventoryService.Data;
using InventoryService.Messaging.Consumers;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace InventoryService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services
            builder.Services.AddDbContext<InventoryDbContext>(options => options.UseInMemoryDatabase("InventoryDb"));

            builder.Services.AddMassTransit(x =>
            {
                x.AddConsumer<OrderCreatedConsumer>(); // Register the consumer

                x.UsingInMemory((context, cfg) =>
                {
                    cfg.ConfigureEndpoints(context);
                });
            });

            builder.Services.AddMassTransitHostedService();
            builder.Services.AddControllers();

            var app = builder.Build();

            app.MapControllers();
            app.Run();
        }
    }
}
