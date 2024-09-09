namespace OrderService.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }

        // Add UserId to link order to a user
        public int UserId { get; set; }
    }


}
