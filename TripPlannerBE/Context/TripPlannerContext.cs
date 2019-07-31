using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripPlannerBE.Models;

namespace TripPlannerBE.Context
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
