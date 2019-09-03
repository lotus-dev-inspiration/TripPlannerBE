using Entities.Context;
using Entities.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripPlannerBE.Repositories
{
	public class UserRepository : RepositoryBase<User>, IUserRepository
	{
		public UserRepository(TripPlannerContext context): base(context)
		{

		}
	}
}
