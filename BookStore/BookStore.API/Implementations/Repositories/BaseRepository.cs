using BookStore.API.Contracts.Repositories;
using BookStore.API.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Implementations.Repositories
{
    public class BaseRepository<T> : IRepositoryBase<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext Context;
        protected DbSet<T> DbSet { get; }

        public BaseRepository(ApplicationDbContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }

        public async Task<bool> Create(T entity)
        {
            await DbSet.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(T entity)
        {
            DbSet.Remove(entity);
            return await Save();
        }

        public async Task<IList<T>> FindAll()
        {
            var result = await DbSet.ToListAsync();
            return result;
        }

        public async Task<T> FindById(int id)
        {
            var result = await DbSet.FindAsync(id);
            return result;
        }

        public async Task<bool> Save()
        {
            var changes = await Context.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(T entity)
        {
            DbSet.Update(entity);
            return await Save();
        }

        public async Task<bool> Exists(int id)
        {
            var exists = await DbSet.AsNoTracking().AnyAsync(x => x.Id == id);
            return exists;
        }
    }
}
