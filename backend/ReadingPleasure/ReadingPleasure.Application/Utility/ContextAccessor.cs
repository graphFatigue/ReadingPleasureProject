using Microsoft.AspNetCore.Http;
using ReadingPleasure.Abstractions.Application;
using System.Security.Claims;

namespace ReadingPleasure.Application.Utility
{
    public class ContextAccessor : IContextAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ContextAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid GetCurrentUserId()
        {
            var idClaim = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(x =>
                x.Type == ClaimTypes.NameIdentifier);
            if (idClaim is null)
            {
                throw new Exception("Not authorized");
            }

            return Guid.Parse(idClaim.Value);
        }
    }
}
