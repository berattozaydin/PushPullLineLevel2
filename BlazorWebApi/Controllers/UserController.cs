using BlazorBLL.Managers;
using BlazorDAL;
using BlazorDAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        UserManager userManager;
        public UserController(UserManager userManager)
        {
            this.userManager = userManager;       
        }

        [HttpGet]
        public ReturnResult<List<Account>> GetUserList()
        {
            var res = userManager.GetUserList();
            return res;
        }
    }
}
