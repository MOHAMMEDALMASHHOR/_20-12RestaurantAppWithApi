using Entities;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.HttpResults;
using Repositories.Services.Exceptions;

namespace RestaurantApi.Extensions;
public static class ExceptionMiddlewareHandler
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder app){
        app.UseExceptionHandler(appError=>
        {
            appError.Run(async context=>{
                context.Response.ContentType="application/json";
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature is not null)
                {
                    context.Response.StatusCode = contextFeature.Error switch
                    {
                        NotFoundException => StatusCodes.Status404NotFound,
                        BadRequestException => StatusCodes.Status400BadRequest,
                        InternalServerException => StatusCodes.Status500InternalServerError
                    };
                   
                    await context.Response.WriteAsync(new ErrorDetails()
                    {
                        SatusCode=context.Response.StatusCode,
                        Message=contextFeature.Error.Message
                    }.ToString());
                }
            });
        });
    }
}