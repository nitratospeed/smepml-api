using Application.Common.Exceptions;
using Application.Common.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {

        private readonly IDictionary<string, Action<ExceptionContext>> _exceptionHandlers;

        private string CustomType = "";

        private string CustomMessage = "";

        private IEnumerable<ValidationFailure> CustomValidationMessage;

        public ApiExceptionFilterAttribute()
        {
            // Register known exception types and handlers.
            _exceptionHandlers = new Dictionary<string, Action<ExceptionContext>>
            {
                { nameof(ValidationException), HandleValidationException },
                { nameof(NotFoundException), HandleNotFoundException },
                //{ nameof(UnauthorizedAccessException), HandleUnauthorizedAccessException },
                //{ nameof(ForbiddenAccessException), HandleForbiddenAccessException },
                //{ nameof(CustomException), HandleCustomException },
            };
        }

        public override void OnException(ExceptionContext context)
        {
            HandleException(context);

            var errorResponse = new BaseApiResponse<object>() { Data = null, Exception = CustomType, IsSuccess = false, Message = CustomMessage, ValidationErrors = CustomValidationMessage };

            context.Result = new JsonResult(errorResponse);

            base.OnException(context);
        }

        private void HandleException(ExceptionContext context)
        {
            var type = context.Exception.GetType().Name;
            if (_exceptionHandlers.ContainsKey(type))
            {
                _exceptionHandlers[type].Invoke(context);
                return;
            }

            HandleUnknownException(context);
        }

        private void HandleValidationException(ExceptionContext context)
        {
            //var exception = ((FluentValidation.ValidationException)context.Exception).Errors;

            var exception = context.Exception as ValidationException;

            CustomType = "ValidationException";

            CustomValidationMessage = exception.Errors;

            context.ExceptionHandled = true;
        }

        private void HandleNotFoundException(ExceptionContext context)
        {
            var exception = context.Exception as NotFoundException;

            CustomType = "NotFoundException";

            CustomMessage = exception.Message;

            context.ExceptionHandled = true;
        }

        //private void HandleUnauthorizedAccessException(ExceptionContext context)
        //{
        //    var details = new ProblemDetails
        //    {
        //        Status = StatusCodes.Status401Unauthorized,
        //        Title = "Unauthorized",
        //        Type = "https://tools.ietf.org/html/rfc7235#section-3.1"
        //    };

        //    CustomType = "UnauthorizedAccessException";

        //    CustomMessage = "Error " + details.Status.ToString() + ": " + details.Title;

        //    context.ExceptionHandled = true;
        //}

        //private void HandleForbiddenAccessException(ExceptionContext context)
        //{
        //    var details = new ProblemDetails
        //    {
        //        Status = StatusCodes.Status403Forbidden,
        //        Title = "Forbidden",
        //        Type = "https://tools.ietf.org/html/rfc7231#section-6.5.3"
        //    };

        //    CustomType = "ForbiddenAccessException";

        //    CustomMessage = "Error " + details.Status.ToString() + ": " + details.Title;

        //    context.ExceptionHandled = true;
        //}

        private void HandleUnknownException(ExceptionContext context)
        {
            var details = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "An error occurred while processing your request.",
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1"
            };

            CustomType = "UnknownException";

            CustomMessage = "Error " + details.Status.ToString() + ": " + details.Title;

            context.ExceptionHandled = true;
        }

        private void HandleCustomException(ExceptionContext context)
        {
            CustomType = "CustomException";

            CustomMessage = context.Exception.Message;

            context.ExceptionHandled = true;
        }
    }
}
