using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace CM.App.Infrastructure
{
    public class GlobalExceptionLogger : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            string message = "Exception";

            if (context.ExceptionContext != null)
            {
                message = $"{DateTime.UtcNow} : {context.ExceptionContext.Exception.Message}";
            }
            else if (context.Exception != null)
            {
                message = $"{DateTime.UtcNow} : {context.Exception.Message}";
            }
            
            string filePath = Path.Combine(@"E:\Logs", "errorLog.txt");

            File.AppendAllText(filePath, message);
        }
    }
}