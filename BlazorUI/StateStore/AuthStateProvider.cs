using Blazored.LocalStorage;
using BlazorUI.Src;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http;
using System.Security.Claims;

namespace BlazorUI.StateStore
{
    public class AuthStateProvider : AuthenticationStateProvider
    {

        private readonly ILocalStorageService localStorageService;
        private readonly AuthenticationState anonymous;
        private IHttpClient httpClient;
        public AuthStateProvider(ILocalStorageService localStorageService, IHttpClient httpClient)
        {
            this.localStorageService = localStorageService;
            anonymous = new AuthenticationState(new System.Security.Claims.ClaimsPrincipal(new ClaimsIdentity()));
            this.httpClient = httpClient;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {

            var apiToken = await localStorageService.GetItemAsStringAsync("token");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiToken);
            if (string.IsNullOrEmpty(apiToken)) { return anonymous; }
            string email = await localStorageService.GetItemAsStringAsync("email");
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Email, email) }, "jwtAuthType"));
            var res = Task.FromResult(new AuthenticationState(claimsPrincipal));
            NotifyAuthenticationStateChanged(res);
            return new AuthenticationState(claimsPrincipal);
        }
        public void UserLogin(string email)
        {
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Email, email) }, "jwtAuthType"));
            var res = Task.FromResult(new AuthenticationState(claimsPrincipal));
            NotifyAuthenticationStateChanged(res);
        }
        public void UserLogout()
        {
            var res = Task.FromResult(anonymous);
            NotifyAuthenticationStateChanged(res);
        }
    }
}