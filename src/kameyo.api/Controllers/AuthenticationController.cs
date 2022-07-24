using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Kameyo.Core.Infrastructure.Identity.Models.Dtos.Request;
using Kameyo.Infrastructure.Identity.Entities;
using Kameyo.Infrastructure.Identity.User.Dtos.Response;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Kameyo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ApiControllerBase
    {
        UserManager<ApplicationUser> _userManager;
        IConfiguration _configuration;

        public AuthenticationController(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult<AuthenticateResponse>> Login(AuthenticateDtoRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                return Forbid();
            }

            var roles = await _userManager.GetRolesAsync(user);
            var userClaims = await _userManager.GetClaimsAsync(user);

            var claims = new List<Claim> {
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                //new Claim(ClaimTypes.GivenName, $"{user.FirstName} {user.LastName}")
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            foreach (var claim in userClaims)
            {
                claims.Add(new Claim(claim.Type, claim.Value));
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(720), //12 hours
                signingCredentials: credentials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

            return Ok(new AuthenticateResponse()
            {
                User = new AuthenticateUser()
                {
                    Email = user.Email,
                    UserName = user.UserName,
                    PersonTypeId = user.PersonTypeId?.ToString(),
                    PersonId = user.PersonId?.ToString()
                },
                AccessToken = jwt
            });
        }
    }
}
