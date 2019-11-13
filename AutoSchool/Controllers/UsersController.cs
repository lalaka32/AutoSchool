using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.BisnessObjects;
using Common.Entities;
using DataService.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
		IUserService userStoreService;

		public UsersController(IUserService userStoreService)
		{
			this.userStoreService = userStoreService;
		}

		[HttpPost("[action]")]
		public IActionResult Post([FromBody]User user)
		{
            //userStoreService.Create(user);
            throw new NotImplementedException();
			return Ok();
		}
        [HttpGet("[action]")]
        public IActionResult Get()
        {
           // userStoreService.AddUser(new User());
            return Ok();
        }
    }
}