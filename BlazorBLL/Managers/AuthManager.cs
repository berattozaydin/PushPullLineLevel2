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
        /*private static string secret = "123waeaqweqeqwqwewqqew";
        public TokenDto Login(Account account)
        {
            TokenDto tokenDto = new TokenDto();
            Account user = tpHetrL3Context.Accounts.FirstOrDefault(x => x.Username == account.Username);
            if (user == null) 
            {
                tokenDto.TokenOrMessage = "Giriş Yapılamadı";

            }
            bool credentials = user.Password.Equals(account.Password);
            if (!credentials)
            {
                tokenDto.TokenOrMessage = "Invalid Password";

            }
            tokenDto.TokenOrMessage = GenerateToken(account.Username);
            return tokenDto;
        }
        public static string GenerateToken(string userName)
        {
            byte[] key = Convert.FromBase64String(secret);
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(key);
            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, userName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(45),
                SigningCredentials = new SigningCredentials(symmetricSecurityKey,SecurityAlgorithms.HmacSha256Signature)
            };
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = jwtSecurityTokenHandler.CreateJwtSecurityToken(securityTokenDescriptor);
            return jwtSecurityTokenHandler.WriteToken(token);
        }
        public static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtSecurityToken = (JwtSecurityToken)jwtSecurityTokenHandler.ReadToken(token);
                if(jwtSecurityToken == null)
                {
                    return null;
                }
                byte[] key = Convert.FromBase64String(secret);
                TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
                SecurityToken securityToken;
                ClaimsPrincipal claimsPrincipal = jwtSecurityTokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
                return claimsPrincipal;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public static string ValidateToken(string token)
        {
            string userName = null;
            ClaimsPrincipal principal = GetPrincipal(token);
            if (principal == null)
                return null;
            ClaimsIdentity claimsIdentity = null;
            try
            {
                claimsIdentity = (ClaimsIdentity)principal.Identity;
            }catch(Exception ex)
            {
                throw;
            }
            Claim claim = claimsIdentity.FindFirst(ClaimTypes.Name);
            userName = claim.Value;
            return userName;
        }*/
    }
}
