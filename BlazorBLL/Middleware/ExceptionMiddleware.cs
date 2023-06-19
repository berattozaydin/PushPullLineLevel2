using BlazorDAL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorBLL.Middleware
{
    public class ExceptionMiddleware
    {
        public RequestDelegate _requestDelegate;

        public ExceptionMiddleware(RequestDelegate requestDelegate)
        {
            this._requestDelegate = requestDelegate;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }
        private async Task HandleException(HttpContext context, Exception ex)
        {

            /*var log = new event_alarm
            {
                log_description=ex.Message,
                log_method=context.Request.Method,
                user_name=manager.Identity.Name,
                machine_name = Environment.MachineName,
                dati=DateTime.Now,
            };
            manager.Db.Insert(log);*/

            var res = new ReturnResult
            {
                Msg = "Seviye-2 Program Hatası",
                IsSuccess = 0

            };
            var errorMessage = JsonSerializer.Serialize(res);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(errorMessage);
        }
    }
}
