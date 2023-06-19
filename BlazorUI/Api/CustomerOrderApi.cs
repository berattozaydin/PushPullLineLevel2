using BlazorDAL;
using BlazorDAL.Models;
using BlazorUI.Src;
using Microsoft.AspNetCore.Components;
using Radzen;
using System.Net.Http;

namespace BlazorUI.Api
{
    public class CustomerOrderApi
    {
        string END_POINT = "http://localhost:5213/api/customerOrder/";
        IHttpClient httpClient;
        NavigationManager navigationManager;
        //string END_POINT = "";
        public CustomerOrderApi(IHttpClient httpClient, NavigationManager navigationManager)
        {
            this.httpClient = httpClient;
            httpClient.BaseAddress = new Uri(navigationManager.BaseUri);
            // END_POINT = navigationManager.BaseUri+"api/customerorder/";
        }


        public async Task<ReturnResult> UpdateCustomerOrder(CustomerOrderDto parametres)
        {
            Uri url = new Uri(END_POINT + "UpdateCustomerOrder");
            var res = await httpClient.PostAsJsonAsync(url, parametres);
            var result = await res.ReadAsync<ReturnResult>();
            return result;
        }
        public async Task<ReturnResult> AddCustomerOrder(CustomerOrderDto parametres)
        {
            Uri uriCustomerOrder = new Uri(END_POINT + "AddCustomerOrder");
            var res = await httpClient.PostAsJsonAsync(uriCustomerOrder, parametres);
            var result = await res.ReadAsync<ReturnResult>();
            return result;
        }
        public async Task<List<CustomerOrderDto>> GetCustomerOrderList()
        {
            Uri urL = new Uri(END_POINT + "GetCustomerOrderList");
            var res = await httpClient.GetFromJsonAsync<ReturnResult<List<CustomerOrderDto>>>(urL);
            return res.result;
        }
        public async Task<CustomerOrderDto> GetCustomerOrder(string customerOrderId)
        {
            Uri urL = new Uri(END_POINT + "GetCustomerOrder?CustomerOrderId=" + customerOrderId);
            var res = await httpClient.GetFromJsonAsync<ReturnResult<CustomerOrderDto>>(urL);
            return res.result;
        }
        public async Task<List<CustomerOrderStatus>> GetCustomerOrderStatusList()
        {
            Uri urL = new Uri(END_POINT + "GetCustomerOrderStatusList");
            var res = await httpClient.GetFromJsonAsync<ReturnResult<List<CustomerOrderStatus>>>(urL);
            return res.result;
        }
        public async Task<ReturnResult> DeleteCustomerOrder(CustomerOrderDto customerOrderId)
        {
            Uri urL = new Uri(END_POINT + "DeleteCustomerOrder");
            var res = await httpClient.PostAsJsonAsync(urL, customerOrderId);
            var result = await res.ReadAsync<ReturnResult>();
            return result;
        }
        public async Task<ReturnResult> ChangePdiStatus(CustomerOrderDto customerOrder)
        {
            Uri urL = new Uri(END_POINT + "ChangePdiStatus");
            var res = await httpClient.PostAsJsonAsync(urL, customerOrder);
            var result = await res.ReadAsync<ReturnResult>();
            return result;
        }
    }
}
