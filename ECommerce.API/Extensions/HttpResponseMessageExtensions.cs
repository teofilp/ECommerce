using System.Net;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ECommerce.API.Extensions;

public static class HttpResponseMessageExtensions
{
    public static async Task<HttpResult<T>> GetResult<T>(this HttpResponseMessage responseMessage)
    {
        var body = await responseMessage.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<T>(body);
        
        if (!responseMessage.IsSuccessStatusCode || result is null)
        {
            return new HttpResult<T>
            {
                IsSuccess = false,
                StatusCode = responseMessage.StatusCode,
                ErrorMessage = body
            };
        }
        
        return new HttpResult<T>
        {
            IsSuccess = true,
            StatusCode = responseMessage.StatusCode,
            Data = result
        };
    }
}