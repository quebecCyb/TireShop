using Microsoft.AspNetCore.Authorization;
using TireShop.Schemas.Auth;
using TireShop.Types.Auth;

namespace TireShop.Guard
{
    public class AdminGuard : IAuthorizationRequirement { }

    public class AdminHandler : AuthorizationHandler<AdminGuard>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AdminGuard requirement)
        {
            var role = context.User.Claims.First(c => c.Type == AuthTypes.Role);
            if (role.Value == Role.Admin)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }

    }
}