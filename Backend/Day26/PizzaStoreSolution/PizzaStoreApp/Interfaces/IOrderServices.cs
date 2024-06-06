using PizzaStoreApp.Models.DTOs;

namespace PizzaStoreApp.Interfaces
{
    public interface IOrderServices
    {
        public Task<OrderDTO> AddOrder(OrderDTO orderDTO);
        public Task<IEnumerable<OrderDTO>> GetOrders();
    }
}
