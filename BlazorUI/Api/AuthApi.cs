using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Net.Http;
using BlazorDAL.Models;
using BlazorUI.Src;

namespace BlazorUI.Api
{
    public class AuthApi
    {
        string END_POINT = "http://localhost:5213/api/auth/";
        IHttpClient httpClient;
        NavigationManager navigationManager;
        public AuthApi(IHttpClient httpClient, NavigationManager navigationManager)
        {
            this.httpClient = httpClient;
            this.navigationManager = navigationManager;
            // END_POINT = navigationManager.BaseUri+"api/auth/";

        }
        public async Task<Result> Login(AccountDto user)
        {
            try
            {
                Uri urL = new Uri(END_POINT + "login");
                var httpClient = new HttpClient();
                var res = await httpClient.PostAsJsonAsync(urL, user);
                var result = await res.Content.ReadFromJsonAsync<Result>();
                return result;
            }
            catch (Exception ex)
            {
                return new Result
                {
                    msg = ex.InnerException?.ToString(),
                    username = ex.Message
                };
            }

        }
    }
}
