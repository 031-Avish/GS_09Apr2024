using PizzaSellingStoreApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppBLLibrary
{
    public interface IOrderService
    {
        int AddOrder(Order order);
        Order GetOrderById(int id);
        List<Order> GetAllOrders();
        Order DeleteOrderById(int id);
    }
}
