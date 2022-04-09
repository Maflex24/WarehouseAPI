using WarehouseAPI.Exceptions;

namespace WarehouseAPI.ExceptionsAndMiddleware
{
    public class ExceptionHandlerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (AlreadyExistException alreadyExistException)
            {
                context.Response.StatusCode = 409;
                await context.Response.WriteAsync(alreadyExistException.Message);
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Something went wrong");
            }
        }
    }
}
