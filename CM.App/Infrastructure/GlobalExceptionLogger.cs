using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace CM.App.Infrastructure
{
    public class GlobalExceptionLogger : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            if (context.ExceptionContext != null)
            {
                Trace.TraceError(context.ExceptionContext.Exception.ToString());
            }
            else if (context.Exception != null)
            {
                Trace.TraceError(context.Exception.ToString());
            }
        }
    }
}