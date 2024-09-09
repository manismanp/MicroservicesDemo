using InventoryService.Data;
using InventoryService.Messaging.Events;
using MassTransit;

namespace InventoryService.Messaging.Consumers
{
    public class OrderCreatedConsumer : IConsumer<OrderCreated>
    {
        private readonly InventoryDbContext _dbContext;

        public OrderCreatedConsumer(InventoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Consume(ConsumeContext<OrderCreated> context)
        {
            var message = context.Message;

            // Find the product in the inventory based on the product name in the order
            var inventoryItem = _dbContext.InventoryItems.FirstOrDefault(item => item.Name == message.Product);

            if (inventoryItem != null && inventoryItem.Stock >= message.Quantity)
            {
                // Reduce the stock by the quantity ordered
                inventoryItem.Stock -= message.Quantity;
                await _dbContext.SaveChangesAsync();
                Console.WriteLine($"Reduced stock for {message.Product}. New stock: {inventoryItem.Stock}");
            }
            else
            {
                // Handle insufficient stock or product not found
                Console.WriteLine("Insufficient stock or item not found.");
            }
        }
    }


}
