using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Application.Exceptions;
using System.Net;
using System.Text.Json;

namespace UI.WebApi.Middlewares
{
    public class ErrorHandlerMiddlerware
    {
        private readonly RequestDelegate Next;

        public ErrorHandlerMiddlerware(RequestDelegate next)
        {
            Next = next;
        }
        
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await Next(context);
            }
            catch (Exception ex)
            {
                if (ex.InnerException is not null)
                {
                    // hacer un log
                    Console.WriteLine(ex.InnerException.Message);
                }
                else
                {
                    Console.WriteLine(ex.Message);
                }

                HttpResponse response = context.Response;
                response.ContentType = "application/json";
                List<string> list = new List<string>() { ex.Message };
                switch (ex)
                {
                    case ValidationException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        list = e.Errors;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                string result = JsonSerializer.Serialize(list);
                await response.WriteAsync(result);
            }
        }
    }
}
