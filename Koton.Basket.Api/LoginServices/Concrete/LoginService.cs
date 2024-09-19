using Koton.Basket.Api.LoginServices.Abstract;

namespace Koton.Basket.Api.LoginServices.Concrete
{
    public class LoginService(IHttpContextAccessor contextAccessor) : ILoginService
    {
        private readonly IHttpContextAccessor _contextAccessor = contextAccessor;

        public string GetUserId => _contextAccessor.HttpContext.User.FindFirst("sub").Value;
    }
}
