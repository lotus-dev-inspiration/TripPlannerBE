using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;

namespace Entities.Context
{
	public class TripPlannerContext	: DbContext
	{
		public DbSet<User> Users { get; set; }
		public TripPlannerContext(DbContextOptions<TripPlannerContext> options)
			:base(options)
		{
			Database.EnsureCreated();			
		}
	}
}
