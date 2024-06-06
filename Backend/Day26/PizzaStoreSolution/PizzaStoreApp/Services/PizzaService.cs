using PizzaStoreApp.Interfaces;
using PizzaStoreApp.Models.DTOs;
using PizzaStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaStoreApp.Services
{
    public class PizzaService : IPizzaServices
    {
        private readonly IRepository<int, Pizza> _repository;

        public PizzaService(IRepository<int, Pizza> repository)
        {
            _repository = repository;
        }

        #region AddPizza
        public async Task<AddPizzaDTO> AddPizza(AddPizzaDTO addPizzaDTO)
        {
            var pizza = MapPizzaDTOToPizza(addPizzaDTO);
            pizza = await _repository.Add(pizza);
            if (pizza == null)
            {
                throw new Exception("Not able to add Pizza");
            }
            return addPizzaDTO;
        }
        #endregion

        #region
        private Pizza MapPizzaDTOToPizza(AddPizzaDTO addPizzaDTO)
        {
            Pizza pizza = new Pizza()
            {
                Name = addPizzaDTO.Name,
                QuantityInStock = addPizzaDTO.QuantityInStock,
                Price = addPizzaDTO.Price,
                Description = addPizzaDTO.Description,
            };
            return pizza;
        }
        #endregion

        #region GetAllPizzas
        public async Task<IEnumerable<PizzaDTO>> GetAllPizzas()
        {
            var pizzas = await _repository.GetAll();
            if (!pizzas.Any())
            {
                throw new Exception("No Pizza Present");
            }
            IList<PizzaDTO> pizzaDTOs = new List<PizzaDTO>();
            foreach (Pizza pizza in pizzas)
            {
                pizzaDTOs.Add(MapPizzaToPizzaDTO(pizza));
            }
            return pizzaDTOs;
        }
        #endregion

        #region MapPizzaToPizzaDTO
        private PizzaDTO MapPizzaToPizzaDTO(Pizza pizza)
        {
            PizzaDTO pizzaDTO = new PizzaDTO()
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Price = pizza.Price,
                QuantityInStock = pizza.QuantityInStock,
                Description = pizza.Description
            };
            return pizzaDTO;
        }
        #endregion

        #region UpdatePizzaStock
        public async Task<PizzaDTO> UpdatePizzaStock(int id, int stock)
        {
            var pizza = await _repository.GetByKey(id);
            if (pizza == null)
                throw new Exception("No such Pizza Found");
            pizza.QuantityInStock = stock;
            pizza = await _repository.Update(pizza);
            return MapPizzaToPizzaDTO(pizza);
        }
        #endregion

        #region GetPizzasInStock
        public async Task<IEnumerable<PizzaDTO>> GetPizzasInStock()
        {
            var pizzas = (await _repository.GetAll()).Where(p => p.QuantityInStock > 0);
            if (!pizzas.Any())
            {
                throw new Exception("No Pizza Present");
            }
            IList<PizzaDTO> pizzaDTOs = new List<PizzaDTO>();
            foreach (Pizza pizza in pizzas)
            {
                pizzaDTOs.Add(MapPizzaToPizzaDTO(pizza));
            }
            return pizzaDTOs;
        }
        #endregion
    }
}
