using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using AutoSchool.Authorization;
using AutoSchool.Models.User;
using Common.BisnessObjects;
using Common.DataContracts.User;
using Common.Enums.User;
using DataService.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AutoSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJWTAuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        public AuthController(IUserService userService, IJWTAuthenticationService authenticationService, IMapper mapper)
        {
            _userService = userService;
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public IActionResult Register([FromBody]UserRegistryModel model)
        {
            var withLoginExist = _userService.Search(
                new UserCollectionFilterDto { Login = model.Login })
                .Count > 0;

            if (withLoginExist)
            {
                const string LoginTakenErrorMessage = "Login is already taken";
                return BadRequest(new { error = LoginTakenErrorMessage });
            }

            var createDto = _mapper.Map<UserCreateDto>(model);

            createDto.RoleId = Role.Student;
            
            var userId = _userService.Create(createDto);
            _authenticationService.Login(_mapper.Map<UserLoginDto>(model));

            var tokenString = _authenticationService.GenerateJSONWebToken(userId);

            return Ok(new { token = tokenString });
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody]User loginUser)
        {
            var userId = await _authenticationService.Login(_mapper.Map<UserLoginDto>(loginUser));
//            if (user == null)
//            {
//                const string LoginNotCorrectErrorMessage = "No users with this login";
//                return Unauthorized(new { error = LoginNotCorrectErrorMessage });
//            }
//            if (user.Password != loginUser.Password)
//            {
//                const string PasswordErrorMessgae = "Wrong password";
//                return Unauthorized(new { error = PasswordErrorMessgae });
//            }

            var tokenString = await _authenticationService.GenerateJSONWebToken(userId);

            return Ok(new { token = tokenString });
        }

        public string GenerateJSONWebToken(User userInfo)
        {
            var securityKey = AuthOptions.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, userInfo.Login),
                        new Claim(JwtRegisteredClaimNames.Jti, userInfo.Id.ToString())};

            var token = new JwtSecurityToken(AuthOptions.ISSUER,
            AuthOptions.AUDIENCE,
            claims,
            signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}