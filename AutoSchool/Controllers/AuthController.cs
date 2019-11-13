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
        private readonly IJwtAuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        public AuthController(IUserService userService, IJwtAuthenticationService authenticationService, IMapper mapper)
        {
            _userService = userService;
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public IActionResult Register([FromBody] UserRegistryModel model)
        {
            var createDto = _mapper.Map<UserCreateDto>(model);

            createDto.RoleId = Role.Student;

            try
            {
                _userService.Create(createDto);
            }
            catch (BadOperationException e)
            {
                if (e.Code == ErrorCode.LoginOccupied)
                {
                    const string loginTakenErrorMessage = "Login is already taken";
                    return BadRequest(new {error = loginTakenErrorMessage});
                }
            }

            var userId = _authenticationService.Login(_mapper.Map<UserLoginDto>(model));

            var tokenString = _authenticationService.GenerateJsonWebToken(userId);

            return Ok(new {token = tokenString});
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public IActionResult Login([FromBody] UserLoginModel loginUser)
        {
            var userId = 0;
            try
            {
                userId = _authenticationService.Login(_mapper.Map<UserLoginDto>(loginUser));
            }
            catch (BadOperationException e)
            {
                if (e.Code == ErrorCode.WrongLogin)
                {
                    const string loginNotCorrectErrorMessage = "No users with this login";
                    return Unauthorized(new {error = loginNotCorrectErrorMessage});
                }

                if (e.Code == ErrorCode.WrongPassword)
                {
                    const string passwordErrorMessage = "Wrong password";
                    return Unauthorized(new {error = passwordErrorMessage});
                }
            }

            var tokenString = _authenticationService.GenerateJsonWebToken(userId);

            return Ok(new {token = tokenString});
        }
    }
}