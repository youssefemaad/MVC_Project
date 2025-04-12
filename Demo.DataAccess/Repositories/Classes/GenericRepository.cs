using Demo.DataAccess.Data.DbContexts;
using Demo.DataAccess.Models.Shared;
using Demo.DataAccess.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Demo.DataAccess.Repositories.Classes
{
	public class GenericRepository<TEntity>(ApplicationDbContext _dbContext) : IGenericRepository<TEntity> where TEntity : BaseEntity
	{
		public int Add(TEntity entity)
		{
			_dbContext.Set<TEntity>().Add(entity);
			return _dbContext.SaveChanges();
		}

		public IEnumerable<TEntity> GetAll(bool withTracking = false)
		{
			if (withTracking)
				return _dbContext.Set<TEntity>().Where(E => E.IsDeleted != true).ToList();
			else
				return _dbContext.Set<TEntity>().Where(E => E.IsDeleted != true).AsNoTracking().ToList();
		}

		public TEntity? GetById(int id) => _dbContext.Set<TEntity>().Find(id);

		public int Remove(TEntity entity)
		{
			_dbContext.Set<TEntity>().Remove(entity);
			return _dbContext.SaveChanges();
		}


		public IEnumerable<TResult> GetAll<TResult>(Expression<Func<TEntity, TResult>> selector)
		{
			return _dbContext.Set<TEntity>()
				.Where(e => !e.IsDeleted)
				.Select(selector)
				.ToList();
		}

		public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
		{
			return _dbContext.Set<TEntity>()
				.Where(predicate)
				.Where(e => !e.IsDeleted)
				.ToList();
		}
		public int Update(TEntity entity)
		{
			_dbContext.Set<TEntity>().Update(entity);
			return _dbContext.SaveChanges();
		}
	}
}
