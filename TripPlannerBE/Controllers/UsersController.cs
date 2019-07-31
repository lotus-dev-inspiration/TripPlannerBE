using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TripPlannerBE.Context;
using TripPlannerBE.Models;

namespace TripPlannerBE.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		readonly TripPlannerContext db;

		public UsersController(TripPlannerContext context)
		{
			db = context;
		}

		// GET api/users
		[HttpGet]
		public ActionResult<IEnumerable<string>> Get()
		{
			var users = db.Users.ToList();
			return Ok(users);
		}

		// GET api/users/5
		[HttpGet("{id}")]
		public ActionResult<string> Get(int id)
		{
			var user = db.Users.FirstOrDefault(u => u.Id == id);
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
			{
				return BadRequest();
			}

			db.Add(user);
			db.SaveChanges();
			return Ok(user);
		}

		//// PUT api/values/5
		//[HttpPut("{id}")]
		//public void Put(int id, [FromBody] string value)
		//{
		//}

		//// DELETE api/values/5
		//[HttpDelete("{id}")]
		//public void Delete(int id)
		//{
		//}
	}
}
