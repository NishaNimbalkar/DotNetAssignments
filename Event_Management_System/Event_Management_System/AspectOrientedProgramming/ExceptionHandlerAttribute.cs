﻿using Event_Management_System.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Event_Management_System.AspectOrientedProgramming
{
    public class ExceptionHandlerAttribute:ExceptionFilterAttribute
    {
        readonly ILogger<ExceptionHandlerAttribute> _logger;
        public ExceptionHandlerAttribute(ILogger<ExceptionHandlerAttribute> logger)
        {
            _logger = logger;
        }
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(EventNotFoundException))
            {
                context.Result = new ConflictObjectResult(context.Exception.Message);
                _logger.LogError(context.Exception.Message);
            }
            else
            {
                context.Result = new StatusCodeResult(500);
            }
        }
    }
}
