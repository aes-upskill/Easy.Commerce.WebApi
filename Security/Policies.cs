using Microsoft.AspNetCore.Authorization;

namespace Easy.Commerce.WebApi.Security
{
    public static class Policies
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";

        public static AuthorizationPolicy AdminPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(Admin).Build();
        }

        public static AuthorizationPolicy CustomerPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(Customer).Build();
        }
    }
}
