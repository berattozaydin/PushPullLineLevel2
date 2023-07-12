using BlazorDAL;
using BlazorDAL.Models;
using BlazorUI.Src;
using Microsoft.AspNetCore.Components;
using Radzen;
using System;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Text;
using System.Net.Http.Json;

namespace BlazorUI.Api
{
    public class ShiftApi
    {
        IHttpClient _httpClient;
        NavigationManager navigationManager;
        string END_POINT = "http://localhost:5213/api/shift/"; // must be empty for publish
        //string END_POINT = "";
        public ShiftApi(IHttpClient _httpClient, NavigationManager navigationManager)
        {
            this._httpClient = _httpClient;
            _httpClient.BaseAddress = new Uri(navigationManager.BaseUri);
             //END_POINT = navigationManager.BaseUri+"api/shift/";
        }
        public async Task<USER_DATA> GetShift()
        {
            Uri urL = new Uri(END_POINT + "GetShift");
            var res = await _httpClient.GetFromJsonAsync<ReturnResult<USER_DATA>>(urL);
            return res.result;
        } 
        
        public async Task<ReturnResult> SetShiftForeman(USER_DATA account)
        {
            Uri urL = new Uri(END_POINT+"SetShiftForeman");
            /*   var res = await _httpClient.PostAsJsonAsync(urL, account);
               var result = await res.ReadAsync<ReturnResult>();
               return result;*/
           
            var modifiedAssetJSON = JsonSerializer.Serialize(account);
            var requestContent = new StringContent(modifiedAssetJSON, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(urL, requestContent);
            var res = await response.Content.ReadFromJsonAsync<ReturnResult>();
            return res;
        }
    }
}
