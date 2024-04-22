using PizzaSellingStoreApp;

namespace PizzaOrderDataAccessLibrary
{
    public class OrderRepository : IRepository<int, Order>
    {
        readonly Dictionary<int, Order> _orders;

        public OrderRepository()
        {
            _orders = new Dictionary<int, Order>();
        }
        int GenerateId()
        {
            if (_orders.Count == 0)
                return 1;
            int id = _orders.Keys.Max();
            return ++id;
        }
        public Order Add(Order item)
        {
            if(_orders.ContainsKey(item.OrderId))
            {
                return null;
            }
            item.OrderId=GenerateId();
            _orders.Add(item.OrderId, item);
            return item;
        }

        public Order Delete(int key)
        {
            if( _orders.ContainsKey(key))
            {
                var order = _orders[key];
                _orders.Remove(key);
                return order;
            }
            return null;
        }

        public Order Get(int key)
        {
            return _orders.ContainsKey(key) ? _orders[key] : null;
        }

        public List<Order> GetAll()
        {
            if (_orders.Count == 0)
                return null;
            return _orders.Values.ToList();
        }

        public Order Update(Order item)
        {
            if(_orders.ContainsKey((int)item.OrderId))
            {
                _orders[item.OrderId] = item;
                return item;
            }
            return null;
        }
    }
}
