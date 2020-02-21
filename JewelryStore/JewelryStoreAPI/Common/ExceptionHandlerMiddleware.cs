using JewelryStoreAPI.Core.Exceptions;
using JewelryStoreAPI.Services.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Common
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionHandlerMiddleware> _logger;

        public CustomExceptionHandlerMiddleware(RequestDelegate next, ILogger<CustomExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode code;

            string result;

            switch (exception)
            {
                case BaseBusinessJewelryStoreException baseBusinessJewelryStoreException:
                    code = (HttpStatusCode)baseBusinessJewelryStoreException.ErrorCode;
                    result = JsonConvert.SerializeObject(new { error = exception.Message });
                    break;
                case BasePersistenceJewelryStoreException _:
                    code = HttpStatusCode.Conflict;
                    result = JsonConvert.SerializeObject(new { error = exception.Message });
                    break;
                default:
                    code = HttpStatusCode.UnprocessableEntity;
                    result = JsonConvert.SerializeObject(new { error = "Unhandaled exception. Please try later." });
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            _logger.LogWarning($"Exception while processing {context.Request.Path}. Exception message: {exception.Message}");

            return context.Response.WriteAsync(result);
        }
    }
}
