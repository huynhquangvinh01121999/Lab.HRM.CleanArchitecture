using Application.DTOs.ResultDto;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Extensions.ApplicationBuilderExtensions
{
    public static class HttpResponseExtensions
    {
        public static IApplicationBuilder UseHttpResponseExtensions(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                await next();

                var response = context.Response;
                response.ContentType = "application/json";
                var result = "";

                switch (context.Response.StatusCode)
                {
                    case (int)HttpStatusCode.Unauthorized:
                        result = JsonSerializer.Serialize(new HandlerResult<Task>().Failed("Token Validation Has Failed.Request Access Denied"));
                        break;
                    case (int)HttpStatusCode.Forbidden:
                        result = JsonSerializer.Serialize(new HandlerResult<Task>().Failed("Access Deny!"));
                        break;
                    default:
                        result = JsonSerializer.Serialize(new HandlerResult<Task>().Failed("Server error!"));
                        break;
                }
                await context.Response.WriteAsync(result);
            });

            return app;
        }
    }
}
