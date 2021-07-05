using eKomplet_Test.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace eKomplet_Test.Models
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (DBexception e)
            {
                // Log
                await HandleExceptionAsync(httpContext, e);
                throw;
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, DBexception e)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.OK;

            return httpContext.Response.WriteAsync(new EKException
            {
                StatusCode = e.Message,
                Message = "Internal Server Error",
                ErrorMessage = e.ToString()
            }.ToString());
        }
    }
}
