using BlazorDAL.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBLL.Managers
{
    public class AuthManager
    {
        Manager mgr;
        public AuthManager(Manager mgr)
        {
            this.mgr = mgr;
        }
        public async Task<Result> LoginUser(AccountDto searchAccount)
        {
            var account = mgr.Db.FirstOrDefault<AccountDto>("SELECT * FROM \"Account\" Where \"Username\" =@0 AND \"Password\" = @1", searchAccount.Username, ToSha256(searchAccount.Password));

            if (account == null)
            {
                return new Result
                {
                    isSuccess = 0,
                    msg = "Kullanıcı adı veya şifre yanlış"
                };
            }
            var key = Encoding.ASCII.GetBytes("qweqewqeqwe123123123qwefdsagagsa");
            var tokenHandler = new JwtSecurityTokenHandler();
            var expires = DateTime.UtcNow.AddHours(1);
            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {

                    new Claim(ClaimTypes.Name, account.Username),
                    new Claim(ClaimTypes.Email, account.Email),
                    new Claim(ClaimTypes.Role, account.Role.ToString()),
                    new Claim("UserId", account.Id.ToString())
                }),
                Expires = expires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var securityToken = tokenHandler.CreateToken(descriptor);
            var token = tokenHandler.WriteToken(securityToken);

            var result = new Result
            {
                isSuccess = 1,
                msg = $"Hoşgeldin {account.Name} {account.LastName} ",
                token = token,
                expires = expires,
                id = account.Id,
                username = account.Username,
                name = account.Name,
                lastName = account.LastName,
                role = account.Role,
                email=account.Email

            };
            return result;
        }
        private static string ToSha256(string value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            using (var hash = SHA256.Create())
            {
                Encoding encoding = Encoding.UTF8;
                byte[] result = hash.ComputeHash(encoding.GetBytes(value));
                foreach (byte b in result)
                    stringBuilder.Append(b.ToString("x2"));
            }
            return stringBuilder.ToString();
        }
    }
}
