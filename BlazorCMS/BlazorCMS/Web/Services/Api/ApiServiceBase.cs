using System.Net.Http;

namespace BlazorCMS.Web.Services.Api
{
    public abstract class ApiServiceBase
    {
        protected HttpClient _httpClient { get; set; }

        public ApiServiceBase(HttpClient http)
        {
            _httpClient = http;
        }
    }
}
