using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OrderGenius.Core.Entities.Identity;
using OrderGenius.Core.Interfaces;
using OrderGenius.Dtos;
using System.Security.Claims;

namespace OrderGenius.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountController(SignInManager<AppUser> signInManager,
           UserManager<AppUser> userManager, ITokenService tokenService, IMapper mapper )
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet(nameof(GetCurrentUser))]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var user = new AppUser();
            var userEmailClaim = HttpContext.User.FindFirst(ClaimTypes.Email);
            if (userEmailClaim != null)
            {
                var userEmail = userEmailClaim.Value;
                user = await _userManager.FindByEmailAsync(userEmail);
            }
            return new UserDto
            {
                DisplayName = user.DisplayName,
                Token = _tokenService.CreateToken(user),
                Emial = user.Email
            };
        }
    }
}
