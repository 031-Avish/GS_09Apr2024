using PizzaStoreApp.Interfaces;
using PizzaStoreApp.Models.DTOs;
using PizzaStoreApp.Models;

namespace PizzaStoreApp.Services
{
    public class OrderService : IOrderServices
    {
        private readonly IRepository<int, Order> _repository;

        public OrderService(IRepository<int, Order> repository)
        {
            _repository = repository;
        }
        public async Task<OrderDTO> AddOrder(OrderDTO orderDTO)
        {
            var order = MapOrderDTOToOrder(orderDTO);
            // we have to check pizza is availalable or not and more things 
            // reduce quantity etc.... 
            order = await _repository.Add(order);
            if (order == null)
            {
                throw new Exception("Not able to place order");
            }
            return orderDTO;
        }

        private Order MapOrderDTOToOrder(OrderDTO orderDTO)
        {
            Order order = new Order()
            {
                Id = orderDTO.Id,
                UserId = orderDTO.UserId,
                PizzaId = orderDTO.PizzaId,
                Quantity = orderDTO.Quantity,
            };
            return order;
        }

        public async Task<IEnumerable<OrderDTO>> GetOrders()
        {
            var orders = await _repository.GetAll();
            if (orders == null)
             {
                throw new Exception("No Such Order Present");
             }
            IList<OrderDTO> orderDTOs = new List<OrderDTO>();
            foreach (Order order in orders)
            {
                    orderDTOs.Add(MapOrderToOrderDTO(order));
            }
            return orderDTOs;
        }
        private OrderDTO MapOrderToOrderDTO(Order order)
        {
            OrderDTO orderDTO = new OrderDTO()
            {
                Id = order.Id,
                UserId = order.UserId,
                PizzaId = order.PizzaId,
                Quantity = order.Quantity
            };
            return orderDTO;
        }
    }
}
