namespace InventoryService.Messaging.Events
{
    public class OrderCreated
    {
        public int OrderId { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
    }
}
