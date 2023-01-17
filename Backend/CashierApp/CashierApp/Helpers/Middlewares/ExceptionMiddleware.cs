using C.Repository.Exceptions;
using System.Net;
using System.Text.Json;

namespace D.CashierApp.Helpers.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (InvalidClientOperationException ex)
            {

                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                ErrorResponse errorResponse = new(httpContext.Response.StatusCode, "Client Error",ex.Message);

                JsonSerializerOptions options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                string json = JsonSerializer.Serialize(errorResponse, options);
                await httpContext.Response.WriteAsync(json);
            }
            catch (Exception)
            {

                httpContext.Response.ContentType= "application/json";
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                ErrorResponse errorResponse = new(httpContext.Response.StatusCode, "Internal Server Error", "Something went wrong.");

                JsonSerializerOptions options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                string json = JsonSerializer.Serialize(errorResponse, options);
                await httpContext.Response.WriteAsync(json);
            }
           
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
