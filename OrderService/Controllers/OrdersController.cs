using MassTransit;
using Microsoft.AspNetCore.Mvc;
using OrderService.Data;
using OrderService.Messaging.Events;
using OrderService.Models;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly OrderDbContext _dbContext;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly HttpClient _httpClient;

        public OrdersController(OrderDbContext dbContext, IPublishEndpoint publishEndpoint, IHttpClientFactory httpClientFactory)
        {
            _dbContext = dbContext;
            _publishEndpoint = publishEndpoint;
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(_dbContext.Orders.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            // Validate UserId by calling UserService
            var response = await _httpClient.GetAsync($"http://localhost:8000/users/{order.UserId}");
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest("Invalid UserId.");
            }

            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();

            // Publish event with product and quantity details
            await _publishEndpoint.Publish(new OrderCreated
            {
                OrderId = order.Id,
                Product = order.Product,
                Quantity = order.Quantity,
                UserId = order.UserId
            });


            return Ok(order);
        }
    }


}
