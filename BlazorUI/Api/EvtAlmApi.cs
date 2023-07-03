using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using BlazorDAL.Models;
using BlazorUI.Src;
using System.Net.Http.Json;
namespace BlazorUI.Api
{
    public class EvtAlmApi
    {
        string END_POINT = "http://localhost:5213/api/EvtAlm/"; // must be empty publish
        IHttpClient httpClient;
        NavigationManager navigationManager;
        public EvtAlmApi(NavigationManager navigationManager, IHttpClient httpClient)
        {
            this.httpClient= httpClient;
            //END_POINT = navigationManager.BaseUri+"api/evtalm/"; //must be open for publish

        }
        public async Task<List<EvtAlmDto>> GetAllEvtAlm(EvtAlarmParams evtAlmDto)
        {
            var urL = new Uri(END_POINT + "GetAllEvtAlm");
            var modifiedAssetJSON = JsonSerializer.Serialize(evtAlmDto);
            var requestContent = new StringContent(modifiedAssetJSON, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(urL, requestContent);
            var res = await response.Content.ReadFromJsonAsync<ReturnResult<List<EvtAlmDto>>>();
            return res.result;
        }
    }
}
