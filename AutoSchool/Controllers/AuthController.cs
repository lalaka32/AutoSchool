using System.Threading.Tasks;
using AutoMapper;
using AutoSchool.Models.User;
using Common.DataContracts.User;
using Common.Ecxeptions;
using Common.Enums.User;
using DataService.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtAuthenticationService _jwtAuthenticationService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        public AuthController(IUserService userService, IJwtAuthenticationService jwtAuthenticationService,
            IAuthenticationService authenticationService, IMapper mapper)
        {
            _userService = userService;
            _authenticationService = authenticationService;
            _jwtAuthenticationService = jwtAuthenticationService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody] UserRegistryModel model)
        {
            var createDto = _mapper.Map<UserCreateDto>(model);

            createDto.RoleId = Role.Student;

            _userService.Create(createDto);

            var userId = await _authenticationService.Login(_mapper.Map<UserLoginDto>(model));

            var tokenString = _jwtAuthenticationService.GenerateJsonWebToken(userId);

            return Ok(new {token = tokenString});
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] UserLoginModel loginUser)
        {
            var userId = await _authenticationService.Login(_mapper.Map<UserLoginDto>(loginUser));

            var tokenString = _jwtAuthenticationService.GenerateJsonWebToken(userId);

            return Ok(new {token = tokenString});
        }
    }
}