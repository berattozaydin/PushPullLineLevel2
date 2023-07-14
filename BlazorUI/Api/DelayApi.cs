using BlazorDAL.Models;
using BlazorUI.Src;
using Microsoft.AspNetCore.Components;
using System.Text.Json;
using System.Text;
using Radzen;

namespace BlazorUI.Api
{
    public class DelayApi
    {
        string END_POINT = "http://localhost:5213/api/Delay/"; // must be empty publish
        IHttpClient httpClient;
        NavigationManager navigationManager;
        //string END_POINT = "";
        public DelayApi(NavigationManager navigationManager, IHttpClient httpClient)
        {
            this.httpClient= httpClient;
            //END_POINT = navigationManager.BaseUri+"api/delay/"; //must be open for publish

        }
        public async Task<List<DelayDto>> GetDelayList()
        {
            Uri urL = new Uri(END_POINT + "GetDelayList");
            var res = await httpClient.GetFromJsonAsync<ReturnResult<List<DelayDto>>>(urL);
            return res.result;
        }
        public async Task<DelayDto> DeleteDelay(DelayDto delay)
        {
            Uri urL = new Uri(END_POINT + "DeleteDelay");
            var res = await httpClient.PostAsJsonAsync(urL, delay);
            var result = res.Data;
            return result;
        }
        public async Task<DelayDto> GetDelay(int delayId)
        {
            Uri urL = new Uri(END_POINT+"GetDelay?delayId="+delayId);
            var res = await httpClient.GetFromJsonAsync<ReturnResult<DelayDto>>(urL);
            return res.result;
        }
    }
}
