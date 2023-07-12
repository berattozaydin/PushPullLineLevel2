using BlazorBLL.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class LevelerController : ControllerBase
    {
        LevelerManager levelerManager;
        public LevelerController(LevelerManager levelerManager)
        {
                this.levelerManager = levelerManager;
        }
    }
}
