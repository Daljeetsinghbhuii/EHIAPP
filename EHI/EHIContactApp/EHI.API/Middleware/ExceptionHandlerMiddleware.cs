using EHI.Services.ServiceModel.Contact.Error;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EHI.Services.API.Middleware
{
    /// <summary>
    /// Exception middleware methods
    /// </summary>
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// ExceptionHandlerMiddleware constructor
        /// </summary>
        /// <param name="next"></param>
        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Invoke method
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context, IConfiguration configuration)
        {
            try
            {
                //Commented by Daljeet
                //Here we can also write code to valide token if our API's are token based
                await _next(context).ConfigureAwait(false);
            }
            catch (BadRequestException badRequestEx)
            {
                await LogExceptionData(context, badRequestEx.ErrorCode,
                      badRequestEx.ErrorMessage, badRequestEx.HttpStatusCode).ConfigureAwait(false);
            }
            catch (RecordNotFoundException recordNotFoundException)
            {
                await LogExceptionData(context, recordNotFoundException.ErrorCode,
                                       recordNotFoundException.ErrorMessage, recordNotFoundException.HttpStatusCode).ConfigureAwait(false);
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException updateException)
            {
                await LogExceptionData(context, ErrorCodes.DuplicateKeyException,
                                        updateException.InnerException.Message, HttpStatusCode.BadRequest).ConfigureAwait(false);
            }            
            catch (Exception ex)
            {
                await LogExceptionData(context, ex.Message,
                                        ex.InnerException.ToString(), HttpStatusCode.InternalServerError).ConfigureAwait(false);
            }
        }

        private static async Task LogExceptionData(HttpContext httpContext, string errorCode, string errorMessage, HttpStatusCode httpStatusCode)
        {            
            //Commented by Daljeet
            //Any logging libraly can be used here to log the exception for ex- log4Net
            var result = JsonConvert.SerializeObject(new ErrorInfo(errorCode, errorMessage, httpStatusCode));
            httpContext.Response.StatusCode = (int)httpStatusCode;
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsync(result).ConfigureAwait(false);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    /// <summary>
    /// Exception handler middleware extensions
    /// </summary>
    public static class ExceptionHandlerMiddlewareExtensions
    {
        /// <summary>
        /// Use exception handler middleware
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
        {

            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
