using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.WebApi.Middlewares;

namespace UI.WebApi.Extensions
{
    public static class AppExtensions
    {
        public static void UseErrorHandlerMiddlewhere(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddlerware>();
        }
    }
}
