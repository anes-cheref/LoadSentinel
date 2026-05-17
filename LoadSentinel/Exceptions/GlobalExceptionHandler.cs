using Microsoft.AspNetCore.Diagnostics;

namespace LoadSentinel.Exceptions;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        switch (exception)
        {
            case KeyNotFoundException:
                httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                var responseJson = new
                {
                    Message = "La ressource demandée n'existe pas.",
                    Detail = exception.Message
                };
                await httpContext.Response.WriteAsJsonAsync(responseJson, cancellationToken: cancellationToken);
                break;
            default:
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;    
                var responseJson2 = new
                {
                    Message = "Une erreur interne est survenue."
                };
                await httpContext.Response.WriteAsJsonAsync(responseJson2, cancellationToken: cancellationToken);
                break;
        }
        return true;
    }
}