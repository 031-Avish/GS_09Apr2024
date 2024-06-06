using Microsoft.IdentityModel.Tokens;
using PizzaStoreApp.Interfaces;
using PizzaStoreApp.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace PizzaStoreApp.Services
{
    public class TokenService:ITokenService
    {
        private readonly string _secretKey;
        private readonly SymmetricSecurityKey _hashedKey;

        public TokenService(IConfiguration configuration) { 
            _secretKey= configuration.GetSection("TokenKey").GetSection("JWT").Value.ToString();
            // hash the key
            _hashedKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
        }

        public string GenerateToken(Customer customer)
        {
            string token = string.Empty;
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name , customer.Id.ToString())
            };
            var credentials= new SigningCredentials(_hashedKey, SecurityAlgorithms.HmacSha256);

            var myToken = new JwtSecurityToken(null, null, claims, expires: DateTime.Now.AddDays(3), signingCredentials: credentials);

            token = new JwtSecurityTokenHandler().WriteToken(myToken);
            return token;

        }
    }
}
