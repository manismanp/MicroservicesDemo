using MassTransit;
using OrderService.Messaging.Events;

namespace OrderService.Messaging.Consumers
{
    public class OrderCreatedConsumer : IConsumer<OrderCreated>
    {
        public Task Consume(ConsumeContext<OrderCreated> context)
        {
            Console.WriteLine($"Order Created: {context.Message.OrderId}");
            return Task.CompletedTask;
        }
    }
}
