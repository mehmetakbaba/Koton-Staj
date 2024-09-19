using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Koton.Discount.Business.Filters
{
    public class FluentValidationFilter : IAsyncActionFilter
    {

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.SelectMany(x => x.Errors).Select(
                    x => x.ErrorMessage).ToList();

                var errorResponse = new
                {
                    StatusCode = 400,
                    Errors = errors
                };

                context.Result = new BadRequestObjectResult(errorResponse);
                return;
            }


            await next();
        }
    }
}
