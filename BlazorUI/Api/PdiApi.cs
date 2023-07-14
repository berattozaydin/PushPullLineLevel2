using BlazorDAL;
using BlazorDAL.Models;
using BlazorUI.Src;
using Microsoft.AspNetCore.Components;
using Radzen;
using System.Net.Http;

namespace BlazorUI.Api
{
    public class PdiApi
    {
        string END_POINT = "http://localhost:5213/api/pdi/";  //must be localhost debug mode
        IHttpClient httpClient;
        NavigationManager navigationManager;
        //string END_POINT = ""; // must be pusblish
        public PdiApi(IHttpClient httpClient, NavigationManager navigationManager)
        {
            this.httpClient = httpClient;
            httpClient.BaseAddress = new Uri(navigationManager.BaseUri);
            //END_POINT = navigationManager.BaseUri+"api/pdi/";
        }


        public async Task<PDI> UpdatePdi(PDI parametres)
        {
            Uri url = new Uri(END_POINT + "UpdatePdi");
            var res = await httpClient.PostAsJsonAsync(url, parametres);
            var result = res.Data;
            return result;
        }
        public async Task<PDI> AddPdi(PDI parametres)
        {
            Uri uriCustomerOrder = new Uri(END_POINT + "AddPdi");
            var res = await httpClient.PostAsJsonAsync(uriCustomerOrder, parametres);
            var result = res.Data;
            return result;
        }
        public async Task<List<PdiDto>> GetPdiList()
        {
            Uri urL = new Uri(END_POINT + "GetPdiList");
            var res = await httpClient.GetFromJsonAsync<ReturnResult<List<PdiDto>>>(urL);
            return res.result;
        }
        public async Task<PDI> GetPdi(string enCoilId)
        {
            Uri urL = new Uri(END_POINT + "GetPdi?enCoilId=" + enCoilId);
            var res = await httpClient.GetFromJsonAsync<ReturnResult<PDI>>(urL);
            return res.result;
        }
        /*public async Task<List<CustomerOrderStatus>> GetCustomerOrderStatusList()
        {
            Uri urL = new Uri(END_POINT + "GetCustomerOrderStatusList");
            var res = await httpClient.GetFromJsonAsync<ReturnResult<List<CustomerOrderStatus>>>(urL);
            return res.result;
        }*/
        public async Task<PdiDto> DeletePdi(PdiDto pdi)
        {
            Uri urL = new Uri(END_POINT + "DeletePdi");
            var res = await httpClient.PostAsJsonAsync(urL, pdi);
            var result = res.Data;
            return result;
        }
        public async Task<PDI> ChangePdiStatus(PDI pdi)
        {
            Uri urL = new Uri(END_POINT + "ChangePdiStatus");
            var res = await httpClient.PostAsJsonAsync(urL, pdi);
            var result = res.Data;
            return result;
        }
    }
}
