using Entities.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripPlannerBE.Repositories
{
	public class RepositoryWrapper : IRepositoryWrapper
	{
		private TripPlannerContext _context;
		private IUserRepository _user;

		public IUserRepository User
		{
			get
			{
				if (_user == null)
				{
					_user = new UserRepository(_context);
				}

				return _user;
			}
		}

		public RepositoryWrapper(TripPlannerContext context)
		{
			_context = context;
		}

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
