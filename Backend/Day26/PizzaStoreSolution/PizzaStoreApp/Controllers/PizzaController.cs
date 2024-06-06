using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaStoreApp.Interfaces;
using PizzaStoreApp.Models;
using PizzaStoreApp.Models.DTOs;

namespace PizzaStoreApp.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaServices _pizzaService;

        #region Constructor
        public PizzaController(IPizzaServices pizzaService)
        {
            _pizzaService = pizzaService;
        }
        #endregion

        #region GetPizzaInStock

        [Authorize]
        [Route("GetPizzasInStock")]
        [HttpGet]
        [ProducesResponseType(typeof(PizzaDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderDTO>> Get()
        {
            try
            {
                var result = await _pizzaService.GetPizzasInStock();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorModel(StatusCodes.Status404NotFound, ex.Message));
            }
        }

        #endregion

        #region AddPizza

        [Authorize]
        [Route("AddPizza")]
        [HttpPost]
        [ProducesResponseType(typeof(PizzaDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<PizzaDTO>> Add(AddPizzaDTO addPizzaDTO)
        {
            try
            {
                var result = await _pizzaService.AddPizza(addPizzaDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorModel(StatusCodes.Status400BadRequest, ex.Message));
            }
        }
        #endregion

        #region UpdateStock
        [Authorize]
        [Route("UpdateStock")]
        [HttpPut]
        [ProducesResponseType(typeof(PizzaDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(PizzaDTO), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PizzaDTO>> Update(UpdatePizzaDTO updatePizzaDTO)
        {
            try
            {
                var result = await _pizzaService.UpdatePizzaStock(updatePizzaDTO.Id, updatePizzaDTO.Stock);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorModel(StatusCodes.Status404NotFound, ex.Message));
            }
        }
        #endregion

        #region GetAllPizza
        [Authorize]
        [Route("GetAllPizza")]
        [HttpGet]
        [ProducesResponseType(typeof(PizzaDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PizzaDTO>> GetAll()
        {
            try
            {
                var result = await _pizzaService.GetAllPizzas();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorModel(StatusCodes.Status404NotFound, ex.Message));
            }
        }
        #endregion

    }
}
