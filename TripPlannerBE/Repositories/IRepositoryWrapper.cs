using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripPlannerBE.Repositories
{
	public interface IRepositoryWrapper
	{
		IUserRepository User { get; }
		void Save();
	}
}
