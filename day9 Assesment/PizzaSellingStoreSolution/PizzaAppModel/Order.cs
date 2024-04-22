using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSellingStoreApp
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public string ContactInformation { get; set; }
        public List<Pizza> Pizzas { get; set; }
        public DateTime OrderDateTime { get; set; }
        public bool IsDelivery { get; set; }
        public double TotalCost { get; set; }
    }
}
