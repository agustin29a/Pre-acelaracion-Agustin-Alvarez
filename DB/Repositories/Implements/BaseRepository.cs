using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repositories
{
	public abstract class BaseRepository<TEntity, TContext> : IRepository<TEntity> where TEntity : class where TContext : DbContext
	{
		private readonly TContext _dbContext;
		public BaseRepository(TContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<List<TEntity>> GetAllEntities()
		{
			return await _dbContext.Set<TEntity>().ToListAsync();
		}

		public async Task<TEntity> GetById(int id)
		{
			return await _dbContext.Set<TEntity>().FindAsync(id);
		}

		public async Task<TEntity> Add(TEntity entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException(nameof(entity));
			}

			try
			{
				await _dbContext.Set<TEntity>().AddAsync(entity);
				await _dbContext.SaveChangesAsync();
				return entity;
			}
			catch (System.Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<TEntity> Update(TEntity entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException(nameof(entity));
			}

			try
			{
				_dbContext.Set<TEntity>().Update(entity);
				await _dbContext.SaveChangesAsync();
				return entity;
			}
			catch (System.Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task Delete(int id)
		{
			try
			{
				var entity = await GetById(id);

				if (entity == null)
				{
					throw new Exception("The entity is null");
				}
				else
				{
					_dbContext.Set<TEntity>().Remove(entity);
					await _dbContext.SaveChangesAsync();
				}
			}
			catch (System.Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
