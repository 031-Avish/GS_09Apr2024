namespace PizzaSellingStoreApp
{
    public class Pizza
    {
        public int PizzaId { get; set; }
        public string Name { get; set; }
        public List<int> incredients { get; set; }
        public Dictionary<string, double> PriceAccToSize { get; set; }
        public bool IsAvailable { get; set; }

        public Pizza()
        {
            PizzaId = 0;
            Name = string.Empty;
            incredients = new List<int>();
            PriceAccToSize = new Dictionary<string, double>();
            IsAvailable = true;
        }


    }
}
