using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repositories
{
	public interface IRepository<T>
		where T : class
	{
		public Task<List<T>> GetAllEntities();
		public Task<T> GetById(int id);
		public Task<T> Add(T entity);
		public Task<T> Update(T entity);
		public Task Delete(int id);
	}

}
