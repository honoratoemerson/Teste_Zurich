using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_Zurich.Dominio.Interfaces.Repositorio.EF
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<int> AddAsync(TEntity entity);

        int Add(TEntity entity);

        Task<TEntity> GetByIdAsync(int id);

        TEntity GetById(int id);

        Task<List<TEntity>> GetAllAsync();

        List<TEntity> GetAll();

        Task<int> UpdateAsync(TEntity entity);

        int Update(TEntity entity);

        void Remove(TEntity entity);

        void RemoveVirtual(TEntity entity);
    }
}
