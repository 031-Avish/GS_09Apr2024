using PizzaStoreApp.Models;
using PizzaStoreApp.Models.DTOs;

namespace PizzaStoreApp.Interfaces
{
    public interface IPizzaServices
    {
        Task<IEnumerable<PizzaDTO>> GetPizzasInStock();
        Task<PizzaDTO> AddPizza(PizzaDTO pizzaDTO);
        Task<IEnumerable<PizzaDTO>> GetAllPizzas();
        Task<PizzaDTO> UpdatePizzaStock(int id, int stock);
    }
}
