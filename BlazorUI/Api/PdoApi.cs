using BlazorDAL;
using BlazorDAL.Models;
using BlazorUI.Src;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Reflection.Metadata;
using System;
using Radzen;

namespace BlazorUI.Api
{
    public class PdoApi
    {
        IHttpClient _httpClient;
        NavigationManager navigationManager;
        string END_POINT = "http://localhost:5213/api/pdo/"; //""; //Must be empty for publish
        public PdoApi(IHttpClient httpClient,NavigationManager navigationManager)
        {
            this._httpClient = httpClient;
            this.navigationManager = navigationManager;
            //END_POINT = navigationManager.BaseUri +"/api/pdo/";
        }
        public async Task<List<PDO>> GetAllPdoList()
        {
            var urL = new Uri(END_POINT+"GetAllPdoList");
            var res = await _httpClient.GetFromJsonAsync<ReturnResult<List<PDO>>>(urL);
            return res.result;
        }
        public async void UpdatePdo(PDO pdoDto)
        {
            var urL = new Uri(END_POINT+"UpdatePdo");
            var res = await _httpClient.PostAsJsonAsync(urL, pdoDto);
            await res.ReadAsync<ReturnResult>();
        }
        public async void AddPdo(PDO pdoDto)
        {
            var urL = new Uri(END_POINT+"AddPdo");
            var res = await _httpClient.PostAsJsonAsync(urL, pdoDto);
            await res.ReadAsync<ReturnResult>();
        }
        public async void DeletePdo(PDO pdoDto)
        {
            var urL = new Uri(END_POINT+"DeletePdo");
            var res = await _httpClient.PostAsJsonAsync(urL, pdoDto);
            await res.ReadAsync<ReturnResult>();
        }
        public async Task<PDO> GetPdo(string exCoilId)
        {
            var urL = new Uri(END_POINT+"GetPdo?exCoilId="+exCoilId);
            var res = await _httpClient.GetFromJsonAsync<ReturnResult<PDO>>(urL);
            return res.result;
        }
    }
}
