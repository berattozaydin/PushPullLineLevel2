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
    public class PdoController : ControllerBase
    {
        PdoManager pdoManager;
        public PdoController(PdoManager pdoManager)
        {
            this.pdoManager = pdoManager;
        }
        [HttpGet]
        public ReturnResult<List<PDO>> GetAllPdoList()
        {
            var res = pdoManager.GetAllPdoList();
            return res;
        }
        [HttpGet]
        public ReturnResult<PdoDto> GetPdo(string exCoilId)
        {
            var res = pdoManager.GetPdo(exCoilId);
            return res;
        }
        [HttpPost]
        public ReturnResult AddPdo(PDO pdo)
        {
            var res = pdoManager.AddPdo(pdo);
            return res;
        }
        [HttpPost]
        public ReturnResult UpdatePdo(PDO pdo)
        {
            var res = pdoManager.UpdatePdo(pdo);
            return res;
        }
        [HttpPost]
        public ReturnResult DeletePdo(PDO pdo)
        {
            var res = pdoManager.DeletePdo(pdo);
            return res;
        }
    }
}
