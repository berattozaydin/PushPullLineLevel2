using BlazorBLL.Managers;
using BlazorDAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebApi.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]/[action]")]


    public class AuthController : ControllerBase
    {
        AuthManager authManager;
        public AuthController(AuthManager authManager)
        {
            this.authManager = authManager;
        }
        [HttpPost]
        public async Task<IActionResult> Login(AccountDto account)
        {
            var res = await authManager.LoginUser(account);
            return Ok(res);
        }
    }
}
