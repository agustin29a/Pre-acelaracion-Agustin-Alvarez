using DB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Services.Implements
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
    {
        private IRepository<TEntity> _genericRepository;

        public GenericService(IRepository<TEntity> genericRepository)
        {
            this._genericRepository = genericRepository;
        }

        public async Task Delete(int id)
        {
            await _genericRepository.Delete(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _genericRepository.GetAllEntities();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _genericRepository.GetById(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            return await _genericRepository.Add(entity);
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            return await _genericRepository.Update(entity);
        }
    }
}
