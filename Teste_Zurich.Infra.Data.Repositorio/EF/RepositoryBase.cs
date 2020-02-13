using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_Zurich.Dominio.Interfaces.Repositorio.EF;

namespace Teste_Zurich.Infra.Data.Repositorio.EF
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly DbContext _dbContext;

        public RepositoryBase(DbContext context)
        {
            _dbContext = context;
        }

        public virtual async Task<int> AddAsync(TEntity entity)
        {
            try
            {
                _dbContext.Set<TEntity>().Add(entity);
                await _dbContext.SaveChangesAsync();

                var objectType = entity.GetType();
                var propInfo = objectType.GetProperty("Id");

                if (propInfo is null) return 0;

                var id = propInfo.GetValue(entity);
                return int.Parse(id.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual int Add(TEntity entity)
        {
            try
            {
                _dbContext.Set<TEntity>().Add(entity);
                _dbContext.SaveChanges();

                var objectType = entity.GetType();
                var propInfo = objectType.GetProperty("Id");

                if (propInfo is null) return 0;

                var id = propInfo.GetValue(entity);
                return int.Parse(id.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<TEntity> GetByIdAsync(int id) =>
            _dbContext.Set<TEntity>().FindAsync(id);

        public TEntity GetById(int id) =>
            _dbContext.Set<TEntity>().Find(id);

        public Task<List<TEntity>> GetAllAsync() =>
            _dbContext.Set<TEntity>().ToListAsync();

        public List<TEntity> GetAll() =>
            _dbContext.Set<TEntity>().ToList();

        public virtual async Task<int> UpdateAsync(TEntity entity)
        {
            try
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                var objectType = entity.GetType();
                var propInfo = objectType.GetProperty("Id");

                if (propInfo is null) return 0;

                var id = propInfo.GetValue(entity);
                return int.Parse(id.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual int Update(TEntity entity)
        {
            try
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
                _dbContext.SaveChanges();
                var objectType = entity.GetType();
                var propInfo = objectType.GetProperty("Id");

                if (propInfo is null) return 0;

                var id = propInfo.GetValue(entity);
                return int.Parse(id.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual void Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public virtual void RemoveVirtual(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
