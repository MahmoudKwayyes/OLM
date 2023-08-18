using Olm.Service.Exceptions;
using OnlineLearningManagment.Models;

namespace OnlineLearningManagment.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate request;
        private readonly ILogger<ExceptionHandlerMiddleware> logger;
        public ExceptionHandlerMiddleware(RequestDelegate request, ILogger<ExceptionHandlerMiddleware> logger)
        {
            this.request = request;
            this.logger = logger;
        }
        public async Task Invoke(HttpContext context) 
        {
            try
            {
                await this.request.Invoke(context);
            }
            catch (NotFoundException ex) 
            {
                await context.Response.WriteAsJsonAsync(new Response
                {
                    StatusCode = ex.StatusCode,
                    Message = ex.Message,
                });
            }
            catch (AlreadyExistException ex)
            {
                await context.Response.WriteAsJsonAsync(new Response
                {
                    StatusCode = ex.StatusCode,
                    Message = ex.Message,
                });
            }
            catch (Exception ex)
            {
                await context.Response.WriteAsJsonAsync(new Response
                {
                    StatusCode = 500,
                    Message = ex.Message,
                });
                logger.LogError(ex.ToString());
            }

        }
    }
}
