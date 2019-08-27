using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
	public class User
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Name is Required")]
		public string Name { get; set; }

		public string Email { get; set; }

		public int Age { get; set; }
	}
}
