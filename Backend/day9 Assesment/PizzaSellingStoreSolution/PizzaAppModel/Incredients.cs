using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSellingStoreApp
{
    public class Incredients
    {
        public int IncId {  get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int QuantityAvailable { get; set; } = 0;

        public override string ToString()
        {
            return
            "\nIncredients Id            : " + IncId
          + "\nIncredients Name          : " + Name
          + "\nIncredients Price         : " + Price
          + "\nIncredients Avalilability : " + QuantityAvailable;
        }
    }
}
