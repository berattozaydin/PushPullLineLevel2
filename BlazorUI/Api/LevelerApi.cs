using BlazorUI.Src;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
    }
}
