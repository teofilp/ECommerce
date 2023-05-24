using System.Net;

namespace ECommerce.API.Extensions;

public class HttpResult<T>
{
    public bool IsSuccess { get; set; }
    public T Data { get; set; }
    public string? ErrorMessage { get; set; }
    public HttpStatusCode StatusCode { get; set; }
}