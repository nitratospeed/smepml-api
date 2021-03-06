using Application.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filters
{
    public class BaseApiResponseFilterAttribute : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ObjectResult objectResult)
            {
                objectResult.Value = new BaseApiResponse<object>
                {
                    IsSuccess = true,
                    Data = objectResult.Value,
                    Message = "The operation completed successfully",
                    Exception = "",
                    ValidationErrors = null
                };
            }
        }
    }
}
