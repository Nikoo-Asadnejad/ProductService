using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Product.API.Middlewares
{
  public class ErrorHandlingMiddleware : IMiddleware
  {

    private readonly ILogger _loggerService;
    public ErrorHandlingMiddleware(ILogger loggerService)
    {
      _loggerService = loggerService;
    }
    
    public async Task InvokeAsync(HttpContext contex , RequestDelegate next)
    {
      try
      {
        await next(contex);
      }
      catch (Exception ex)
      {
         _loggerService.LogError(ex , $"An Error Captured by ErrorHandlingMiddleware  : {ex.Message}");
        await CreateErrorResponse(contex);
      }
    }
    private static async Task CreateErrorResponse( HttpContext contex)
    {
      contex.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
      contex.Response.ContentType = "application/json; charset=utf-8";

    }
    
  }
}
