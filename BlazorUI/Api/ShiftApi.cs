using BlazorDAL;
using BlazorDAL.Models;
using BlazorUI.Src;
using Microsoft.AspNetCore.Components;
using System.Net.Http;

namespace BlazorUI.Api
{
    public class ShiftApi
    {
        IHttpClient _httpClient;
        NavigationManager navigationManager;
        string END_POINT = "http://localhost:5213/api/shift/"; // must be empty for publish
        public ShiftApi(IHttpClient _httpClient, NavigationManager navigationManager)
        {
            this._httpClient = _httpClient;
            _httpClient.BaseAddress = new Uri(navigationManager.BaseUri);
            // END_POINT = navigationManager.BaseUri+"api/shift/";
        }
        public async Task<Account> GetShift()
        {
            Uri urL = new Uri(END_POINT + "GetShift");
            var res = await _httpClient.GetFromJsonAsync<ReturnResult<Account>>(urL);
            return res.result;
        } 
    }
}
