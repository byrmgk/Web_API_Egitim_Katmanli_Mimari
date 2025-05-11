using Entities.ErrorModel;
using Entities.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Services.Contracts;
using System.Net;

namespace WebAPI.Extensions
{
    //TODO: Exception metotodlar static olarak tanımlanır.
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app, ILoggerService logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    //TODO: Use ExceptionHandler yakaladığımız için artık . (int)HttpStatusCode.InternalServerError; siliyoruz.  Artık 500 ve 400 hataları olabilir. 
                    //context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature is not  null)
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound, //TODO: NotFound ise 404 değil ise 500
                            _ => StatusCodes.Status500InternalServerError

                        };

                        logger.LogError($"Bir şeyler ters gitti: {contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message//TODO: contextFeature.Error.Message ile hata mesajını alıyoruz.
                        }.ToString());
                    }
                });
            });
        }
    }
}
