using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using TripPlannerBE.Repositories;

namespace TripPlannerBE.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private IRepositoryWrapper _repoWrapper;

		public UsersController(IRepositoryWrapper repoWrapper)
		{
			 _repoWrapper = repoWrapper;
		}

		// GET api/users
		[HttpGet]
		public virtual ActionResult<IEnumerable<User>> Get()
		{
			var users = _repoWrapper.User.FindAll().ToList(); 
			return Ok(users);
		}

		// GET api/users/5
		[HttpGet("{id}")]
		public ActionResult<string> Get(int id)
		{
			var user = _repoWrapper.User.FindByCondition(u => u.Id == id).FirstOrDefault();
			if(user == null)
			{
				return NotFound();
			}
			return Ok(user);
		}

		// POST api/users
		[HttpPost]
		public ActionResult Post([FromBody] User user)
		{
			if (!ModelState.IsValid)
				return BadRequest("Not a valid model");

			_repoWrapper.User.Create(user);
			_repoWrapper.Save();
			return Ok();
		}

		// PUT api/users/5
		[HttpPut("{id}")]
		public ActionResult Put(int id, [FromBody] User user)
		{
			if (!ModelState.IsValid)
				return BadRequest("Not a valid model");

			var foundUser = _repoWrapper.User.FindByCondition(u => u.Id == id).FirstOrDefault();

			if (foundUser == null)
			{
				return NotFound();
			}

			foundUser.Name = user.Name;
			foundUser.Age = user.Age;
			foundUser.Email = user.Email;
			_repoWrapper.User.Update(foundUser);
			_repoWrapper.Save();
			return Ok();
		}

		// DELETE api/users/5
		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			var user = _repoWrapper.User.FindByCondition(u => u.Id == id).FirstOrDefault();

			if (user == null)
			{
				return NotFound();
			}

			_repoWrapper.User.Delete(user);
			_repoWrapper.Save();
			return Ok();
		}
	}
}
