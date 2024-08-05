using Hangfire.Annotations;
using Hangfire.Dashboard;
using Test.Server.Api.Models.Identity;

namespace Test.Server.Api;

internal class DashboardAuthorizationFilter : IDashboardAuthorizationFilter
{
    public DashboardAuthorizationFilter()
    {
    }

    public bool Authorize(DashboardContext context)
    {
        var httpContext = context.GetHttpContext();
        var isAuthenticated = httpContext.User.IsAuthenticated();
        return isAuthenticated;
    }
}
