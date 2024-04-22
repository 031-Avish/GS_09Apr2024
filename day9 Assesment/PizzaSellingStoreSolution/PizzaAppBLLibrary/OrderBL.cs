using PizzaOrderDataAccessLibrary;
using PizzaSellingStoreApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppBLLibrary
{
    public class OrderBL : IOrderService
    {
        readonly IRepository<int, Order> _orderRepository;
        public OrderBL()
        {
            _orderRepository = new OrderRepository();
        }
        public int AddOrder(Order order)
        {
            var result=_orderRepository.Add(order);
            if (result != null)
            {
                return result.OrderId;
            }
            throw new DuplicateOrderException();
        }

        public Order DeleteOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public Order GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public Order UpdateOrderById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
