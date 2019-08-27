using Entities.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository
{
	public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
	{
		protected TripPlannerContext _context { get; set; }

		public RepositoryBase(TripPlannerContext context)
		{
			_context = context;
		}

		public IQueryable<T> FindAll()
		{
			return _context.Set<T>().AsNoTracking();
		}

		public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
		{
			return _context.Set<T>().Where(expression).AsNoTracking();
		}

		public void Create(T entity)
		{
			_context.Set<T>().Add(entity);
		}

		public void Update(T entity)
		{
			_context.Set<T>().Update(entity);
		}

		public void Delete(T entity)
		{
			_context.Set<T>().Remove(entity);
		}
	}
}
