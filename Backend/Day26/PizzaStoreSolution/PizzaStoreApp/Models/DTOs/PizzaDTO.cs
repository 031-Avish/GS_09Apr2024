namespace PizzaStoreApp.Models.DTOs
{
    public class PizzaDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int QuantityInStock { get; set; }
        public int Price { get; set; }
        public string Description { get; set; } 
    }
}
