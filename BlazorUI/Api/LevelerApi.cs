using BlazorDAL;
using BlazorDAL.Models;
using BlazorUI.Src;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Radzen;

namespace BlazorUI.Api
{
    public class LevelerApi
    {
        IHttpClient _httpClient;
        NavigationManager navigationManager;
        string END_POINT = "http://localhost:5213/api/leveler/";//""; //Must be empty for publish
        public LevelerApi(IHttpClient _httpClient, NavigationManager navigationManager)
        {
            this._httpClient= _httpClient;
            this.navigationManager = navigationManager;
            //END_POINT = navigationManager.BaseUri + "api/leveler";  //must be empty for publish 
        }
        public async Task<List<LEVELER_SETTING>> GetAllLevelerSettingList()
        {
            var urL = new Uri(END_POINT+"GetAllLevelerSettingList");
            var res = await _httpClient.GetFromJsonAsync<ReturnResult<List<LEVELER_SETTING>>>(urL);
            return res.result;
        }
        public async Task<LEVELER_SETTING> GetLevelerSetting(int levelerSettingId)
        {
            var urL = new Uri(END_POINT+"GetlevelerSetting?levelerSettingId="+levelerSettingId);
            var res = await _httpClient.GetFromJsonAsync<ReturnResult<LEVELER_SETTING>>(urL);
            return res.result;
        }
        public async void UpdateLevelerSetting(LEVELER_SETTING levelerSetting)
        {
            var urL = new Uri(END_POINT+"UpdateLevelerSetting");
            var res = await _httpClient.PostAsJsonAsync(urL, levelerSetting);
            
        }
        public async void AddLevelerSetting(LEVELER_SETTING levelerSetting)
        {
            var urL = new Uri(END_POINT+"AddLevelerSetting");
            var res = await _httpClient.PostAsJsonAsync(urL, levelerSetting);
          
        }
        public async void DeletelevelerSetting(LEVELER_SETTING levelerSetting)
        {
            var urL = new Uri(END_POINT+"DeletelevelerSetting");
            var res = await _httpClient.PostAsJsonAsync(urL, levelerSetting);
           
        }
    }
}
