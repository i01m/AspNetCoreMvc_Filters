﻿using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;


namespace Filters.Infrastructure
{
    public class MessageAttribute : ResultFilterAttribute
    {
        private string message;

        public MessageAttribute(string msg)
        {
            message = msg;
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            WriteMessage(context, $"<div>Before result: {message}</div>");
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            WriteMessage(context, $"<div>After result: {message}</div>");
        }

        private void WriteMessage(FilterContext context, string msg)
        {
            byte[] bytes = Encoding.ASCII.GetBytes($"<div>{msg}</div>");
            context.HttpContext.Response.Body.Write(bytes, 0, bytes.Length);
        }
    }
}
