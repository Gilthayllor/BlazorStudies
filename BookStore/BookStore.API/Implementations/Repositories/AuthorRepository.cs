using BookStore.API.Contracts.Repositories;
using BookStore.API.Data;

namespace BookStore.API.Implementations.Repositories
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationDbContext context)
            :base(context)
        {
            
        }
    }
}
