using BlazorDAL;
using BlazorDAL.Models;
using BlazorUI.Src;
using Microsoft.AspNetCore.Components;

namespace BlazorUI.Api
{
    public class UserApi
    {
        //string END_POINT = "";
        string END_POINT =  "http://localhost:5213/api/user/"; // must be empty publish
        IHttpClient httpClient;
        NavigationManager navigationManager;
        public UserApi(IHttpClient httpClient, NavigationManager navigationManager)
        {
            this.httpClient = httpClient;
            this.navigationManager= navigationManager;
            //END_POINT = navigationManager.BaseUri+"api/user/"; //must be open for publish
        }
        public async Task<List<USER_DATA>> GetUserList()
        {
            Uri urL = new Uri(END_POINT + "GetUserList");
            var res = await httpClient.GetFromJsonAsync<ReturnResult<List<USER_DATA>>>(urL);
            return res.result;
        }
    }
}
