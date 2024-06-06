using System.ComponentModel.DataAnnotations;

namespace PizzaStoreApp.Models
{
    public class Pizza
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int QuantityInStock { get; set; }
        public int Price { get; set; }

    }
}
