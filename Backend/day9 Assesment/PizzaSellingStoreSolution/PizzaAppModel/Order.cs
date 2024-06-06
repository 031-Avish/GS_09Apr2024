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
        public string Address {  get; set; }
        public DateTime OrderDateTime { get; set; }
        public bool IsDelivery { get; set; }
        public double TotalCost { get; set; }

        public Order()
        {
            OrderId = 0;
            CustomerName = string.Empty;
            ContactInformation = string.Empty;
            Pizzas = new List<Pizza>();
            //Incredients = new List<Incredients>();
            OrderDateTime = DateTime.Now;
            IsDelivery = false;
            Address=string.Empty;
            TotalCost = 0;
        }
    }
}
