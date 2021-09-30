using Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace WebApi.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public string UserName { get; }
        public string UserId { get; }
        public DateTime? NotValidBefore { get; }
        public DateTime? Expiration { get; }

        public CurrentUserService(IHttpContextAccessor httpContextAccessor, IDateTime dateTime)
        {
            UserName = httpContextAccessor?.HttpContext?.User?.FindFirstValue("username") ?? "System";
            UserId = httpContextAccessor?.HttpContext?.User?.FindFirstValue("id") ?? null;
            var nbf = httpContextAccessor?.HttpContext?.User?.FindFirstValue("nbf");

            if (nbf != null)
            {
                NotValidBefore = dateTime.OffsetFromUnixTimeSeconds(Convert.ToInt64(nbf));
            }
            var exp = httpContextAccessor?.HttpContext?.User?.FindFirstValue("exp");

            if (exp != null)
            {
                Expiration = dateTime.OffsetFromUnixTimeSeconds(Convert.ToInt64(exp));
            }

        }
    }
}
