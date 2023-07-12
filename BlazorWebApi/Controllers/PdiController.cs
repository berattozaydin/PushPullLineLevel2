using BlazorBLL.Managers;
using BlazorDAL.Models;
using BlazorDAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class PdiController : ControllerBase
    {

        PdiManager customerOrderManager;
        public PdiController(PdiManager customerOrderManager)
        {
            this.customerOrderManager = customerOrderManager;
        }
        [HttpPost]
        public ReturnResult UpdatePdi(PDI parametres)
        {
            var res = customerOrderManager.UpdatePdi(parametres);
            return res;
        }
        [HttpPost]
        public ReturnResult AddPdi(PDI parametres)
        {
            var res = customerOrderManager.AddPdi(parametres);
            return res;
        }
        [HttpGet]
        public ReturnResult<List<PDI>> GetPdiList()
        {
            var res = customerOrderManager.GetPdiList();
            return res;
        }
        [HttpGet]
        public ReturnResult<PdiDto> GetPdi(string enCoilId)
        {
            var res = customerOrderManager.GetPdi(enCoilId);
            return res;
        }
        /*[HttpGet]
        public ReturnResult<List<CustomerOrderStatus>> GetCustomerOrderStatusList()
        {
            var res = customerOrderManager.GetCustomerOrderStatusList();
            return res;

        }*/
        [HttpPost]
        public ReturnResult DeletePdi(PdiDto pdi)
        {
            var res = customerOrderManager.DeletePdi(pdi);
            return res;
        }
       /* [HttpPost]
        public ReturnResult ChangePdiStatus(CustomerOrder customerOrder)
        {
            var res = customerOrderManager.ChangePdiStatus(customerOrder);
            return res;
        }*/
    }
}
