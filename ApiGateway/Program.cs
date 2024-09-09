using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace ApiGateway
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            builder.Configuration.AddJsonFile("ocelot.json");

            builder.Services.AddOcelot();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();

            await app.UseOcelot();

            app.Run();
        }
    }
}
