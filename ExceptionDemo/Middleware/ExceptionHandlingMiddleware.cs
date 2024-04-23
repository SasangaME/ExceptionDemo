
using System.Net;
using System.Text.Json;
using ExceptionDemo.Exceptions;
using ExceptionDemo.Models;

namespace ExceptionDemo.Middleware
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await SendResponse(context, ex, ex switch
                {
                    NotFoundException _ => HttpStatusCode.NotFound,
                    ValidationException _ => HttpStatusCode.BadRequest,
                    _ => HttpStatusCode.InternalServerError
                });
            }
        }
        private async Task SendResponse(HttpContext context, Exception ex, HttpStatusCode statusCode)
        {
            _logger.LogError(ex.Message, ex);
            ErrorResponse err = new()
            {
                Message = ex.Message,
                StackTrace = ex.StackTrace,
            };
            var response = JsonSerializer.Serialize(err);
            context.Response.StatusCode = (int)statusCode;
            await context.Response.WriteAsync(response);
        }
    }
}
