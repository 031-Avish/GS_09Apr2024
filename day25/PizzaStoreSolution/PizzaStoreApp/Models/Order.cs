using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PizzaStoreApp.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PizzaId { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }
        [ForeignKey("PizzaId")]
        public Pizza? Pizza { get; set; }
    }
}
