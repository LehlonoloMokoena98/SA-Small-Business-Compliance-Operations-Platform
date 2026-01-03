using System.Security.Claims;

namespace SaCompliance.Api.Extensions;

public static class HttpContextExtensions
{
    public static Guid? GetUserId(this HttpContext context)
    {
        var id = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
        return id == null ? null : Guid.Parse(id);
    }
}
