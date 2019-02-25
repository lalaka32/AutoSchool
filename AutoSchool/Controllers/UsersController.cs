using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
		IUserStoreService userStoreService;

		public UsersController(IUserStoreService userStoreService)
		{
			this.userStoreService = userStoreService;
		}

		public IActionResult Post(User user)
		{
			userStoreService.AddUser(user);
			return Ok();
		}
	}
}