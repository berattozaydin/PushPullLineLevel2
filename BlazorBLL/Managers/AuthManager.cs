using BlazorDAL;
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
            var account = mgr.Db.FirstOrDefault<USER_DATA>("SELECT * FROM dbo.user_data where user_name=@0 and password=@1", searchAccount.USER_NAME, ToSha256(searchAccount.PASSWORD));

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

                    new Claim(ClaimTypes.Name, account.USER_NAME),
                    new Claim(ClaimTypes.Email, account.FIRST_NAME),
                    new Claim(ClaimTypes.Role, account.USER_ROLE),
                    new Claim("UserId", account.ID.ToString())
                }),
                Expires = expires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var securityToken = tokenHandler.CreateToken(descriptor);
            var token = tokenHandler.WriteToken(securityToken);

            var result = new Result
            {
                isSuccess = 1,
                msg = $"Hoşgeldin {account.FIRST_NAME} {account.LAST_NAME} ",
                token = token,
                expires = expires,
                id = account.ID,
                username = account.USER_NAME,
                name = account.FIRST_NAME,
                lastName = account.LAST_NAME,
                role = Convert.ToInt32(account.USER_ROLE),
                email=account.FIRST_NAME

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
