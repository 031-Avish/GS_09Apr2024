using PizzaStoreApp.Contexts;
using PizzaStoreApp.Interfaces;
using PizzaStoreApp.Models;
using PizzaStoreApp.Models.DTOs;
using System.Security.Cryptography;
using System.Text;

namespace PizzaStoreApp.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<int, User> _userRepo;
        private readonly IRepository<int, Customer> _customerRepo;
        private readonly ITokenService _tokenServices;
        #region Constructor 
        public UserService(IRepository<int, User> userRepo, IRepository<int, Customer> customerRepo, ITokenService tokenServices)
        {
            _userRepo = userRepo;
            _customerRepo = customerRepo;
            _tokenServices = tokenServices;
        }
        #endregion

        #region Login 
        public async Task<LoginReturnDTO> Login(UserLoginDTO loginDTO)
        {
            var userDB = await _userRepo.GetByKey(loginDTO.UserId);
            if (userDB == null)
            {
                throw new Exception("Invalid username or password");
            }
            HMACSHA512 hMACSHA = new HMACSHA512(userDB.PasswordHashKey);
            var encrypterPass = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));
            bool isPasswordSame = ComparePassword(encrypterPass, userDB.Password);
            if (isPasswordSame)
            {
                var Customer = await _customerRepo.GetByKey(loginDTO.UserId);
                LoginReturnDTO loginReturnDTO = MapCustomerToLoginReturn(Customer);
                return loginReturnDTO;
            }
            throw new Exception("Invalid username or password");
        }

        private LoginReturnDTO MapCustomerToLoginReturn(Customer customer)
        {
            LoginReturnDTO returnDTO = new LoginReturnDTO();
            returnDTO.CustomerId=customer.Id;
            returnDTO.Token = _tokenServices.GenerateToken(customer);
            return returnDTO;
        }
        #endregion

        #region ComparePassword
        private bool ComparePassword(byte[] encrypterPass, byte[] password)
        {
            for (int i = 0; i < encrypterPass.Length; i++)
            {
                if (encrypterPass[i] != password[i])
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region Register
        public async Task<Customer> Register(CustomerUserDTO customerDTO)
        {
            Customer customer= null;
            User user = null;
            try
            {
                // copy all to employee
                customer = customerDTO;
                // map to user 
                user = MapCustomerUserDTOToUser(customerDTO);
                customer = await _customerRepo.Add(customer);
                user.CustomerId = customer.Id;
                user = await _userRepo.Add(user);
                ((CustomerUserDTO)customer).Password = string.Empty;
                return customer;
            }
            catch (Exception) { }
            if (customer != null)
                await RevertCustomerInsert(customer);
            if (user != null && customer == null)
                await RevertUserInsert(user);
            throw new Exception("Not able to register at this moment");
        }
        #endregion

        #region MapCustomerUserDTOToUser
        private User MapCustomerUserDTOToUser(CustomerUserDTO customerDTO)
        {
            User user = new User();
            user.CustomerId = customerDTO.Id;
            HMACSHA512 hMACSHA = new HMACSHA512();
            user.PasswordHashKey = hMACSHA.Key;
            user.Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(customerDTO.Password));
            return user;
        }
        #endregion

        #region
        private async Task RevertUserInsert(User user)
        {
            await _userRepo.DeleteByKey(user.CustomerId);
        }
        #endregion

        #region
        private async Task RevertCustomerInsert(Customer customer)
        {
            await _customerRepo.DeleteByKey(customer.Id);
        }
        #endregion
    }
}