using BookStore.API.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.API.Contracts.Repositories
{
    public interface IRepositoryBase<T> where T : BaseEntity
    {
        Task<IList<T>> FindAll();
        Task<T> FindById(int id);
        Task<bool> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task<bool> Save();
        Task<bool> Exists(int id);
    }
}
