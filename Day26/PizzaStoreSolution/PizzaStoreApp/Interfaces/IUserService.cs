using PizzaStoreApp.Models;
using PizzaStoreApp.Models.DTOs;

namespace PizzaStoreApp.Interfaces
{
    public interface IUserService
    {
        public Task<LoginReturnDTO> Login(UserLoginDTO loginDTO);
        public Task<Customer> Register(CustomerUserDTO customerUserDTO);
    }
}
