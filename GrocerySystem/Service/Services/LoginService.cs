using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.Dto;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class LoginService: ILoginService
    {
        private readonly IService<SupplierDto> supplierService;
        private readonly IService<UserDto> userService;
        private readonly IConfiguration configuration;

        public LoginService(IService<SupplierDto> supplierService, IService<UserDto> userService, IConfiguration configuration)
        {
            this.supplierService = supplierService;
            this.userService = userService;
            this.configuration = configuration;
        }

        public dynamic Authenticate(LoginDto item)
        {
            var supplier = supplierService.GetAll().FirstOrDefault(x => x.Email == item.Email && x.Password == item.Password);
            if (supplier != null)
            {
                supplier.Role = "Supplier";
                return supplier;
            }

            var user = userService.GetAll().FirstOrDefault(x => x.Email == item.Email && x.Password == item.Password);
            if (user != null)
            {
                user.Role = "User";
                return user;
            }
            return null;
        }

        public string GenerateToken(dynamic user)
        {
            //הקוד להצפנה במערך של ביטים 
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            //אלגוריתם להצפנה
            var carditional = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            // הקוד להצפנה במערך של ביטים
            // אלגוריתם להצפנה
            Claim[] claims = new Claim[0];
            if (user.Role == "Supplier")
            {
                claims = new[]
                {
                new Claim(ClaimTypes.Name,user.RepresentativeName),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Role,user.Role)
                };
            }
            else if (user.Role == "User")
            {
                claims = new[]
                {
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Role,user.Role)
                };
            }


            Console.WriteLine("🔹 Creating token with claims: " + string.Join(", ", claims.Select(c => $"{c.Type}: {c.Value}")));

            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: carditional
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
