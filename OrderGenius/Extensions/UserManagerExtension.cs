
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OrderGenius.Core.Entities.Identity;
using System.Security.Claims;

namespace OrderGenius.Extensions
{
    public static class UserManagerExtension
    {
        public static async Task<AppUser> FindEmialWithAddressAsync(
            this UserManager<AppUser> input, ClaimsPrincipal user)
        {
            var email = user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            return await input.Users.Include(x=>x.Address).SingleOrDefaultAsync(x => x.Email == email);
        }
        public static async Task<AppUser> FindByEmailFromClaimPrincipal(
            this UserManager<AppUser> input, ClaimsPrincipal user)
        {
            var email = user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            return await input.Users.SingleOrDefaultAsync(x => x.Email == email);
        }
    }
}
