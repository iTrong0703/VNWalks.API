using System.Net;

namespace VNWalks.API.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext); // Gọi middleware tiếp theo để xử lý tiếp nếu k có lỗi
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid();

                // Log exception
                _logger.LogError(ex, $"{errorId} : {ex.Message}");

                // Return client a custom response
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";

                var error = new
                {
                    Id = errorId,
                    ErrorMessage = "Something went wrong! We are looking into resolving this. Sorry"
                };

                await httpContext.Response.WriteAsJsonAsync(error);
            }
        }
    }
}
