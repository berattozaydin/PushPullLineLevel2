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

    public class CustomerOrderController : ControllerBase
    {

        CustomerOrderManager customerOrderManager;
        public CustomerOrderController(CustomerOrderManager customerOrderManager)
        {
            this.customerOrderManager = customerOrderManager;
        }
        [HttpPost]
        public ReturnResult UpdateCustomerOrder(CustomerOrder parametres)
        {
            var res = customerOrderManager.UpdateCustomerOrder(parametres);
            return res;
        }
        [HttpPost]
        public ReturnResult AddCustomerOrder(CustomerOrder parametres)
        {
            var res = customerOrderManager.AddCustomerOrder(parametres);
            return res;
        }
        [HttpGet]
        public ReturnResult<List<CustomerOrderDto>> GetCustomerOrderList()
        {
            var res = customerOrderManager.GetCustomerOrderList();
            return res;
        }
        [HttpGet]
        public ReturnResult<CustomerOrder> GetCustomerOrder(string CustomerOrderId)
        {
            var res = customerOrderManager.GetCustomerOrder(CustomerOrderId);
            return res;
        }
        [HttpGet]
        public ReturnResult<List<CustomerOrderStatus>> GetCustomerOrderStatusList()
        {
            var res = customerOrderManager.GetCustomerOrderStatusList();
            return res;

        }
        [HttpPost]
        public ReturnResult DeleteCustomerOrder(CustomerOrderDto customerOrderId)
        {
            var res = customerOrderManager.DeleteCustomerOrder(customerOrderId);
            return res;
        }
        [HttpPost]
        public ReturnResult ChangePdiStatus(CustomerOrder customerOrder)
        {
            var res = customerOrderManager.ChangePdiStatus(customerOrder);
            return res;
        }
    }
}
