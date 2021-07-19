using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Middleware
{
    public class HttpRequestLogger
    {
        private readonly RequestDelegate _next;

        public HttpRequestLogger(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var watch = new Stopwatch();
            watch.Start();

            context.Response.OnStarting(() => {
                watch.Stop();

                Console.WriteLine($"Response time : {watch.ElapsedMilliseconds}ms");

                return Task.CompletedTask;
            });

            context.Response.OnCompleted(() =>
            {
                var logBuilder = new StringBuilder();
                logBuilder.AppendJoin(" ", context.Request.Path, context.Request.Method, context.Response.StatusCode);

                Console.WriteLine(logBuilder.ToString());

                return Task.CompletedTask;
            });

            await this._next(context);
        }
    }
}
