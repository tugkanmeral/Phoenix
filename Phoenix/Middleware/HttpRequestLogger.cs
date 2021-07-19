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
                return Task.CompletedTask;
            });

            context.Response.OnCompleted(() =>
            {
                var logMsgBuilder = new StringBuilder();
                logMsgBuilder.Append($"Response time : {watch.ElapsedMilliseconds}ms\n");
                logMsgBuilder.AppendJoin(" ", context.Request.Path, context.Request.Method, context.Response.StatusCode);

                Console.WriteLine(logMsgBuilder.ToString());

                return Task.CompletedTask;
            });

            await this._next(context);
        }
    }
}
