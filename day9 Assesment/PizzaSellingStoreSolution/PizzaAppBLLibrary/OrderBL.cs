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
            Order result = _orderRepository.Delete(id); 
            if (result != null)
            {
                return result;
            }
            throw new OrderDoesNotExistException();
        }

        public List<Order> GetAllOrders()
        {
            List<Order> result = _orderRepository.GetAll();
            if (result != null)
            {
                return result;
            }
            throw new OrderDoesNotExistException();
        }

        public Order GetOrderById(int id)
        {
            Order order = _orderRepository.Get(id);
            if (order != null)
            {
                return order;
            }
            throw new OrderDoesNotExistException();
        }

    }
}
