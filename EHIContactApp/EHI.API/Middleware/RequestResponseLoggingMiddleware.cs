using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace EHI.Services.Contact.API.Middleware
{
    /// <summary>
    /// Request response logging middleware
    /// </summary>
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Request response logging middleware
        /// </summary>
        /// <param name="next"></param>
        public RequestResponseLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Middle ware invocation for logging request and response
        /// </summary>
        /// <param name="context"></param>
        /// <param name="common"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context, Common common, IConfiguration configuration)
        {
            context.Request.EnableRewind();
            LogAPIRequest(context, common);

            await LogAPIResponse(context, common).ConfigureAwait(false);
        }

        /// <summary>
        /// Log API request
        /// </summary>
        /// <param name="context"></param>
        /// <param name="loggingManager"></param>
        /// <param name="common"></param>
        /// <returns></returns>
        private async Task LogAPIResponse(HttpContext context, Common common)
        {
            var originalBodyStream = context.Response.Body;
            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;//... use for the temporary response body
                await _next(context).ConfigureAwait(false);

                context.Response.Body.Seek(0, SeekOrigin.Begin);
                string responseBodyText = await new StreamReader(context.Response.Body).ReadToEndAsync().ConfigureAwait(false);
                context.Response.Body.Seek(0, SeekOrigin.Begin);                
                await responseBody.CopyToAsync(originalBodyStream).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Log API response
        /// </summary>
        /// <param name="context"></param>
        /// <param name="loggingManager"></param>
        /// <param name="common"></param>
        private static void LogAPIRequest(HttpContext context, Common common)
        {
            using (var stream = new MemoryStream())
            {
                context.Request.Body.Seek(0, SeekOrigin.Begin);
                context.Request.Body.CopyTo(stream);
                string requestBody = Encoding.UTF8.GetString(stream.ToArray());
                context.Request.Body.Seek(0, SeekOrigin.Begin);                
            }
        }
    }
}
