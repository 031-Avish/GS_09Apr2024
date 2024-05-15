namespace PizzaStoreApp.Models.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PizzaId { get; set; }
        public int Quantity { get; set; }
    }
}
