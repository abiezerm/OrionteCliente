using System.Diagnostics;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

public static class ExceptionHandler
{
    public static void UseCustomErrors(this IApplicationBuilder app)
    {
        app.Use(WriteDevelopmentResponse);
    }
    private static async Task WriteDevelopmentResponse(HttpContext httpContext, Func<Task> next)
        => await WriteResponse(httpContext);
    private static Task WriteProductionResponse(HttpContext httpContext, Func<Task> next)
        => WriteResponse(httpContext);
    private static async Task WriteResponse(HttpContext httpContext)
    {
        var exceptionDetails = httpContext.Features.Get<IExceptionHandlerFeature>();
        var error = exceptionDetails?.Error;

        if (exceptionDetails is not null)
        {
            httpContext.Response.ContentType = "application/problem+json";

            if (error?.GetType().Name == nameof(ValidationException))
            {
                await BuildResponse(httpContext, HttpStatusCode.BadRequest, "Validation error", error.Message);
            }
            else if (error?.GetType().Name == nameof(UnauthorizeException))
            {
                await BuildResponse(httpContext, HttpStatusCode.Unauthorized, "Unauthorized", error.Message);
            }
            else if (error?.GetType().Name == nameof(NotFoundException))
            {
                await BuildResponse(httpContext, HttpStatusCode.NotFound, "Not found", error.Message);
            }
            else
            {
                await BuildResponse(httpContext, HttpStatusCode.InternalServerError, "Unhandler server error", error?.ToString()!);
                // save log
                // using var context = new POSContext();
                // var errorLog = new Error()
                // {
                //     Message = error?.Message!,
                //     Exception = Newtonsoft.Json.JsonConvert.SerializeObject(error?.InnerException).ToString(),
                //     Fecha = DateTime.Now
                // };

                // await context.Error.AddAsync(errorLog);
                // await context.SaveChangesAsync();
            }

        }
    }
    private static async Task BuildResponse(HttpContext context, HttpStatusCode code, string tittle, string errorMessage)
    {
        var stream = context.Response.Body;
        var traceId = Activity.Current?.Id ?? context.TraceIdentifier;

        context.Response.StatusCode = (int)code;

        var customError = JsonConvert.SerializeObject(
             new ErrorDetails(status: code, title: tittle, message: errorMessage, traceId: traceId));

        await context.Response.WriteAsync(customError);
        // await context.Response.WriteAsync(
        //    JsonSerializer.Serialize(new ErrorDetails(status: code, title: tittle, message: errorMessage, traceId: traceId)));
    }


    public class Person
    {
        public string Nombre = null!;
        public string apellido = null!;
        public Person(string nombre)
        {
            Nombre = nombre;
        }

    }
}