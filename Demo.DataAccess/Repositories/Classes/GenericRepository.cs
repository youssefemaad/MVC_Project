using Demo.DataAccess.Data.DbContexts;
using Demo.DataAccess.Models.Shared;
using Demo.DataAccess.Repositories.Interfaces;

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

		public IEnumerable<TResult> GetAll<TResult>(System.Linq.Expressions.Expression<Func<TEntity, TResult>> selector)
		{
			return _dbContext.Set<TEntity>().Where(E => E.IsDeleted != true)
											.Select(selector).ToList();
		}
		public int Update(TEntity entity)
		{
			_dbContext.Set<TEntity>().Update(entity);
			return _dbContext.SaveChanges();
		}
	}
}
