using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAuth.Middleware
{
    public class PasswordHelpMiddleware
    {
        private readonly string helpWordQueryString = "help";
        private readonly string secretHelpWord = "wowa";
        private readonly RequestDelegate _next;
        public PasswordHelpMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var helpWord = context.Request.Query[helpWordQueryString];
            if (helpWord == secretHelpWord)
            {
                context.Response.StatusCode = StatusCodes.Status200OK;
                await context.Response.WriteAsync("login: admin@gmail.com, key: Nidsf473!");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
