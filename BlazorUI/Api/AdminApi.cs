using BlazorDAL.Models;
using BlazorDAL;
using BlazorUI.Src;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;
using System.Security.Principal;

namespace BlazorUI.Api
{
    public class AdminApi
    {
        IHttpClient _httpClient;
        NavigationManager _navigationManager;
        string END_POINT ="http://localhost:5213/api/admin/"; //Must be empty For Publish
        //string END_POINT = "";
        public AdminApi(IHttpClient _httpClient, NavigationManager _navigationManager)
        {
            this._httpClient = _httpClient;
            this._navigationManager = _navigationManager;
             //END_POINT = _navigationManager.BaseUri+"api/admin/"; // must be publish remove // 
        }
        public async Task<ReturnResult> SendRefresh()
        {
            Uri urL = new Uri(END_POINT+"SendRefresh");
            var modifiedAssetJSON = JsonSerializer.Serialize("");
            var requestContent = new StringContent(modifiedAssetJSON, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(urL, requestContent);
            var res = await response.Content.ReadFromJsonAsync<ReturnResult>();
            return res;
        }
    }
}
